using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Content_Upgrade_Panel : MonoBehaviour
{
    Image img_Content_Upgrade_Boss;
    Image img_Content_Upgrade_Time;
    Text txt_Content_Upgrade_Time;
    Image img_Content_Upgrade_Monster;
    Text txt_Content_Upgrade_Monster;
    Image img_Content_Upgrade_Reward_0;
    Text txt_Content_Upgrade_Reward_0;
    Image img_Content_Upgrade_Reward_1;
    Text txt_Content_Upgrade_Reward_1;
    Button btn_Content_Upgrade_In;

    Text txt_Floor;
    Text txt_Succese;
    Image img_Lock;

    Dictionary<string, object> data;

    public void Set_Item(int lv = 0)
    {
        data = BackEndDataManager.instance.upgrade_dungeon_csv_data[lv];

        img_Content_Upgrade_Boss = transform.Find("img_Content_Upgrade_Boss").GetComponent<Image>();
        img_Content_Upgrade_Time = transform.Find("img_Content_Upgrade_Time").GetComponent<Image>();
        txt_Content_Upgrade_Time = transform.Find("txt_Content_Upgrade_Time").GetComponent<Text>();
        img_Content_Upgrade_Monster = transform.Find("img_Content_Upgrade_Monster").GetComponent<Image>();
        txt_Content_Upgrade_Monster = transform.Find("txt_Content_Upgrade_Monster").GetComponent<Text>();
        img_Content_Upgrade_Reward_0 = transform.Find("img_Content_Upgrade_Reward_0").GetComponent<Image>();
        txt_Content_Upgrade_Reward_0 = transform.Find("txt_Content_Upgrade_Reward_0").GetComponent<Text>();
        img_Content_Upgrade_Reward_1 = transform.Find("img_Content_Upgrade_Reward_1").GetComponent<Image>();
        txt_Content_Upgrade_Reward_1 = transform.Find("txt_Content_Upgrade_Reward_1").GetComponent<Text>();
        btn_Content_Upgrade_In = transform.Find("btn_Content_Upgrade_In").GetComponent<Button>();
        txt_Floor = btn_Content_Upgrade_In.transform.Find("txt_Floor").GetComponent<Text>();
        txt_Succese = btn_Content_Upgrade_In.transform.Find("txt_Succese").GetComponent<Text>();
        img_Lock = btn_Content_Upgrade_In.transform.Find("img_Lock").GetComponent<Image>();

        
        txt_Content_Upgrade_Time.text = string.Format("{0:00}:{1:00}", "0", data["time"]);
        txt_Content_Upgrade_Monster.text = data["monster_val"].ToString();
        img_Content_Upgrade_Reward_0.sprite = Upgrade_.Get_Img_Reward_0();
        txt_Content_Upgrade_Reward_0.text = UiManager.instance.GetGoldString(Calculate.Reward((int)BackEndDataManager.instance.upgrade_dungeon_csv_data[0]["reward_val_0"], 120, lv));
        img_Content_Upgrade_Reward_1.sprite = Upgrade_.Get_Img_Reward_1();
        txt_Content_Upgrade_Reward_1.text = UiManager.instance.GetGoldString(Calculate.Reward((int)BackEndDataManager.instance.upgrade_dungeon_csv_data[0]["reward_val_1"], 240, lv));

        btn_Content_Upgrade_In.onClick.AddListener(() => PlayManager.instance.Check_Upgrade(lv));

        txt_Floor.text = string.Format("{0}{1}", lv + 1, "층");
        
        UnLock();
    }

    public void UnLock()
    {
        int Lv = (int)data["unlock_lv"];

        Upgrade_info upgrade_Info = BackEndDataManager.instance.Content_Data.upgrade_info.Find(x => x.int_num.Equals((int)data["num"]));

        txt_Succese.gameObject.SetActive(upgrade_Info != null);
        txt_Floor.gameObject.SetActive(upgrade_Info == null && Lv <= BackEndDataManager.instance.Stage_Data.int_stage);

        btn_Content_Upgrade_In.interactable = upgrade_Info == null && Lv <= BackEndDataManager.instance.Stage_Data.int_stage;
        img_Lock.gameObject.SetActive(Lv > BackEndDataManager.instance.Stage_Data.int_stage);
    }
}
