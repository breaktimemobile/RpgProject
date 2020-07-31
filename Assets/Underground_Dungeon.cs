using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Underground_Dungeon : MonoBehaviour
{
    Text txt_Underground_Steel_Val;
    Text txt_Underground_Upgread_Stone_Val;
    Text txt_Underground_Ticket_Val;

    Button btn_Underground_In;
    Button btn_Underground_Sweep_10;
    Button btn_Underground_Sweep_1;
    Button btn_Underground_Dungeon_Close;

    Text txt_Max_Monster_Val;
    Text txt_Max_Boss_Val;
    Text txt_Boss_Percent_Val;
    Text txt_Dungeon_Time_Val;
    Text txt_Dungeon_Reward_0;
    Text txt_Dungeon_Reward_1;

    public GameObject Underground_Panel;

    private void Awake()
    {
        Find_Obj();
    }

    public void Find_Obj()
    {

        txt_Underground_Steel_Val = transform.Find("Underground_Goods/Underground_Steel/txt_Underground_Steel_Val").GetComponent<Text>();
        txt_Underground_Upgread_Stone_Val = transform.Find("Underground_Goods/Underground_Upgread_Stone/txt_Underground_Upgread_Stone_Val").GetComponent<Text>();
        txt_Underground_Ticket_Val = transform.Find("Underground_Goods/Underground_Ticket/txt_Underground_Ticket_Val").GetComponent<Text>();

        Transform Underground_Stat = transform.Find("Underground_Stat");

        btn_Underground_In = Underground_Stat.Find("btn_Underground_In").GetComponent<Button>();
        btn_Underground_Sweep_10 = Underground_Stat.Find("btn_Underground_Sweep_10").GetComponent<Button>();
        btn_Underground_Sweep_1 = Underground_Stat.Find("btn_Underground_Sweep_1").GetComponent<Button>();

        Transform img_stat_bg = Underground_Stat.Find("img_stat_bg");

        
           txt_Max_Monster_Val = img_stat_bg.Find("txt_Max_Monster_Val").GetComponent<Text>();
        txt_Max_Boss_Val = img_stat_bg.Find("txt_Max_Boss_Val").GetComponent<Text>();
        txt_Boss_Percent_Val = img_stat_bg.Find("txt_Boss_Percent_Val").GetComponent<Text>();
        txt_Dungeon_Time_Val = img_stat_bg.Find("txt_Dungeon_Time_Val").GetComponent<Text>();
        txt_Dungeon_Reward_0 = img_stat_bg.Find("txt_Dungeon_Reward_0").GetComponent<Text>();
        txt_Dungeon_Reward_1 = img_stat_bg.Find("txt_Dungeon_Reward_1").GetComponent<Text>();


        btn_Underground_Dungeon_Close = transform.Find("btn_Underground_Dungeon_Close").GetComponent<Button>();

        foreach (var item in BackEndDataManager.instance.underground_dungeon_csv_data)
        {
            Instantiate(Underground_Panel, transform
              .Find("Scroll_Underground/Viewport/Content"));

        }
    }

    public void Set_Stat_Txt(int lv)
    {

    }
}
