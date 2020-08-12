using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Content_Hell_Panel : MonoBehaviour
{

    Image img_Content_Hell_Boss;
    Image img_Content_Hell_Time;
    Text txt_Content_Hell_Time;
    Image img_Content_Hell_Reward_0;
    Text txt_Content_Hell_Reward_0;
    Image img_Content_Hell_Reward_1;
    Text txt_Content_Hell_Reward_1;
    Button btn_Content_Hell_In;

    Text txt_Floor;
    Image img_Lock;

    Dictionary<string, object> data;

    public void Set_Panel(int lv = 0)
    {
        data = BackEndDataManager.instance.hell_dungeon_csv_data[lv];

        img_Content_Hell_Boss = transform.Find("img_Content_Hell_Boss").GetComponent<Image>();
        img_Content_Hell_Time = transform.Find("img_Content_Hell_Time").GetComponent<Image>();
        txt_Content_Hell_Time = transform.Find("txt_Content_Hell_Time").GetComponent<Text>();
        img_Content_Hell_Reward_0 = transform.Find("img_Content_Hell_Reward_0").GetComponent<Image>();
        txt_Content_Hell_Reward_0 = transform.Find("txt_Content_Hell_Reward_0").GetComponent<Text>();
        img_Content_Hell_Reward_1 = transform.Find("img_Content_Hell_Reward_1").GetComponent<Image>();
        txt_Content_Hell_Reward_1 = transform.Find("txt_Content_Hell_Reward_1").GetComponent<Text>();
        btn_Content_Hell_In = transform.Find("btn_Content_Hell_In").GetComponent<Button>();
        txt_Floor = btn_Content_Hell_In.transform.Find("txt_Floor").GetComponent<Text>();
        img_Lock = btn_Content_Hell_In.transform.Find("img_Lock").GetComponent<Image>();


        txt_Content_Hell_Time.text = string.Format("{0:00}:{1:00}", "0", data["time"]);
        img_Content_Hell_Reward_0.sprite = Hell_.Get_Img_Reward_0();
        txt_Content_Hell_Reward_0.text = UiManager.instance.GetGoldString(Calculate.Reward((int)BackEndDataManager.instance.hell_dungeon_csv_data[0]["reward_val_0"], 120, lv));
        img_Content_Hell_Reward_1.sprite = Hell_.Get_Img_Reward_1();
        txt_Content_Hell_Reward_1.text = UiManager.instance.GetGoldString((int)BackEndDataManager.instance.hell_dungeon_csv_data[0]["reward_val_1"] * (lv + 1));

        btn_Content_Hell_In.onClick.AddListener(() => PlayManager.instance.Check_Hell(lv));

        txt_Floor.text = string.Format("{0}{1}", lv + 1, "층");

        UnLock();
    }

    public void UnLock()
    {
        int Lv = (int)data["unlock_lv"];

        Hell_info Hell_Info = BackEndDataManager.instance.Content_Data.hell_info.Find(x => x.int_num.Equals((int)data["num"]));

        txt_Floor.gameObject.SetActive(Lv <= BackEndDataManager.instance.Stage_Data.int_stage);
        btn_Content_Hell_In.interactable = Lv <= BackEndDataManager.instance.Stage_Data.int_stage;
        img_Lock.gameObject.SetActive(Lv > BackEndDataManager.instance.Stage_Data.int_stage);
    }
}
