﻿using Amazon;
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
    [DynamoDBProperty]
    public bool is_boss { get; set; }
}

[DynamoDBTable("item_info")]
public class Item_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("Item_Info")]
    public List<Item_Info> item_Info { get; set; }

}

[DynamoDBTable("weapon_info")]
public class Weapon_Data
{
    [DynamoDBHashKey] // Hash key.
    public string id { get; set; }
    [DynamoDBProperty("Weapon_info")]
    public List<Weapon_info> weapon_Info { get; set; }

}

public class Item_Info
{
    public int type { get; set; }
    public string str_val { get; set; }
}

public class Weapon_info
{
    public int int_num { get; set; }
    public int int_lv { get; set; }
    public int int_upgread { get; set; }
    public int int_limit { get; set; }
}

public class BackEndDataManager : MonoBehaviour
{
    public static BackEndDataManager instance = null;

    Player_Data player_Data = new Player_Data();
    Character_Data character_Data = new Character_Data();
    Stage_Data stage_Data = new Stage_Data();
    Item_Data item_Data = new Item_Data();
    Weapon_Data weapon_Data = new Weapon_Data();

    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;

    public Player_Data Player_Data { get => player_Data; }
    public Character_Data Character_Data { get => character_Data; }
    public Stage_Data Stage_Data { get => stage_Data; }
    public Item_Data Item_Data { get => item_Data; }
    public Weapon_Data Weapon_Data { get => weapon_Data; }

    public BigInteger Int_coin { get => int_coin; }
    public BigInteger Int_exp { get => int_exp; }

    public List<Dictionary<string, object>> dungeon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> weapon_csv_data;         //던전 정보
    public List<Dictionary<string, object>> monster_csv_data;         //던전 정보

    private bool[] Check_Data = new bool[] { false, false, false, false, false };

    private BigInteger int_coin = 0;
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

