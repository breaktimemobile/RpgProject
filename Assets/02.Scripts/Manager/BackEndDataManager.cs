using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[DynamoDBTable("player_info")]
public class Player_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public int int_lv { get; set; }
    [DynamoDBProperty]
    public string int_exp { get; set; }
    [DynamoDBProperty]
    public string str_nick { get; set; }
    [DynamoDBProperty]
    public string str_Time_Check { get; set; }
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
    [DynamoDBProperty]
    public int Int_Upgrade_Lv { get; set; }
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
    [DynamoDBProperty]
    public bool is_boss { get; set; }
}

[DynamoDBTable("item_info")]
public class Item_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("item_Info")]
    public List<Item_Info> item_Info { get; set; }
    [DynamoDBProperty("roon_Info")]
    public List<Roon_Info> roon_Info { get; set; }
}

[DynamoDBTable("weapon_info")]
public class Weapon_Data
{

    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty]
    public int sword_mount { get; set; }
    [DynamoDBProperty]
    public int shield_mount { get; set; }
    [DynamoDBProperty]
    public int accessory_mount { get; set; }
    [DynamoDBProperty]
    public int costume_mount { get; set; }
    [DynamoDBProperty("weapon_info")]
    public List<Weapon_info> weapon_Info { get; set; }

}

[DynamoDBTable("skill_info")]
public class Skill_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("skill_info")]
    public List<Skill_info> skill_Info { get; set; }

}

[DynamoDBTable("content_info")]
public class Content_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("underground_info")]
    public List<Underground_info> underground_info { get; set; }
    [DynamoDBProperty("upgrade_info")]
    public List<Upgrade_info> upgrade_info { get; set; }
    [DynamoDBProperty("hell_info")]
    public List<Hell_info> hell_info { get; set; }
}

[DynamoDBTable("pet_info")]
public class Pet_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("pet_info")]
    public List<Pet_info> pet_info { get; set; }

}

[DynamoDBTable("job_info")]
public class Job_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("job_info")]
    public List<Job_info> job_info { get; set; }

}
public class Item_Info
{
    public int type { get; set; }
    public string str_val { get; set; }
}

public class Roon_Info
{
    public int type  = -1;
}

public class Weapon_info
{
    public Weapon_Content enum_weapon { get; set; }
    public int int_num { get; set; }
    public int int_lv { get; set; }
    public int int_upgread { get; set; }
    public int int_limit { get; set; }
    public int int_val { get; set; }
    public List<Roon_Slot> list_roon { get; set; }
}

public class Skill_info
{
    public int int_num { get; set; }
    public int int_lv { get; set; }

}

public class Underground_info
{
    public int int_num { get; set; }
    public int int_Max_Monster { get; set; }
    public int int_Max_Boss { get; set; }
}

public class Upgrade_info
{
    public int int_num { get; set; }
}

public class Hell_info
{
    public int int_num { get; set; }
}

public class Pet_info
{
    public int int_num { get; set; }
    public int int_lv { get; set; }
    public int int_pos { get; set; }

}

public class Roon_Slot
{
    public int int_slot = 0;
    public Roon_Info int_roon;
    public bool isLock = false;
}

public class Job_info
{
    public int int_num { get; set; }
    public int int_lv { get; set; }
    public string str_time { get; set; }
}

public class BackEndDataManager : MonoBehaviour
{
    public static BackEndDataManager instance = null;

    Player_Data player_Data = new Player_Data();
    Character_Data character_Data = new Character_Data();
    Stage_Data stage_Data = new Stage_Data();
    Item_Data item_Data = new Item_Data();
    Weapon_Data weapon_Data = new Weapon_Data();
    Skill_Data skill_Data = new Skill_Data();
    Content_Data content_Data = new Content_Data();
    Pet_Data pet_Data = new Pet_Data();
    Job_Data job_Data = new Job_Data();

    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;

