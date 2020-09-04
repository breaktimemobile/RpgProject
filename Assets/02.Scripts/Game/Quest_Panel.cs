using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;


public class Quest_Panel : MonoBehaviour
{
    Image img_quest;
    Text txt_quest_name;
    Text txt_quest_val;
    Button btn_quest;
    Text txt_quest_success;
    Text txt_quest_get;
    Text txt_quest_ing;

    Dictionary<string, object> data;

    public int num = 0;
    public int game_info_type = -1;
    Quest_Type type = Quest_Type.daily;

    public void Set_Quest(Dictionary<string, object> data_,Quest_Type type_)
    {
        type = type_;
        data = data_;

        num = (int)data["num"];

        img_quest = transform.Find("img_quest").GetComponent<Image>();
        txt_quest_name = transform.Find("txt_quest_name").GetComponent<Text>();
        txt_quest_val = transform.Find("txt_quest_val").GetComponent<Text>();
        btn_quest = transform.Find("btn_quest").GetComponent<Button>();
        txt_quest_success = btn_quest.transform.Find("txt_quest_success").GetComponent<Text>();
        txt_quest_get = btn_quest.transform.Find("txt_quest_get").GetComponent<Text>();
        txt_quest_ing = btn_quest.transform.Find("txt_quest_ing").GetComponent<Text>();

        txt_quest_name.text = data["name"].ToString();

        btn_quest.onClick.AddListener(() => Get_Quest_Reward());
        Set_Val();

    }

    public void Set_Val()
    {
        Quest_info quest_Info = BackEndDataManager.instance.Quest_Data.quest_Info
            .Find(x => x.int_num.Equals(num) && x.type.Equals(type));

        if (quest_Info == null)
        {
            quest_Info = new Quest_info
            {
                int_num = num,
                type = type,
                int_clear = 0,
                int_val = 0
            };

            BackEndDataManager.instance.Quest_Data.quest_Info.Add(quest_Info);
            BackEndDataManager.instance.Save_Quest_Data();
        }

        BigInteger count = (int)data["count"];

        switch (type)
        {
            case Quest_Type.daily:

                if (quest_Info.int_clear >= 1)
                {
                    txt_quest_success.gameObject.SetActive(true);
                    txt_quest_get.gameObject.SetActive(false);
                    txt_quest_ing.gameObject.SetActive(false);
                    btn_quest.interactable = false;
                }
                else
                {
                    txt_quest_success.gameObject.SetActive(false);

                    if (quest_Info.int_val >= count)
                    {
                        txt_quest_get.gameObject.SetActive(true);
                        txt_quest_ing.gameObject.SetActive(false);
                        btn_quest.interactable = true;
                    }
                    else
                    {
                        txt_quest_get.gameObject.SetActive(false);
                        txt_quest_ing.gameObject.SetActive(true);
                        btn_quest.interactable = false;
                    }
                }

                txt_quest_val.text = string.Format("{0}/{1}", quest_Info.int_val, count);

                break;
            case Quest_Type.accumulate:

                game_info_type = (int)data["game_info_type"];

                txt_quest_success.gameObject.SetActive(false);

                if ((int)data["val_type"] == 0) 
                    count = (int)data["count"] + (int)data["val_amount_0"] * quest_Info.int_clear;
                else
                {
                    float percent = (float)data["val_amount_0"] * 100;

                    count = Calculate.Price((int)data["count"], (int)percent,quest_Info.int_clear,1);

                }

                if (Game_info_.Get_Game_info((Game_Info_Type)game_info_type) >= count)
                {
                    txt_quest_get.gameObject.SetActive(true);
                    txt_quest_ing.gameObject.SetActive(false);
                    btn_quest.interactable = true;

                }
                else
                {
                    txt_quest_get.gameObject.SetActive(false);
                    txt_quest_ing.gameObject.SetActive(true);
                    btn_quest.interactable = false;

                }

                switch ((Accumulate_Quest_Type)num)
                {
                   
                    case Accumulate_Quest_Type.upgrade_stone:
                    case Accumulate_Quest_Type.limit_stone:
                    case Accumulate_Quest_Type.black_stone:
                    case Accumulate_Quest_Type.crystal:
                    case Accumulate_Quest_Type.coin:
                    case Accumulate_Quest_Type.steel:
                    case Accumulate_Quest_Type.player_level:
                        txt_quest_val.text = string.Format("{0}/{1}", UiManager.instance.GetGoldString(Game_info_.Get_Game_info((Game_Info_Type)game_info_type)), UiManager.instance.GetGoldString(count));

                        break;
                    default:
                        txt_quest_val.text = string.Format("{0}/{1}", Game_info_.Get_Game_info((Game_Info_Type)game_info_type), count);

                        break;
                }

                break;
            default:
                break;
        }
    }

    public void Get_Quest_Reward()
    {
        if (type.Equals(Quest_Type.daily))
        {
            Quest_.Check_Daily_Quest(Daily_Quest_Type.daily_clear, 1);
            Game_info_.Set_Game_Info(Game_Info_Type.daily_quest_clear, 1);

        }

        Quest_info quest_Info = BackEndDataManager.instance.Quest_Data.quest_Info
        .Find(x => x.int_num.Equals(num) && x.type.Equals(type));

        quest_Info.int_clear += 1;
        BigInteger big = BigInteger.Parse(data["reward_val_0"].ToString());

        UiManager.instance.Set_QuestItem((Item_Type)data["reward_0"],big);

        BackEndDataManager.instance.Set_Item((Item_Type)data["reward_0"], big,Calculate_Type.plus);
            
        BackEndDataManager.instance.Save_Quest_Data();
        Set_Val();
    }

}