        Get_Csv_Data();
    }

    /// <summary>
    /// csv 데이터 가져오기
    /// </summary>
    void Get_Csv_Data()
    {

        dungeon_csv_data = CSVReader.Read("dungeon");
        weapon_csv_data = CSVReader.Read("weapon");
        monster_csv_data = CSVReader.Read("monster");
        Debug.Log("monster_csv_data " + monster_csv_data.Count);
        Debug.Log("monster_csv_data " + monster_csv_data[0]["reward_val_0"]);


    }

    private void CreateData() //캐릭터 정보를 DB에 올리기
    {


        player_Data = new Player_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_lv = 1,
            int_exp = "0",
            str_nick = "null"

        };

        character_Data = new Character_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_character_Lv = 1,
            Int_character_Num = 0
        };

        stage_Data = new Stage_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            int_chapter = 1,
            int_stage = 1,
            int_step = 1,
            is_boss = false

        };

        item_Data = new Item_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            item_Info = new List<Item_Info>
            {
                new Item_Info
                {
                    type = 1,
                    str_val = "0"
                }
            }

        };

        weapon_Data = new Weapon_Data
        {
            id = BackEndAuthManager.Get_UserId(),
            weapon_Info = new List<Weapon_info>
            {
                new Weapon_info
                {
                    int_num = 0,
                    int_lv =1,
                    int_upgread =0,
                    int_limit = 0
                }
            }

        };

        context.SaveAsync(player_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("Player_Data Save");

                Sucess_Data(Data_Type.player_info);


            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(character_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("character_Data Save");

                Sucess_Data(Data_Type.character_info);


            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(Stage_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("Stage_Data Save");

                Sucess_Data(Data_Type.stage_info);


            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(item_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("item_Data Save");

                Sucess_Data(Data_Type.item_info);


            }
            else
                Debug.Log(result.Exception);
        });

        context.SaveAsync(weapon_Data, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("weapon_Data Save");

                Sucess_Data(Data_Type.weapon_info);


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
            TableName = "player_info"
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

    public void Get_First_Game()
    {
        Debug.Log("이거 시작 아닌가????? ");

        context.LoadAsync(BackEndAuthManager.Get_UserId(), (AmazonDynamoDBResult<Player_Data> result) =>
        {
            Debug.Log("왜안나오니??");

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

    public void Sucess_Data(Data_Type type)
    {
        Debug.Log(type.ToString());
        Check_Data[(int)type] = true;
        Check_All_Data();

    }

    public void Check_All_Data()
    {

        for (int i = 0; i < Check_Data.Length; i++)
        {
            if (!Check_Data[i])
                return;
        }

        IntroManager.instance.Check_Next();
    }

    public void Get_First_Data()
    {
        Get_Player_Data();
        Get_Character_Data();
        Get_Stage_Data();
        Get_Item_Data();
        Get_Weapon_Data();

    }

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

            Item_Info item_Info = item_Data.item_Info.Find(x => x.type.Equals((int)Item_Type.coin));
            int_coin = BigInteger.Parse(item_Info.str_val);
            
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
                return;
            }

            weapon_Data = result.Result;

            Sucess_Data(Data_Type.weapon_info);


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
            }
            else
                Debug.Log(result.Exception);
        });
    }

    #endregion

   
    public void Minus_Coin(ulong coin)
    {
        int_coin -= coin;

        Set_Item(Item_Type.coin, int_coin);
        UiManager.instance.Set_Txt_Coin();
        UiManager.instance.Set_Buy_Lv();

    }

    public void Add_Exp(BigInteger exp)
    {
        int_exp += exp;
        BigInteger Total_ = Total_exp();

        Debug.Log(int_exp +  "  " + Total_  );

        if (int_exp >= Total_)
        {

            int_exp -= Total_;

            Player_Data.int_exp = int_exp.ToString();
            Player_Data.int_lv += 1;

            Debug.Log(int_exp + "  " + Total_);

            UiManager.instance.Set_Txt_Lv();

        }

        UiManager.instance.Set_Txt_Exp();

        player_Data.int_exp = int_exp.ToString();
        Save_Player_Data();

    }

    /// <summary>
    /// 총합 경험치
    /// </summary>
    /// <returns></returns>
    public BigInteger Total_exp()
    {
        BigInteger total_exp = 30;

        for (int i = 0; i < Player_Data.int_lv - 1; i++)
        {
            total_exp = total_exp + BigInteger.Divide(total_exp, 10);
        }

        return total_exp;
    }

    /// <summary>
    /// 총합 경험치
    /// </summary>
    /// <returns></returns>
    public BigInteger Monster_Hp(bool boss)
    {

        BigInteger total_hp = (int)monster_csv_data[0]["Base_Hp"] * (boss ? 10 : 1);

        for (int i = 0; i < stage_Data.int_stage - 1; i++)
        {
            total_hp = total_hp + BigInteger.Divide(total_hp, 2);
        }

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

    public void Monster_Reward(Item_Type i,BigInteger val,bool boss)
    {

        Debug.Log(i +"  " + val);

        BigInteger a =  BigInteger.Parse(Get_Item(i)) + val * (boss ? 2 : 1);
        Set_Item(i, a);
        
    }

    public string Get_Item(Item_Type type)
    {
        Item_Info item_Info = item_Data.item_Info.Find(x => x.type.Equals((int)type));

        if (item_Info == null)
            return "0";
        else
            return item_Info.str_val;

    }

    public void Set_Item(Item_Type type, BigInteger val)
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
            item_Info.str_val = val.ToString();

        }

        UiManager.instance.Set_Inventory_Val(type);

        switch (type)
        {
            case Item_Type.crystal:
                UiManager.instance.Set_Txt_Dia();
                break;
            case Item_Type.coin:
                int_coin = val;
                UiManager.instance.Set_Txt_Coin();
                UiManager.instance.Set_Buy_Lv();

                break;
            case Item_Type.upgread_stone:
                break;
            case Item_Type.limit_stone:
                break;
            case Item_Type.steel:
                UiManager.instance.Set_Txt_Steel();

                break;
            case Item_Type.tree:
                break;
            case Item_Type.block_stone:
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
            case Item_Type.upgread_stone_box_1_100:
                break;
            case Item_Type.upgread_stone_box_100_500:
                break;
            case Item_Type.upgread_stone_box_500_1000:
                break;
            case Item_Type.upgread_stone_box_1000_3000:
                break;
            case Item_Type.upgread_stone_box_3000_5000:
                break;
            case Item_Type.upgread_stone_box_5000_10000:
                break;
            case Item_Type.upgread_stone_box_10000_20000:
                break;
            case Item_Type.underground_ticket:
                break;
            case Item_Type.upgread_ticket:
                break;
            case Item_Type.hell_ticket:
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
            case Item_Type.weapon_shield_stone_d:
                break;
            case Item_Type.weapon_shield_stone_c:
                break;
            case Item_Type.weapon_shield_stone_b:
                break;
            case Item_Type.weapon_shield_stone_a:
                break;
            case Item_Type.weapon_shield_stone_s:
                break;
            case Item_Type.weapon_shield_stone_ss:
                break;
            case Item_Type.weapon_accessory_stone_d:
                break;
            case Item_Type.weapon_accessory_stone_c:
                break;
            case Item_Type.weapon_accessory_stone_b:
                break;
            case Item_Type.weapon_accessory_stone_a:
                break;
            case Item_Type.weapon_accessory_stone_s:
                break;
            case Item_Type.weapon_accessory_stone_ss:
                break;
            default:
                break;
        }

        Save_Item_Data();
    }

    public void Buy_Character_Lv(Character_Lv character_Lv)
    {
        ulong lv = (ulong)Character_Data.int_character_Lv;
        ulong lv_1 = 500 + (500 / 20) * (lv - 1);

        switch (character_Lv)
        {
            case Character_Lv.lv_1:
                Minus_Coin(lv_1);
                Player_stat.Add_Lv(1);
                break;
            case Character_Lv.lv_10:
                Minus_Coin(lv_1 * 10);
                Player_stat.Add_Lv(10);

                break;
            case Character_Lv.lv_100:
                Minus_Coin(lv_1 * 100);
                Player_stat.Add_Lv(100);

                break;
            default:
                break;
        }
    }
}