    public Player_Data Player_Data { get => player_Data; }
    public Character_Data Character_Data { get => character_Data; }
    public Stage_Data Stage_Data { get => stage_Data; }
    public Item_Data Item_Data { get => item_Data; }
    public Weapon_Data Weapon_Data { get => weapon_Data; }
    public Skill_Data Skill_Data { get => skill_Data; }
    public Content_Data Content_Data { get => content_Data; }
    public Pet_Data Pet_Data { get => pet_Data; }
    public Job_Data Job_Data { get => job_Data; }

    public BigInteger Int_exp { get => int_exp; }

    public List<Dictionary<string, object>> underground_dungeon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> sword_csv_data;         //던전 정보
    public List<Dictionary<string, object>> shield_csv_data;         //던전 정보
    public List<Dictionary<string, object>> accessory_csv_data;         //던전 정보
    public List<Dictionary<string, object>> monster_csv_data;         //던전 정보
    public List<Dictionary<string, object>> ability_csv_data;         //던전 정보
    public List<Dictionary<string, object>> skill_csv_data;         //던전 정보
    public List<Dictionary<string, object>> content_csv_data;         //던전 정보
    public List<Dictionary<string, object>> underground_item_csv_data;         //던전 정보
    public List<Dictionary<string, object>> upgrade_dungeon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> hell_dungeon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> pet_csv_data;         //던전 정보
    public List<Dictionary<string, object>> roon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> job_csv_data;         //던전 정보

    public Item_s underground_item_ = new Item_s();         //던전 정보


    private List<bool> Check_Data = new List<bool>();

    private BigInteger int_exp = 0;

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


        for (int i = 0; i < Enum.GetValues(typeof(Data_Type)).Length; i++)
        {
            Check_Data.Add(false);

        }

        Get_Csv_Data();

