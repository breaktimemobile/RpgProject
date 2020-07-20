using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DynamoDBTable("user_info")]
public class User_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public string str_nick { get; set; }
}


[DynamoDBTable("player_info")]
public class Player_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public int int_lv { get; set; }
    [DynamoDBProperty]
    public int int_exp { get; set; }
    [DynamoDBProperty]
    public int int_steel { get; set; }
    [DynamoDBProperty]
    public int int_coin { get; set; }
    [DynamoDBProperty]
    public int int_dia { get; set; }
}

[DynamoDBTable("character_info")]
public class Character_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public int int_character_Lv { get; set; }
    [DynamoDBProperty]
    public int Int_character_Num { get; set; }

}

[DynamoDBTable("stage_info")]
public class Stage_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public int int_chapter { get; set; }
    [DynamoDBProperty]
    public int int_stage { get; set; }
    [DynamoDBProperty]
    public int int_step { get; set; }
}

public class BackEndDataManager : MonoBehaviour
{
    public static BackEndDataManager instance = null;

    User_Data user_Data = new User_Data();
    Player_Data player_Data = new Player_Data();
    Character_Data character_Data = new Character_Data();
    Stage_Data stage_Data = new Stage_Data();

    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;

    public Player_Data Player_Data { get => player_Data; }
    public Character_Data Character_Data { get => character_Data; }
    public Stage_Data Stage_Data { get => stage_Data; }
    public User_Data User_Data { get => user_Data; }

    private bool[] Check_Data = new bool[] { false, false, false, false };

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;

        UnityInitializer.AttachToGameObject(this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        credentials = new CognitoAWSCredentials("ap-northeast-2:f497c006-2a2e-4336-b2da-7d8bb5c45f24", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);

    }

    private void CreateData() //캐릭터 정보를 DB에 올리기
    {


        User_Data user = new User_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            str_nick = "null"
        };

        Player_Data player = new Player_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_lv = 1

        };

        Character_Data character = new Character_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_character_Lv = 1

        };

        Stage_Data stage = new Stage_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_chapter = 1,
            int_stage = 1,
            int_step = 1

        };

        context.SaveAsync(user, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[0] = true;
                Debug.Log(" User_Data Save");
            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(player, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[1] = true;

                Debug.Log("Player_Data Save");

            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(character, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[2] = true;

                Debug.Log("character_Data Save");

            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(stage, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[3] = true;

                Debug.Log("Stage_Data Save");

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Set_NickName(string NickName)
    {

        bool Check = true;

        ScanRequest request = new ScanRequest()
        {
            TableName = "user_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            AttributeValue test;

            foreach (var item in result.Response.Items)
            {
                List<string> list = new List<string>();
                if (item.TryGetValue("str_nick", out test))
                {
                    if (NickName.Equals(test.S))
                        Check = false;
                }
            }

            Debug.Log(Check ? "없음" : "중복");

            if (!Check)
            {
                UiManager.instance.Check_Nick_State(false);
                return;

            }


        });

        user_Data.str_nick = NickName;

        context.SaveAsync(user_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("닉네임");
                PopupManager.Close_Popup();
                PlayManager.instance.Play_Game();
            }
            else
                Debug.Log(result.Exception);
        });

    }


    public void Get_First_Game()
    {
        StartCoroutine("Co_Check_Get_Data");
        context.LoadAsync<User_Data>(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<User_Data> result) =>
        {

            if (result.Result == null)
            {
                Debug.Log("처음시작");
                CreateData();
            }
            else
            {
                Debug.Log("데이터가 있음");
                //데이터 불러오기
                Get_First_Data();
            }

        }, null);


    }

    IEnumerator Co_Check_Get_Data()
    {
        bool total_check = false;

        while (!total_check)
        {
            for (int i = 0; i < Check_Data.Length; i++)
            {
                total_check = Check_Data[i];
            }

            yield return new WaitForSeconds(0.1f);
        }

        IntroManager.instance.Check_Next();
    }

    public void Get_First_Data()
    {
        Get_User_Data();
        Get_Player_Data();
        Get_Character_Data();
        Get_Stage_Data();
    }

    #region Get_Data

    public void Get_User_Data() //DB에서 캐릭터 정보 받기
    {
        context.LoadAsync<User_Data>(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<User_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            Check_Data[0] = true;

            user_Data = result.Result;
            Debug.Log(player_Data.int_lv); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }


    public void Get_Player_Data() //DB에서 캐릭터 정보 받기
    {
        context.LoadAsync<Player_Data>(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Player_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            Check_Data[1] = true;

            player_Data = result.Result;
            Debug.Log(player_Data.int_lv); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }

    public void Get_Character_Data() //DB에서 캐릭터 정보 받기
    {
        context.LoadAsync<Character_Data>(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Character_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            Check_Data[2] = true;

            character_Data = result.Result;
            Debug.Log(player_Data.int_lv); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }

    public void Get_Stage_Data() //DB에서 캐릭터 정보 받기
    {
        context.LoadAsync<Stage_Data>(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Stage_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            Check_Data[3] = true;

            stage_Data = result.Result;
            Debug.Log(player_Data.int_lv); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }

    #endregion

    #region Save_Data

    public void Save_User_Data() //DB에서 캐릭터 정보 받기
    {

        context.SaveAsync(user_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[0] = true;
                Debug.Log(" User_Data Save");
            }
            else
                Debug.Log(result.Exception);
        });

    }


    public void Save_Player_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(player_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[0] = true;
                Debug.Log(" User_Data Save");
            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Character_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(character_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[0] = true;
                Debug.Log(" User_Data Save");
            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Stage_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(stage_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Check_Data[0] = true;
                Debug.Log(" User_Data Save");
            }
            else
                Debug.Log(result.Exception);
        });
    }

    #endregion
}