        StartCoroutine("WebCheck");
    }

    /// <summary>
    /// csv 데이터 가져오기
    /// </summary>
    void Get_Csv_Data()
    {

        underground_dungeon_csv_data = CSVReader.Read("underground_dungeon");
        sword_csv_data = CSVReader.Read("sword");
        shield_csv_data = CSVReader.Read("shield");
        accessory_csv_data = CSVReader.Read("accessory");
        monster_csv_data = CSVReader.Read("monster");
        skill_csv_data = CSVReader.Read("skill");
        content_csv_data = CSVReader.Read("content");
        underground_item_csv_data = CSVReader.Read("underground_item");
        upgrade_dungeon_csv_data = CSVReader.Read("upgrade_dungeon");
        hell_dungeon_csv_data = CSVReader.Read("hell_dungeon");
        pet_csv_data = CSVReader.Read("pet");
        ability_csv_data = CSVReader.Read("ability");
        roon_csv_data = CSVReader.Read("roon");
        job_csv_data = CSVReader.Read("job");

        foreach (var data in skill_csv_data)
        {
            Skill skill = new Skill
            {
                num = int.Parse(data["num"].ToString()),
                name = data["name"].ToString(),
                max_lv = int.Parse(data["max_lv"].ToString()),
                price_type = int.Parse(data["price_type"].ToString()),
                price_val = int.Parse(data["price_val"].ToString()),
                price_percent = float.Parse(data["price_percent"].ToString()),
                ability_type = int.Parse(data["ability_type"].ToString()),
                base_ability = float.Parse(data["base_ability"].ToString()),
                ability_add = float.Parse(data["ability_add"].ToString()),
                skill_time = int.Parse(data["skill_time"].ToString()),
                cool_time = int.Parse(data["cool_time"].ToString()),
                f_total = 0
            };

            Skill_s.skills.Add(skill);
        }

        foreach (var data in underground_item_csv_data)
        {
            Item item_ = new Item
            {
                num = int.Parse(data["num"].ToString()),
                name = data["name"].ToString(),
                item_num = int.Parse(data["item_num"].ToString()),
                percent = float.Parse(data["percent"].ToString())
            };

            Item_s.items.Add(item_);
            Item_s.total += item_.percent;
        }

    }

    public void Set_NickName(string NickName)
    {

        bool Check = true;

        ScanRequest request = new ScanRequest()
        {
            TableName = "player_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            AttributeValue test;

            foreach (var item in result.Response.Items)
            {
                if (item.TryGetValue("str_nick", out test))
                {
                    if (NickName.Equals(test.S))
                        Check = false;
                }
            }

            Debug.Log(Check ? "없음" : "중복");

            Debug.Log(Check);

            if (!Check)
            {
                Debug.Log("중복됨");

                UiManager.instance.Check_Nick_State(false);

            }
            else
            {

                player_Data.str_nick = NickName;

                context.SaveAsync(player_Data, (result2) =>
                {
                    if (result2.Exception == null)
                    {
                        Debug.Log("닉네임");
                        PopupManager.Close_Popup();
                        PlayManager.instance.Play_Game();
                    }
                    else
                        Debug.Log(result2.Exception);
                });
            }


        });



    }

    public void Sucess_Data(Data_Type type)
    {
        if (SceneManager.GetActiveScene().name.Equals("Intro"))
        {
            Check_Data[(int)type] = true;
            Check_All_Data();

        }
    }

    public void Check_All_Data()
    {

        for (int i = 0; i < Check_Data.Count; i++)
        {
            if (!Check_Data[i])
                return;
        }

        Debug.Log("이건데?????");

        IntroManager.instance.Check_Next();

    }

    public void Get_First_Data()
    {
        Check_Player_Data();
        Check_Character_Data();
        Check_Stage_Data();
        Check_Item_Data();
        Check_Weapon_Data();
        Check_Skill_Data();
        Check_Content_Data();
        Check_Pet_Data();
        Check_Job_Data();

    }

    #region Check_Data

    public void Check_Player_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "player_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "player 없음" : "player 있음");

            if (t == null)
            {
                player_Data = new Player_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    int_lv = 1,
                    int_exp = "0",
                    str_nick = "null",
                    str_Time_Check = "null"

                };

                Save_Player_Data();
            }
            else
            {
                Get_Player_Data();
            }

        });
    }

    public void Check_Character_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "character_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "character_info 없음" : "character_info 있음");

            if (t == null)
            {

                character_Data = new Character_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    int_character_Lv = 1,
                    Int_character_Num = 0
                };

                Save_Character_Data();
            }
            else
            {
                Get_Character_Data();
            }

        });
    }

    public void Check_Stage_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "stage_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "stage 없음" : "stage 있음");

            if (t == null)
            {
                stage_Data = new Stage_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    int_chapter = 1,
                    int_stage = 1,
                    int_step = 1,
                    is_boss = false

                };

                Save_Stage_Data();
            }
            else
            {
                Get_Stage_Data();
            }

        });
    }

    public void Check_Item_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "item_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "item 없음" : "item 있음");

            if (t == null)
            {
                item_Data = new Item_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    item_Info = new List<Item_Info>
                    {
                        new Item_Info
                        {
                            type = 1,
                            str_val = "100"
                        }
                    }

                };

                Save_Item_Data();
            }
            else
            {
                Get_Item_Data();
            }

        });
    }

    public void Check_Weapon_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "weapon_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "weapon 없음" : "weapon 있음");

            if (t == null)
            {
                weapon_Data = new Weapon_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    weapon_Info = new List<Weapon_info>
                    {
                        new Weapon_info
                        {
                            enum_weapon = Weapon_Content.Sword,
                            int_num = 0,
                            int_lv =1,
                            int_upgread =0,
                            int_limit = 0
                        }
                    }

                };

                Save_Weapon_Data();
            }
            else
            {
                Get_Weapon_Data();
            }

        });
    }

    public void Check_Skill_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "skill_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "skill 없음" : "skill 있음");

            if (t == null)
            {
                skill_Data = new Skill_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    skill_Info = new List<Skill_info>()
                };

                Save_Skill_Data();
            }
            else
            {
                Get_Skill_Data();
            }

        });
    }

    public void Check_Content_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "content_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "Content 없음" : "Content 있음");

            if (t == null)
            {
                content_Data = new Content_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    underground_info = new List<Underground_info>
                    {
                        new Underground_info
                        {
                            int_num = 0,
                            int_Max_Monster =0,
                            int_Max_Boss =0

                        }
                    }
                };

                Save_Content_Data();
            }
            else
            {
                Get_Content_Data();
            }

        });
    }

    public void Check_Pet_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "pet_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "pet 없음" : "pet 있음");

            if (t == null)
            {
                pet_Data = new Pet_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    pet_info = new List<Pet_info>()
                };

                Save_Pet_Data();
            }
            else
            {
                Get_Pet_Data();
            }

        });
    }

    public void Check_Job_Data()
    {
        ScanRequest request = new ScanRequest()
        {
            TableName = "job_info"
        };

        DBclient.ScanAsync(request, (result) =>
        {

            Dictionary<string, AttributeValue> t =
              result.Response.Items.Find(x => x["id"].S.Equals(BackEndAuthManager.Get_UserId()));

            Debug.Log(t == null ? "job 없음" : "job 있음");

            if (t == null)
            {
                job_Data = new Job_Data
                {
                    id = BackEndAuthManager.Get_UserId(),
                    job_info = new List<Job_info>()
                };

                Job_info job_ = new Job_info()
                {
                    int_lv = 1,
                    int_num = 0,
                    str_time = ""
                };

                job_Data.job_info.Add(job_);

                Save_Job_Data();
            }
            else
            {
                Get_Job_Data();
            }

        });
    }

    #endregion

    #region Get_Data

    public void Get_Player_Data() //DB에서 캐릭터 정보 받기
    {

        Debug.Log("Get_Player_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Player_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            player_Data = result.Result;
            int_exp = BigInteger.Parse(player_Data.int_exp);

            Sucess_Data(Data_Type.player_info);


        }, null);
    }

    public void Get_Character_Data() //DB에서 캐릭터 정보 받기
    {
        Debug.Log("Get_Character_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Character_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            character_Data = result.Result;

            Sucess_Data(Data_Type.character_info);

        }, null);
    }

    public void Get_Stage_Data() //DB에서 캐릭터 정보 받기
    {
        Debug.Log("Get_Stage_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Stage_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }

            stage_Data = result.Result;

            Sucess_Data(Data_Type.stage_info);


        }, null);
    }

    public void Get_Item_Data() //DB에서 캐릭터 정보 받기
    {
        Debug.Log("Get_Item_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Item_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                return;
            }

            item_Data = result.Result;

            Sucess_Data(Data_Type.item_info);


        }, null);
    }

    public void Get_Weapon_Data() //DB에서 캐릭터 정보 받기
    {
        Debug.Log("Get_Weapon_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Weapon_Data> result) =>
        {

            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                Get_Weapon_Data();
                return;
            }

            weapon_Data = result.Result;

            Sucess_Data(Data_Type.weapon_info);


        }, null);
    }

    public void Get_Skill_Data() //DB에서 캐릭터 정보 받기
    {


        Debug.Log("Get_Skill_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Skill_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                Get_Skill_Data();
                return;
            }

            skill_Data = result.Result;

            foreach (var item in skill_Data.skill_Info)
            {
                Skill_s.Set_Skill_Val(item.int_num, item.int_lv);
            }

            Sucess_Data(Data_Type.skill_info);


        }, null);
    }

    public void Get_Content_Data() //DB에서 캐릭터 정보 받기
    {


        Debug.Log("Get_Content_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Content_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                return;
            }

            content_Data = result.Result;

            Sucess_Data(Data_Type.content_info);


        }, null);
    }

    public void Get_Pet_Data() //DB에서 캐릭터 정보 받기
    {


        Debug.Log("Get_Pet_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Pet_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                return;
            }

            pet_Data = result.Result;

            Sucess_Data(Data_Type.pet_info);


        }, null);
    }

    public void Get_Job_Data() //DB에서 캐릭터 정보 받기
    {


        Debug.Log("Get_Job_Data");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Job_Data> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.Log(result.Exception);
                return;
            }

            job_Data = result.Result;

            Sucess_Data(Data_Type.job_info);


        }, null);
    }

    #endregion

    #region Save_Data

    public void Save_Player_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(player_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log(" player_Data Save");
                Sucess_Data(Data_Type.player_info);
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
                Debug.Log(" character Save");
                Sucess_Data(Data_Type.character_info);

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
                Debug.Log(" stage_Data Save");
                Sucess_Data(Data_Type.stage_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Item_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(item_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log(" item_Data Save");
                Sucess_Data(Data_Type.item_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Weapon_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(weapon_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log(" item_Data Save");
                Sucess_Data(Data_Type.weapon_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Skill_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(skill_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log(" skill_Data Save");
                Sucess_Data(Data_Type.skill_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Content_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(content_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("content_Data Save");
                Sucess_Data(Data_Type.content_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    public void Save_Pet_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(pet_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("pet_Data Save");
                Sucess_Data(Data_Type.pet_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }


    public void Save_Job_Data() //DB에서 캐릭터 정보 받기
    {
        context.SaveAsync(job_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("job_Data Save");
                Sucess_Data(Data_Type.job_info);

            }
            else
                Debug.Log(result.Exception);
        });
    }

    

    #endregion


    public void Minus_Item(Item_Type item_Type, BigInteger coin)
    {

        Set_Item(item_Type, coin, Calculate_Type.mius);

    }

    public void Add_Exp(BigInteger exp)
    {
        int_exp += exp;
        BigInteger Total_ = Total_exp();

        if (int_exp >= Total_)
        {

            int_exp -= Total_;

            Player_Data.int_exp = int_exp.ToString();
            Player_Data.int_lv += 1;

            Debug.Log(int_exp + "  " + Total_);

            UiManager.instance.Set_Txt_Lv();

            UiManager.instance.Check_Underground_Unlock();
            UiManager.instance.Check_Upgrade_Unlock();
        }

        UiManager.instance.Set_Txt_Exp();

        player_Data.int_exp = int_exp.ToString();
        Save_Player_Data();

    }

    public BigInteger Total_exp()
    {
        BigInteger total_exp = 30;

        for (int i = 0; i < Player_Data.int_lv - 1; i++)
        {
            total_exp = total_exp + BigInteger.Divide(total_exp, 10);
        }

        return total_exp;
    }

    public BigInteger Monster_Hp(bool boss)
    {
        BigInteger total_hp = 0;

        switch (PlayManager.instance.Stage_State)
        {
            case Stage_State.stage:

                total_hp = (int)monster_csv_data[0]["Base_Hp"] * (boss ? 10 : 1);
                for (int i = 0; i < stage_Data.int_stage - 1; i++)
                {
                    total_hp = total_hp + BigInteger.Divide(total_hp, 2);
                }

                break;

            case Stage_State.underground:

                BigInteger pow = (BigInteger)Math.Pow(1000, Underground_.Underground_Lv);

                if (boss)
                    total_hp = BigInteger.Parse(underground_dungeon_csv_data[0]["boss_hp"].ToString()) * pow;
                else
                    total_hp = BigInteger.Parse(underground_dungeon_csv_data[0]["hp"].ToString()) * pow;

                break;

            case Stage_State.upgrade:

                pow = (BigInteger)Math.Pow(10, Upgrade_.Upgrade_Lv);

                total_hp = BigInteger.Parse(upgrade_dungeon_csv_data[0]["hp"].ToString()) * pow;

                break;
            default:
                break;
        }


        Debug.Log("TOTAL " + total_hp);
        return total_hp;

    }

    public BigInteger Monster_Exp(bool boss)
    {
        BigInteger total_exp = stage_Data.int_stage;

        for (int i = 0; i < stage_Data.int_stage - 1; i++)
        {
            total_exp = total_exp + 3;
        }

        total_exp = total_exp * (boss ? 1 : 2);

        return total_exp;
    }

    public void Monster_Reward(Item_Type i, BigInteger val, bool boss)
    {

        Debug.Log(i + "  " + val);

        BigInteger a = (val * (boss ? 2 : 1));
        Set_Item(i, a, Calculate_Type.plus);

    }

    public BigInteger Get_Item(Item_Type type)
    {
        Item_Info item_Info = item_Data.item_Info.Find(x => x.type.Equals((int)type));

        if (item_Info == null)
            return 0;
        else
            return BigInteger.Parse(item_Info.str_val);

    }

    public void Set_Roon(int type, Calculate_Type calculate)
    {
        Roon_Info item_ = new Roon_Info
        {
            type = type,
        };

        if (Item_Data.roon_Info == null)
        {
            Item_Data.roon_Info = new List<Roon_Info>();

        }

        Item_Data.roon_Info.Add(item_);

        Save_Item_Data();

    }

    public void Set_Item(Item_Type type, BigInteger val, Calculate_Type calculate)
    {
        Item_Info item_Info = item_Data.item_Info.Find(x => x.type.Equals((int)type));

        if (item_Info == null)
        {
            Item_Info item_ = new Item_Info
            {
                type = (int)type,
                str_val = val.ToString()
            };

            item_Data.item_Info.Add(item_);

        }
        else
        {
            BigInteger total = Get_Item(type);
            Debug.Log(val);
            switch (calculate)
            {
                case Calculate_Type.plus:
                    total += val;
                    break;
                case Calculate_Type.mius:
                    total -= val;
                    break;
                default:
                    break;
            }

            item_Info.str_val = total.ToString();

        }

        UiManager.instance.Set_Inventory_Val(type);

        switch (type)
        {
            case Item_Type.crystal:
                UiManager.instance.Set_Txt_Crystal();
                break;
            case Item_Type.coin:
                UiManager.instance.Set_Txt_Coin();
                UiManager.instance.Set_Buy_Lv();

                break;
            case Item_Type.upgrade_stone:
                UiManager.instance.Set_Txt_Upgrade_Stone();

                break;
            case Item_Type.limit_stone:
                break;
            case Item_Type.steel:
                UiManager.instance.Set_Txt_Steel();

                break;
            case Item_Type.soul_stone:
                UiManager.instance.Set_Txt_Soul_Stone();
                UiManager.instance.Check_Upgrade();
                UiManager.instance.Set_Skill_Buy();
                break;
            case Item_Type.black_stone:
                UiManager.instance.Set_Txt_Black_Stone();
                break;
            case Item_Type.topaz:
                break;
            case Item_Type.ruby:
                break;
            case Item_Type.emerald:
                break;
            case Item_Type.sapphire:
                break;
            case Item_Type.weapon_box_d_c:
                break;
            case Item_Type.weapon_box_d_b:
                break;
            case Item_Type.weapon_box_d_a:
                break;
            case Item_Type.weapon_box_d_s:
                break;
            case Item_Type.shield_box_d_c:
                break;
            case Item_Type.shield_box_d_b:
                break;
            case Item_Type.shield_box_d_a:
                break;
            case Item_Type.shield_box_d_s:
                break;
            case Item_Type.accessory_box_d_c:
                break;
            case Item_Type.accessory_box_d_b:
                break;
            case Item_Type.accessory_box_d_a:
                break;
            case Item_Type.accessory_box_d_s:
                break;
            case Item_Type.upgrade_stone_box_1_100:
                break;
            case Item_Type.upgrade_stone_box_100_500:
                break;
            case Item_Type.upgrade_stone_box_500_1000:
                break;
            case Item_Type.upgrade_stone_box_1000_3000:
                break;
            case Item_Type.upgrade_stone_box_3000_5000:
                break;
            case Item_Type.upgrade_stone_box_5000_10000:
                break;
            case Item_Type.upgrade_stone_box_10000_20000:
                break;
            case Item_Type.underground_ticket:
                UiManager.instance.Check_Underground_Ticket();
                UiManager.instance.Set_Txt_Underground_Ticket();
                break;
            case Item_Type.upgrade_ticket:
                UiManager.instance.Set_Txt_Upgrade_Ticket();
                break;
            case Item_Type.hell_ticket:
                UiManager.instance.Set_Txt_Hell_Ticket();
                break;
            case Item_Type.yellow_key:
                break;
            case Item_Type.red_key:
                break;
            case Item_Type.blue_key:
                break;
            case Item_Type.green_key:
                break;
            case Item_Type.black_key:
                break;
            case Item_Type.yellow_marble:
                break;
            case Item_Type.red_marble:
                break;
            case Item_Type.blue_marble:
                break;
            case Item_Type.green_marble:
                break;
            case Item_Type.black_marble:
                break;
            case Item_Type.meat:
                break;
            case Item_Type.heart:
                break;
            case Item_Type.guild_coin:
                break;
            case Item_Type.weapon_limit_stone_d:
                break;
            case Item_Type.weapon_limit_stone_c:
                break;
            case Item_Type.weapon_limit_stone_b:
                break;
            case Item_Type.weapon_limit_stone_a:
                break;
            case Item_Type.weapon_limit_stone_s:
                break;
            case Item_Type.weapon_limit_stone_ss:
                break;
           
            default:
                break;
        }

        Save_Item_Data();
    }

    public void Buy_Character_Lv(Character_Lv character_Lv)
    {
        int lv = Character_Data.int_character_Lv;
        BigInteger lv_1 = Calculate.Price(500, 5, lv, (int)character_Lv);

        Set_Item(Item_Type.coin, lv_1, Calculate_Type.mius);

        Player_stat.Add_Lv((int)character_Lv);

    }

    public void Check_Underground_Info()
    {
        Underground_info _Info = content_Data.underground_info.Find(x => x.int_num.Equals(Underground_.Underground_Lv));

        if (_Info == null)
        {
            Debug.Log(Underground_.underground_Info.int_Max_Boss);
            Debug.Log(Underground_.underground_Info.int_Max_Monster);

            Underground_info info = Underground_.underground_Info;

            content_Data.underground_info.Add(info);
        }
        else
        {
            Debug.Log(_Info.int_Max_Boss);
            Debug.Log(_Info.int_Max_Monster);

            if (Underground_.underground_Info.int_Max_Boss >= _Info.int_Max_Boss)
                _Info.int_Max_Boss = Underground_.underground_Info.int_Max_Boss;

            if (Underground_.underground_Info.int_Max_Monster >= _Info.int_Max_Monster)
                _Info.int_Max_Monster = Underground_.underground_Info.int_Max_Monster;

        }

        Save_Content_Data();
    }

    #region Network

    public DateTime WebCheck()
    {

        DateTime dateTime = DateTime.MinValue;

        UnityWebRequest request = new UnityWebRequest();
        try
        {

            using (request = UnityWebRequest.Get("www.google.net"))
            {
                if (request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    string date = request.GetResponseHeader("date");
                    dateTime = DateTime.Parse(date);
                    Debug.Log(dateTime.ToString());

                }
            }
        }
        catch
        {
            dateTime = DateTime.Now;
        }

        return dateTime;
    }

    public void Check_Time_Item()
    {
        Debug.Log("player_Data.str_Time_Check " + player_Data.str_Time_Check);

        if (player_Data.str_Time_Check.Equals("null"))
        {
            Debug.Log("널이다");
            Set_Item(Item_Type.hell_ticket, 2, Calculate_Type.plus);
            Set_Item(Item_Type.underground_ticket, 2, Calculate_Type.plus);
            Set_Item(Item_Type.upgrade_ticket, 2, Calculate_Type.plus);

            player_Data.str_Time_Check = WebCheck().ToString();
            Save_Player_Data();
        }
        else
        {

            DateTime date = DateTime.Parse(player_Data.str_Time_Check);
            DateTime Web = WebCheck();

            Debug.Log(date.Day + " 체크 " + Web.Day);

            if (date.Day != Web.Day)
            {
                Debug.Log("줘야댐");

                Set_Item(Item_Type.hell_ticket, 2, Calculate_Type.plus);
                Set_Item(Item_Type.underground_ticket, 2, Calculate_Type.plus);
                Set_Item(Item_Type.upgrade_ticket, 2, Calculate_Type.plus);

                player_Data.str_Time_Check = WebCheck().ToString();
                Save_Player_Data();
            }
        }

    }

    #endregion


}
