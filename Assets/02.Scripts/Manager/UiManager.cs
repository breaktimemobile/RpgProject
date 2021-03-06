﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    Transform Popup;

    #region Popup

    private GameObject NickNamePopup;
    private GameObject Content_UndergroundPopup;
    private GameObject Content_UpgradePopup;
    private GameObject Content_HellPopup;
    private GameObject InventoryPopup;
    private GameObject WeaponPopup;
    public GameObject UndergroundDungeon;
    private GameObject UndergroundRewardPopup;
    public GameObject UpgradeDungeon;
    private GameObject UpgradeRewardPopup;
    public GameObject HellDungeon;
    private GameObject HellRewardPopup;
    private GameObject PetPopup;
    private GameObject ShopPopup;
    private GameObject GoodsPopup;
    private GameObject SettingPopup;
    private GameObject RepaerPopup;
    private GameObject LanguagePopup;
    private GameObject CuponPopup;
    private GameObject PowerPopup;
    private GameObject LogoutPopup;
    private GameObject MailPopup;
    private GameObject ExitPopup;
    private GameObject HelpPopup;
    private GameObject PostPopup;
    private GameObject QuestPopup;
    private GameObject QuestItemPopup;
    private GameObject GiftPopup;
    private GameObject CalendarPopup;

    #endregion

    private GameObject obj_Top;
    public GameObject obj_Stage;
    private GameObject obj_Btns;

    private GameObject obj_Content;
    private GameObject obj_Icon;

    private GameObject Content_Content;
    private GameObject Content_Character;
    private GameObject Content_Pet;
    private GameObject Content_Weapon;
    private GameObject Content_Job;
    private GameObject Content_Totem;
    private GameObject Content_Shop;

    #region obj_Top

    private Image img_Character;
    private Text txt_Lv;
    private Text txt_NickName;
    private Slider slider_Exp;

    private Image img_top_steel;
    private Image img_top_coin;
    private Image img_top_dia;

    private Text txt_Steel_Val;
    private Text txt_Coin_Val;
    private Text txt_Dia_Val;

    private Button Btn_Goods_All;

    #endregion

    #region obj_Stage

    private Text txt_State_Chapter;
    private Text txt_State_Stage;

    public Slider slider_Boss_Timer;
    public Text txt_Boss_Timer;
    public List<Button> btn_Pet = new List<Button>();

    #endregion

    #region obj_Btns

    private Button btn_Boss;
    private Button btn_Boss_Exit;
    private Button btn_Inventory;
    private Button btn_setting;

    private Image img_Skill_0;
    private Image img_Skill_0_bg;
    private Text txt_Skill_0;
    private Image img_Skill_0_lock;

    private Image img_Skill_1;
    private Image img_Skill_1_bg;
    private Text txt_Skill_1;
    private Image img_Skill_1_lock;

    private Image img_Skill_2;
    private Image img_Skill_2_bg;
    private Text txt_Skill_2;
    private Image img_Skill_2_lock;

    private Button btn_progress_reward;
    private Text txt_progress_name;
    private Text txt_progress_val;

    private Button btn_post;
    private Button btn_quest;

    private Button btn_gift;
    private Text txt_gift_time;

    private Button btn_calendar;

    #endregion

    #region Content_Content

    #endregion

    #region Content_Character

    private Button btn_State;
    private Button btn_Skill;
    private Button btn_Upgrade;
    private Button btn_Limit;

    private GameObject popup_State;
    private GameObject popup_Skill;
    private GameObject popup_Upgrade;
    private GameObject popup_Limit;


    #endregion

    #region Content_Weapon

    private Button btn_Weapon;
    private Button btn_Shield;
    private Button btn_Accessory;
    private Button btn_Costume;

    private GameObject popup_Sword;
    private GameObject popup_Shield;
    private GameObject popup_Accessory;
    private GameObject popup_Costume;

    private Weapon_Panel[] Weapon_Panels;
    private Weapon_Panel[] Shield_Panels;
    private Weapon_Panel[] Accessory_Panels;
    private Weapon_Panel[] Costume_Panels;

    #endregion

    #region Content_Pet

    private Transform scroll_pet;

    List<Pet> obj_Pets = new List<Pet>();

    #endregion

    #region  popup_State;

    private Text txt_State_Name;
    private Text txt_State_Lv;

    private Transform pos_Character;

    public Transform Spawn;
    public Transform Monster_Spawn;
    public Transform Pet_Spawn;
    public Transform Character_Spawn;

    private Button btn_Lv_1;
    private Button btn_Lv_10;
    private Button btn_Lv_100;

    private Image img_Lv_1_Coin;
    private Image img_Lv_10_Coin;
    private Image img_Lv_100_Coin;

    private Text txt_Lv_1_Val;
    private Text txt_Lv_10_Val;
    private Text txt_Lv_100_Val;

    private Text txt_State_Atk_Val;
    private Text txt_State_Hp_Val;
    private Text txt_State_Atk_Speed_Val;
    private Text txt_State_Critical_Val;
    private Text txt_State_Critical_Percent_Val;
    private Text txt_State_Speed_Val;

    #endregion

    #region popup_Skill

    List<Skill_Panel> skill_Panels = new List<Skill_Panel>();

    private Image img_Skill_Soul;

    private Button btn_Skill_Lv1;
    private Button btn_Skill_Lv10;
    private Button btn_Skill_Lv100;

    private Text txt_Skill_Soul_Val;

    #endregion

    #region popup_Upgrade

    private Image img_Upgrade_Soul_Stone;

    private Text txt_Upgrade_Soul_Stone_Val;

    private Text txt_Upgrade_title;
    private Text txt_Upgrade_Lv;
    private Text txt_Upgrade_Next_Lv;
    private Text txt_Upgrade_Percent;
    private Text txt_Upgrade_Next_Percent;

    private Button btn_Upgrade_1;
    private Button btn_Upgrade_10;
    private Button btn_Upgrade_100;

    private Image img_Upgrade_1_Soul_stone;
    private Image img_Upgrade_10_Soul_stone;
    private Image img_Upgrade_100_Soul_stone;

    private Text txt_Upgrade_1_Val;
    private Text txt_Upgrade_10_Val;
    private Text txt_Upgrade_100_Val;

    #endregion

    #region obj_Icon

    public Button btn_Icon_Content;
    public Button btn_Icon_Character;
    public Button btn_Icon_Pet;
    public Button btn_Icon_Weapon;
    public Button btn_Icon_Job;
    public Button btn_Icon_Relics;
    public Button btn_Icon_Shop;

    #endregion

    #region NickNamePopup

    private InputField Input_NickName;
    private Button btn_NickName_Ok;
    private GameObject txt_NickName_Fail;

    #endregion

    #region Content_UndergroundPopup

    Text txt_Underground_Soul_Stone_Val;
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
    Image img_Dungeon_Reward_0;
    Text txt_Dungeon_Reward_0;
    Image img_Dungeon_Reward_1;
    Text txt_Dungeon_Reward_1;

    #endregion

    #region InvantoryPopup

    private List<Inventory_Panel> Inventory_Panels = new List<Inventory_Panel>();
    private Button btn_Invantory_Close;

    #endregion

    #region WeaponPopup

    private Button btn_Weapon_Info_Popup;
    private Button btn_Weapon_Upgrade_Popup;
    private Button btn_Weapon_Mix_Popup;
    private Button btn_Weapon_Roon_Popup;
    private Button btn_Weapon_Decom_Popup;

    private GameObject content_Weapon_Info;
    private GameObject content_Weapon_Upgrade;
    private GameObject content_Weapon_Mix;
    private GameObject content_Weapon_Roon;
    private GameObject content_Weapon_Decom;

    private Button btn_Weapon_Close;

    #region content_Weapon_Info

    Text txt_Weapon_name;
    List<Button> obj_roon = new List<Button>();

    Image img_weapon_bg;
    Image img_Weapon;
    Text txt_Weapon_Grade;
    Text txt_Weapon_Lv;

    Button btn_Weapon_Limit;
    Button btn_Weapon_Mount;

    List<Text> txt_Mount_sub = new List<Text>();
    List<Text> txt_Mount_val = new List<Text>();
    List<Text> txt_Mount_limit_sub = new List<Text>();
    List<Text> txt_Mount_limit_val = new List<Text>();
    List<Text> txt_Use_sub = new List<Text>();
    List<Text> txt_Use_val = new List<Text>();
    List<Text> txt_Use_limit_sub = new List<Text>();
    List<Text> txt_Use_limit_val = new List<Text>();

    #endregion

    #region content_Weapon_Upgrade

    Text txt_Weapon_Lv_Low_Upgrade;
    Text txt_Weapon_Lv_Next_Upgrade;
    Image img_weapon_bg_Upgrade;
    Image img_Weapon_Upgrade;
    Text txt_Weapon_Grade_Upgrade;


    List<Text> txt_Mount_sub_Upgrade = new List<Text>();
    List<Text> txt_Mount_val_Upgrade = new List<Text>();
    List<Text> txt_Mount_limit_sub_Upgrade = new List<Text>();
    List<Text> txt_Mount_limit_val_Upgrade = new List<Text>();
    List<Text> txt_Use_sub_Upgrade = new List<Text>();
    List<Text> txt_Use_val_Upgrade = new List<Text>();
    List<Text> txt_Use_limit_sub_Upgrade = new List<Text>();
    List<Text> txt_Use_limit_val_Upgrade = new List<Text>();


    Image img_Upgrade_Stone;
    Text txt_My_Upgrade_Stone;
    Text txt_Upgrade_Stone;
    Button btn_Weapon_Upgrade;

    #endregion

    #region content_Weapon_Mix

    Image img_my_weapon_bg_Mix;
    Image img_my_Weapon_Mix;
    Text txt_my_Weapon_Grade_Mix;
    Text txt_my_Weapon_Lv_Mix;
    Text txt_my_Weapon_Ea_Mix;

    Image img_next_weapon_bg_Mix;
    Image img_next_Weapon_Mix;
    Text txt_next_Weapon_Grade_Mix;
    Text txt_next_Weapon_Lv_Mix;
    Text txt_next_Weapon_Ea_Mix;

    Button btn_Mix_Mius;
    Text txt_Mix_val;
    Button btn_Mix_Plus;

    Image img_Mix_Stone;
    Text txt_My_Mix_Stone;
    Text txt_Mix_Stone;

    Button btn_Mix;

    #endregion

    #region content_Weapon_Roon

    Image img_weapon_bg_roon;
    Image img_Weapon_roon;

    List<Roon> mount_roons = new List<Roon>();

    GameObject My_Roon;
    List<Roon> my_roons = new List<Roon>();
    Button btn_roon_close;

    GameObject Roon_Stat;
    Image img_select_roon;
    Text txt_select_roon_stat;
    Text txt_select_roon_stat_val;


    Button btn_roon_release;
    Button btn_roon_mount;
    Button btn_roon_stat_close;

    #endregion

    #region content_Weapon_Decom

    Button btn_Decom;
    Image img_weapon_bg_decom;
    Image img_Weapon_decom;
    Text txt_Weapon_Grade_decom;
    Text txt_Weapon_Lv_decom;
    Text txt_Weapon_Ea_decom;

    Image img_Decom_bg;
    Image img_Decom;
    Text txt_Decom_Ea_decom;

    Button btn_Decom_Mius;
    Text txt_Decom_val;
    Button btn_Decom_Plus;

    #endregion

    #endregion

    #region UndergroundDungeon

    Text txt_Underground_Time;
    Transform pos_Underground_Character;
    Transform pos_Underground_Monster;
    List<GameObject> Undergrounds = new List<GameObject>();

    Text txt_Underground_Kill_Monster;
    Text txt_Underground_Kill_Boss;
    Text txt_Underground_Reward_0;
    Text txt_Underground_Reward_1;

    Image img_Underground_Kill_Monster;
    Image img_Underground_Kill_Boss;
    Image img_Underground_Reward_0;
    Image img_Underground_Reward_1;

    #endregion

    #region UndergroundRewardPopup

    Text txt_UndergroundReward_Kill_Monster;
    Text txt_UndergroundReward_Kill_Boss;
    Text txt_UndergroundReward_Reward_0;
    Text txt_UndergroundReward_Reward_1;


    Image img_UndergroundReward_Kill_Monster;
    Image img_UndergroundReward_Kill_Boss;
    Image img_UndergroundReward_Reward_0;
    Image img_UndergroundReward_Reward_1;

    Button Btn_UndergroundReward_Ok;

    #endregion

    #region Content_UpgradePopup

    Transform Scroll_Content_Upgrade;

    Text txt_Content_Upgrade_Steel_Val;
    Text txt_Content_Upgrade_Upgread_Stone_Val;
    Text txt_Content_Upgrade_Ticket_Val;

    Button btn_Content_Upgrade_Close;

    #endregion

    #region UpgradeDungeon

    List<Content_Upgrade_Panel> content_Upgrade_s = new List<Content_Upgrade_Panel>();

    Image img_Upgrade_Reward_0;
    Text txt_Upgrade_Reward_0;
    Image img_Upgrade_Reward_1;
    Text txt_Upgrade_Reward_1;

    Text txt_Upgrade_Time;
    Transform pos_Upgrade_Character;
    Transform pos_Upgrade_Monster;

    #endregion

    #region UpgradeRewardPopup

    Text txt_UpgradeReward_Succese;
    Text txt_UpgradeReward_Fail;
    Text txt_UpgradeReward_Reward_0;
    Image img_UpgradeReward_Reward_0;
    Text txt_UpgradeReward_Reward_1;
    Image img_UpgradeReward_Reward_1;
    Button Btn_UpgradeReward_Ok;

    #endregion


    #region Content_HellPopup

    Transform Scroll_Content_Hell;

    Text txt_Content_Hell_Black_Stone_Val;
    Text txt_Content_Hell_Upgread_Stone_Val;
    Text txt_Content_Hell_Ticket_Val;

    Button btn_Content_Hell_Close;

    #endregion

    #region HellDungeon

    List<Content_Hell_Panel> content_Hell_s = new List<Content_Hell_Panel>();

    Image img_Hell_Kill_Monster;
    Text txt_Hell_Kill_Monster;

    Image img_Hell_Reward_0;
    Text txt_Hell_Reward_0;
    Image img_Hell_Reward_1;
    Text txt_Hell_Reward_1;

    Text txt_Hell_Time;
    Transform pos_Hell_Character;
    Transform pos_Hell_Monster;

    #endregion

    #region HellRewardPopup

    Image img_HellReward_Kill_Monster;
    Text txt_HellReward_Kill_Monster;
    Image img_HellReward_Reward_0;
    Text txt_HellReward_Reward_0;
    Image img_HellReward_Reward_1;
    Text txt_HellReward_Reward_1;

    Button Btn_HellReward_Ok;

    #endregion

    #region PetPopup

    List<Pet_Panel> pet_Panels = new List<Pet_Panel>();

    Button btn_Pet_Close;
    Image img_pet;

    Button btn_pet_lv_1;
    Image img_pet_lv_1;
    Text txt_pet_lv_1_val;

    Button btn_pet_lv_10;
    Image img_pet_lv_10;
    Text txt_pet_lv_10_val;

    Button btn_pet_lv_100;
    Image img_pet_lv_100;
    Text txt_pet_lv_100_val;

    Text txt_pet_name;
    Text txt_pet_name_val;
    Text txt_pet_lv_val;
    Text txt_pet_stat_sub_0;
    Text txt_pet_stat_0_val;
    Text txt_pet_stat_sub_1;
    Text txt_pet_stat_1_val;
    Button btn_pet_buy;
    Button btn_pet_spawn;
    Button btn_pet_limit;
    Image img_pet_buy;
    Text txt_pet_buy;

    #endregion

    #region Content_Job

    Transform scroll_Job;

    List<Job_Panel> job_Panels = new List<Job_Panel>();

    Button btn_Job_Lv1;
    Button btn_Job_Lv10;
    Button btn_Job_Lv100;

    #endregion

    #region Content_Totem

    Transform scroll_Totem;

    List<Totem_Panel> totem_Panels = new List<Totem_Panel>();

    Button btn_Totem_Lv1;
    Button btn_Totem_Lv10;
    Button btn_Totem_Lv100;

    #endregion

    #region ShopPopup

    private Button btn_shop_event;
    private Button btn_shop_gacha;
    private Button btn_shop_goods;
    private Button btn_shop_mileage;
    private Button btn_shop_other;

    private GameObject Content_Event;
    private GameObject Content_Gacha;
    private GameObject Content_Goods;
    private GameObject Content_Mileage;
    private GameObject Content_Other;

    private Button btn_shop_close;

    #endregion

    #region GoodsPopup

    Image img_goods_upgrade;
    Text txt_goods_upgrade;
    Button btn_goods_upgrade;

    Image img_goods_soul_stone;
    Text txt_goods_soul_stone;
    Button btn_goods_soul_stone;

    Image img_goods_black_stone;
    Text txt_goods_black_stone;
    Button btn_goods_black_stone;

    Image img_goods_steel;
    Text txt_goods_steel;
    Button btn_goods_steel;

    Image img_goods_mileage;
    Text txt_goods_mileage;
    Button btn_goods_mileage;

    Image img_goods_guild_coin;
    Text txt_goods_guild_coin;
    Button btn_goods_guild_coin;

    #endregion

    #region SettingPopup

    Button btn_setting_close;
    Button btn_setting_repaer;
    Button btn_setting_language;
    Button btn_setting_cupon;
    Button btn_setting_power;
    Button btn_setting_music;
    Text txt_setting_music_on;
    Text txt_setting_music_off;
    Button btn_setting_effect;
    Text txt_setting_effect_on;
    Text txt_setting_effect_off;
    Button btn_setting_push;
    Text txt_setting_push_on;
    Text txt_setting_push_off;
    Button btn_setting_grapic;
    Text txt_setting_grapic_on;
    Text txt_setting_grapic_off;
    Button btn_setting_google;
    Text txt_setting_google_login;
    Text txt_setting_google_logout;
    Button btn_setting_gameCenter;
    Text txt_setting_gamecenter_login;
    Text txt_setting_gamecenter_logout;
    Button btn_setting_terms;
    Button btn_setting_privacy;
    Button btn_setting_mail;
    Button btn_setting_exit;
    Button btn_setting_help;
    Button btn_setting_logout;
    Text txt_setting_version;

    #endregion


    #region RepaerPopup

    Text txt_repear_success;
    Text txt_repear_fail;
    Button btn_repaer_ok;

    #endregion

    #region LanguagePopup

    Button btn_Language_Back;
    List<Button> btn_Languages = new List<Button>();

    #endregion

    #region CuponPopup

    GameObject cupon;
    InputField input_cupon;
    Button btn_cupon_close;
    Button btn_cupon_ok;

    GameObject cupon_success;
    Button btn_cupon_success;

    GameObject cupon_fail;
    Button btn_cupon_fail;
    GameObject txt_none_fail;
    GameObject txt_overlap_fail;

    #endregion

    #region PowerPopup

    Text txt_power_time;
    Button btn_power_close;

    #endregion

    #region ExitPopup

    Button btn_exit_close;
    Button btn_exit_ok;

    #endregion

    #region HelpPopup

    Button btn_help_close;
    Button btn_help_skill;
    Button btn_help_weapon;
    Button btn_help_job;
    Button btn_help_costume;
    Button btn_help_totem;
    Button btn_help_roon;
    Button btn_help_guild;
    Button btn_help_dungeon;
    Button btn_help_quest;
    Button btn_help_pet;

    Button btn_submit_close;

    GameObject submit;

    GameObject submit_skill;
    GameObject submit_weapon;
    GameObject submit_job;
    GameObject submit_costume;
    GameObject submit_totem;
    GameObject submit_roon;
    GameObject submit_guild;
    GameObject submit_dungeon;
    GameObject submit_quest;
    GameObject submit_pet;

    #endregion

    #region PostPopup

    Transform scroll_Post;
    Button btn_Post_Close;

    #endregion

    #region QuestPopup

    Button btn_quest_close;

    Button btn_daily_quest;
    Button btn_accumulate_quest;

    Transform scroll_daily_quset;
    Transform scroll_accumulate_quest;

    Text txt_quset_time;

    #endregion

    #region QuestItemPopup

    Button btn_quest_item;
    Image img_quset_item;
    Text txt_quset_item;

    #endregion

    #region GiftPopup

    Image img_gift;
    Text txt_gift;
    Button btn_gift_ads;
    Button btn_gift_get;

    #endregion

    #region CalendarPopup

    List<Calendar_panel> calendar_Panels = new List<Calendar_panel>();
    Button btn_calendar_get;
    Button btn_calendar_close;

    #endregion


    #region Prefabs

    public GameObject txt_Damege;
    public GameObject txt_Critical_Damege;
    public GameObject weapon_Panel;
    public GameObject Inventory_Panel;
    public GameObject Skill_Panel;
    public GameObject Content_Panel;
    public GameObject Underground_Panel;
    public GameObject Content_Upgrade_Panel;
    public GameObject Content_Hell_Panel;
    public GameObject Pet_Panel;
    public GameObject pef_roon;
    public GameObject Job_Panel;
    public GameObject totem_Panel;
    public GameObject Post_Panel;
    public GameObject Quest_Panel;

    #endregion

    private int[] langeuae = new int[] { 23, 10, 22, 40, 41, 15, 21, 34, 14, 20, 28, 39, 37, 36, 30, 99999 };

    private void Awake()
    {
        instance = this;

        Find_Obj();
        AddListener();

    }

    private void Find_Obj()
    {

        Transform Game = GameObject.Find("Game").transform;
        Popup = GameObject.Find("Popup").transform;

        #region Popup

        NickNamePopup = Popup.Find("NickNamePopup").gameObject;
        Content_UndergroundPopup = Popup.Find("Content_UndergroundPopup").gameObject;
        Content_UpgradePopup = Popup.Find("Content_UpgradePopup").gameObject;
        InventoryPopup = Popup.Find("InventoryPopup").gameObject;
        WeaponPopup = Popup.Find("WeaponPopup").gameObject;
        UndergroundDungeon = Popup.Find("UndergroundDungeon").gameObject;
        UndergroundRewardPopup = Popup.Find("UndergroundRewardPopup").gameObject;
        UpgradeDungeon = Popup.Find("UpgradeDungeon").gameObject;
        UpgradeRewardPopup = Popup.Find("UpgradeRewardPopup").gameObject;
        Content_HellPopup = Popup.Find("Content_HellPopup").gameObject;
        HellDungeon = Popup.Find("HellDungeon").gameObject;
        HellRewardPopup = Popup.Find("HellRewardPopup").gameObject;
        PetPopup = Popup.Find("PetPopup").gameObject;
        ShopPopup = Popup.Find("ShopPopup").gameObject;
        GoodsPopup = Popup.Find("GoodsPopup").gameObject;
        SettingPopup = Popup.Find("SettingPopup").gameObject;
        RepaerPopup = Popup.Find("RepaerPopup").gameObject;
        LanguagePopup = Popup.Find("LanguagePopup").gameObject;
        CuponPopup = Popup.Find("CuponPopup").gameObject;
        PowerPopup = Popup.Find("PowerPopup").gameObject;
        LogoutPopup = Popup.Find("LogoutPopup").gameObject;
        MailPopup = Popup.Find("MailPopup").gameObject;
        ExitPopup = Popup.Find("ExitPopup").gameObject;
        HelpPopup = Popup.Find("HelpPopup").gameObject;
        PostPopup = Popup.Find("PostPopup").gameObject;
        QuestPopup = Popup.Find("QuestPopup").gameObject;
        QuestItemPopup = Popup.Find("QuestItemPopup").gameObject;
        GiftPopup = Popup.Find("GiftPopup").gameObject;
        CalendarPopup = Popup.Find("CalendarPopup").gameObject;

        #endregion

        obj_Top = Game.Find("obj_Top").gameObject;
        obj_Stage = Game.Find("obj_Stage").gameObject;
        obj_Btns = Game.Find("obj_Btns").gameObject;
        obj_Content = Game.Find("obj_Content").gameObject;
        obj_Icon = Game.Find("obj_Icon").gameObject;

        #region obj_Top

        img_Character = obj_Top.transform.Find("Profil/img_Character").GetComponent<Image>();
        txt_Lv = obj_Top.transform.Find("Profil/txt_Lv").GetComponent<Text>();
        txt_NickName = obj_Top.transform.Find("Profil/txt_NickName").GetComponent<Text>();
        slider_Exp = obj_Top.transform.Find("Profil/slider_Exp").GetComponent<Slider>();


        img_top_steel = obj_Top.transform.Find("Goods/Steel/img_top_steel").GetComponent<Image>();
        img_top_coin = obj_Top.transform.Find("Goods/Coin/img_top_coin").GetComponent<Image>();
        img_top_dia = obj_Top.transform.Find("Goods/Dia/img_top_dia").GetComponent<Image>();

        txt_Steel_Val = obj_Top.transform.Find("Goods/Steel/txt_Steel_Val").GetComponent<Text>();
        txt_Coin_Val = obj_Top.transform.Find("Goods/Coin/txt_Coin_Val").GetComponent<Text>();
        txt_Dia_Val = obj_Top.transform.Find("Goods/Dia/txt_Dia_Val").GetComponent<Text>();

        Btn_Goods_All = obj_Top.transform.Find("Goods/Btn_Goods_All").GetComponent<Button>();

        #endregion

        #region obj_Stage

        Spawn = obj_Stage.transform.Find("Spawn");
        Monster_Spawn = Spawn.Find("Monster_Spawn");
        Pet_Spawn = Spawn.Find("Pet_Spawn");
        Character_Spawn = Spawn.Find("Character_Spawn");

        txt_State_Chapter = obj_Stage.transform.Find("state_Stage/txt_State_Chapter").GetComponent<Text>();
        txt_State_Stage = obj_Stage.transform.Find("state_Stage/txt_State_Stage").GetComponent<Text>();

        slider_Boss_Timer = obj_Stage.transform.Find("slider_Boss_Timer").GetComponent<Slider>();
        txt_Boss_Timer = slider_Boss_Timer.transform.Find("txt_Boss_Timer").GetComponent<Text>();
        btn_Pet = obj_Stage.transform.Find("Pet").GetComponentsInChildren<Button>(true).ToList();

        #endregion

        #region obj_Btns


        btn_Boss = obj_Btns.transform.Find("btn_Boss").GetComponent<Button>();
        btn_Boss_Exit = obj_Btns.transform.Find("btn_Boss_Exit").GetComponent<Button>();
        btn_Inventory = obj_Btns.transform.Find("btn_Inventory").GetComponent<Button>();
        btn_setting = obj_Btns.transform.Find("btn_setting").GetComponent<Button>();

        img_Skill_0 = obj_Btns.transform.Find("img_Skill_0").GetComponent<Image>();
        img_Skill_0_bg = img_Skill_0.transform.Find("img_Skill_0_bg").GetComponent<Image>();
        txt_Skill_0 = img_Skill_0.transform.Find("txt_Skill_0").GetComponent<Text>();
        img_Skill_0_lock = img_Skill_0.transform.Find("img_Skill_0_lock").GetComponent<Image>();

        img_Skill_1 = obj_Btns.transform.Find("img_Skill_1").GetComponent<Image>();
        img_Skill_1_bg = img_Skill_1.transform.Find("img_Skill_1_bg").GetComponent<Image>();
        txt_Skill_1 = img_Skill_1.transform.Find("txt_Skill_1").GetComponent<Text>();
        img_Skill_1_lock = img_Skill_1.transform.Find("img_Skill_1_lock").GetComponent<Image>();


        img_Skill_2 = obj_Btns.transform.Find("img_Skill_2").GetComponent<Image>();
        img_Skill_2_bg = img_Skill_2.transform.Find("img_Skill_2_bg").GetComponent<Image>();
        txt_Skill_2 = img_Skill_2.transform.Find("txt_Skill_2").GetComponent<Text>();
        img_Skill_2_lock = img_Skill_2.transform.Find("img_Skill_2_lock").GetComponent<Image>();

        btn_progress_reward = obj_Btns.transform.Find("btn_progress_reward").GetComponent<Button>();
        txt_progress_name = btn_progress_reward.transform.Find("txt_progress_name").GetComponent<Text>();
        txt_progress_val = btn_progress_reward.transform.Find("txt_progress_val").GetComponent<Text>();

        btn_post = obj_Btns.transform.Find("btn_post").GetComponent<Button>();

        btn_quest = obj_Btns.transform.Find("btn_quest").GetComponent<Button>();

        btn_gift = obj_Btns.transform.Find("btn_gift").GetComponent<Button>();
        txt_gift_time = btn_gift.transform.Find("txt_gift_time").GetComponent<Text>();

        btn_calendar = obj_Btns.transform.Find("btn_calendar").GetComponent<Button>();

        #endregion

        #region obj_Content

        Content_Content = obj_Content.transform.Find("Content_Content").gameObject;
        Content_Character = obj_Content.transform.Find("Content_Character").gameObject;
        Content_Pet = obj_Content.transform.Find("Content_Pet").gameObject;
        Content_Weapon = obj_Content.transform.Find("Content_Weapon").gameObject;
        Content_Job = obj_Content.transform.Find("Content_Job").gameObject;
        Content_Totem = obj_Content.transform.Find("Content_Totem").gameObject;
        Content_Shop = obj_Content.transform.Find("Content_Shop").gameObject;

        #endregion

        #region Content_Character

        btn_State = Content_Character.transform.Find("grid_Btn/btn_State").GetComponent<Button>();
        btn_Skill = Content_Character.transform.Find("grid_Btn/btn_Skill").GetComponent<Button>();
        btn_Upgrade = Content_Character.transform.Find("grid_Btn/btn_Upgrade").GetComponent<Button>();
        btn_Limit = Content_Character.transform.Find("grid_Btn/btn_Limit").GetComponent<Button>();

        popup_State = Content_Character.transform.Find("contents/popup_State").gameObject;
        popup_Skill = Content_Character.transform.Find("contents/popup_Skill").gameObject;
        popup_Upgrade = Content_Character.transform.Find("contents/popup_Upgrade").gameObject;
        popup_Limit = Content_Character.transform.Find("contents/popup_Limit").gameObject;

        #endregion

        #region Content_Weapon

        btn_Weapon = Content_Weapon.transform.Find("grid_Btn/btn_Weapon").GetComponent<Button>();
        btn_Shield = Content_Weapon.transform.Find("grid_Btn/btn_Shield").GetComponent<Button>();
        btn_Accessory = Content_Weapon.transform.Find("grid_Btn/btn_Accessory").GetComponent<Button>();
        btn_Costume = Content_Weapon.transform.Find("grid_Btn/btn_Costume").GetComponent<Button>();

        popup_Sword = Content_Weapon.transform.Find("contents/popup_Sword").gameObject;
        popup_Shield = Content_Weapon.transform.Find("contents/popup_Shield").gameObject;
        popup_Accessory = Content_Weapon.transform.Find("contents/popup_Accessory").gameObject;
        popup_Costume = Content_Weapon.transform.Find("contents/popup_Costume").gameObject;

        Weapon_Panels = popup_Sword.GetComponentsInChildren<Weapon_Panel>();


        #endregion

        #region Content_Pet

        scroll_pet = Content_Pet.transform.Find("scroll_pet");


        #endregion

        #region obj_Icon

        btn_Icon_Content = obj_Icon.transform.Find("grid_Icon/btn_Icon_Content").GetComponent<Button>();
        btn_Icon_Character = obj_Icon.transform.Find("grid_Icon/btn_Icon_Character").GetComponent<Button>();
        btn_Icon_Pet = obj_Icon.transform.Find("grid_Icon/btn_Icon_Pet").GetComponent<Button>();
        btn_Icon_Weapon = obj_Icon.transform.Find("grid_Icon/btn_Icon_Weapon").GetComponent<Button>();
        btn_Icon_Job = obj_Icon.transform.Find("grid_Icon/btn_Icon_Job").GetComponent<Button>();
        btn_Icon_Relics = obj_Icon.transform.Find("grid_Icon/btn_Icon_Relics").GetComponent<Button>();
        btn_Icon_Shop = obj_Icon.transform.Find("grid_Icon/btn_Icon_Shop").GetComponent<Button>();

        #endregion

        #region  popup_State

        pos_Character = popup_State.transform.Find("img_Chatacter_Bg/pos_Character");

        txt_State_Name = popup_State.transform.Find("img_State_Bg/txt_State_Name").GetComponent<Text>();
        txt_State_Lv = popup_State.transform.Find("img_State_Bg/txt_State_Lv").GetComponent<Text>();

        btn_Lv_1 = popup_State.transform.Find("lv_Ups/btn_Lv_1").GetComponent<Button>();
        btn_Lv_10 = popup_State.transform.Find("lv_Ups/btn_Lv_10").GetComponent<Button>();
        btn_Lv_100 = popup_State.transform.Find("lv_Ups/btn_Lv_100").GetComponent<Button>();

        img_Lv_1_Coin = btn_Lv_1.transform.Find("img_Lv_1_Coin").GetComponent<Image>();
        img_Lv_10_Coin = btn_Lv_10.transform.Find("img_Lv_10_Coin").GetComponent<Image>();
        img_Lv_100_Coin = btn_Lv_100.transform.Find("img_Lv_100_Coin").GetComponent<Image>();

        txt_Lv_1_Val = btn_Lv_1.transform.Find("txt_Lv_1_Val").GetComponent<Text>();
        txt_Lv_10_Val = btn_Lv_10.transform.Find("txt_Lv_10_Val").GetComponent<Text>();
        txt_Lv_100_Val = btn_Lv_100.transform.Find("txt_Lv_100_Val").GetComponent<Text>();

        txt_State_Atk_Val = popup_State.transform.Find("states/state_Atk/txt_State_Atk_Val").GetComponent<Text>();
        txt_State_Hp_Val = popup_State.transform.Find("states/state_Hp/txt_State_Hp_Val").GetComponent<Text>();
        txt_State_Atk_Speed_Val = popup_State.transform.Find("states/state_Atk_Speed/txt_State_Atk_Speed_Val").GetComponent<Text>();
        txt_State_Critical_Val = popup_State.transform.Find("states/state_Critical/txt_State_Critical_Val").GetComponent<Text>();
        txt_State_Critical_Percent_Val = popup_State.transform.Find("states/state_Critical_Percent/txt_State_Critical_Percent_Val").GetComponent<Text>();
        txt_State_Speed_Val = popup_State.transform.Find("states/state_Speed/txt_State_Speed_Val").GetComponent<Text>();

        #endregion

        #region popup_Skill

        img_Skill_Soul = popup_Skill.transform.Find("Soul_stone/img_Skill_Soul").GetComponent<Image>();

        btn_Skill_Lv1 = popup_Skill.transform.Find("btn_Skill_Lv1").GetComponent<Button>();
        btn_Skill_Lv10 = popup_Skill.transform.Find("btn_Skill_Lv10").GetComponent<Button>();
        btn_Skill_Lv100 = popup_Skill.transform.Find("btn_Skill_Lv100").GetComponent<Button>();

        txt_Skill_Soul_Val = popup_Skill.transform.Find("Soul_stone/txt_Skill_Soul_Val").GetComponent<Text>();

        #endregion

        #region popup_Upgrade

        img_Upgrade_Soul_Stone = popup_Upgrade.transform.Find("Soul_Stone/img_Upgrade_Soul_Stone").GetComponent<Image>();

        txt_Upgrade_Soul_Stone_Val = popup_Upgrade.transform.Find("Soul_Stone/txt_Upgrade_Soul_Stone_Val").GetComponent<Text>();

        txt_Upgrade_title = popup_Upgrade.transform.Find("Upgrade_State/txt_Upgrade_title").GetComponent<Text>();
        txt_Upgrade_Lv = popup_Upgrade.transform.Find("Upgrade_State/txt_Upgrade_Lv").GetComponent<Text>();
        txt_Upgrade_Next_Lv = popup_Upgrade.transform.Find("Upgrade_State/txt_Upgrade_Next_Lv").GetComponent<Text>();
        txt_Upgrade_Percent = popup_Upgrade.transform.Find("Upgrade_State/txt_Upgrade_Percent").GetComponent<Text>();
        txt_Upgrade_Next_Percent = popup_Upgrade.transform.Find("Upgrade_State/txt_Upgrade_Next_Percent").GetComponent<Text>();

        btn_Upgrade_1 = popup_Upgrade.transform.Find("Upgrade_Btn/btn_Upgrade_1").GetComponent<Button>();
        btn_Upgrade_10 = popup_Upgrade.transform.Find("Upgrade_Btn/btn_Upgrade_10").GetComponent<Button>();
        btn_Upgrade_100 = popup_Upgrade.transform.Find("Upgrade_Btn/btn_Upgrade_100").GetComponent<Button>();


        img_Upgrade_1_Soul_stone = btn_Upgrade_1.transform.Find("img_Upgrade_1_Soul_stone").GetComponent<Image>();
        img_Upgrade_10_Soul_stone = btn_Upgrade_10.transform.Find("img_Upgrade_10_Soul_stone").GetComponent<Image>();
        img_Upgrade_100_Soul_stone = btn_Upgrade_100.transform.Find("img_Upgrade_100_Soul_stone").GetComponent<Image>();


        txt_Upgrade_1_Val = btn_Upgrade_1.transform.Find("txt_Upgrade_1_Val").GetComponent<Text>();
        txt_Upgrade_10_Val = btn_Upgrade_10.transform.Find("txt_Upgrade_10_Val").GetComponent<Text>();
        txt_Upgrade_100_Val = btn_Upgrade_100.transform.Find("txt_Upgrade_100_Val").GetComponent<Text>();

        #endregion

        #region NickNamePopup

        Input_NickName = NickNamePopup.transform.Find("Input_NickName").GetComponent<InputField>();

        btn_NickName_Ok = NickNamePopup.transform.Find("btn_NickName_Ok").GetComponent<Button>();
        txt_NickName_Fail = NickNamePopup.transform.Find("txt_NickName_Fail").gameObject;

        #endregion

        #region InvantoryPopup

        btn_Invantory_Close = InventoryPopup.transform.Find("btn_Invantory_Close").GetComponent<Button>();


        #endregion

        #region WeaponPopup

        btn_Weapon_Info_Popup = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info_Popup").GetComponent<Button>();
        btn_Weapon_Upgrade_Popup = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Upgrade_Popup").GetComponent<Button>();
        btn_Weapon_Mix_Popup = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Mix_Popup").GetComponent<Button>();
        btn_Weapon_Roon_Popup = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Roon_Popup").GetComponent<Button>();
        btn_Weapon_Decom_Popup = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Decom_Popup").GetComponent<Button>();

        content_Weapon_Info = WeaponPopup.transform.Find("contents/content_Weapon_Info").gameObject;
        content_Weapon_Upgrade = WeaponPopup.transform.Find("contents/content_Weapon_Upgrade").gameObject;
        content_Weapon_Mix = WeaponPopup.transform.Find("contents/content_Weapon_Mix").gameObject;
        content_Weapon_Roon = WeaponPopup.transform.Find("contents/content_Weapon_Roon").gameObject;
        content_Weapon_Decom = WeaponPopup.transform.Find("contents/content_Weapon_Decom").gameObject;

        btn_Weapon_Close = WeaponPopup.transform.Find("btn_Weapon_Close").GetComponent<Button>();

        #region content_Weapon_Info

        txt_Weapon_name = content_Weapon_Info.transform.Find("txt_Weapon_name").GetComponent<Text>();
        obj_roon = content_Weapon_Info.transform.Find("obj_roon").GetComponentsInChildren<Button>(true).ToList();

        img_weapon_bg = content_Weapon_Info.transform.Find("img_weapon_bg").GetComponent<Image>();
        img_Weapon = img_weapon_bg.transform.Find("img_Weapon").GetComponent<Image>();
        txt_Weapon_Grade = img_weapon_bg.transform.Find("txt_Weapon_Grade").GetComponent<Text>();
        txt_Weapon_Lv = img_weapon_bg.transform.Find("txt_Weapon_Lv").GetComponent<Text>();

        btn_Weapon_Limit = content_Weapon_Info.transform.Find("btn_Weapon_Limit").GetComponent<Button>();
        btn_Weapon_Mount = content_Weapon_Info.transform.Find("btn_Weapon_Mount").GetComponent<Button>();

        txt_Mount_sub = content_Weapon_Info.transform.Find("Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_sub.RemoveAll(x => !x.name.Contains("sub"));
        txt_Mount_val = content_Weapon_Info.transform.Find("Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_val.RemoveAll(x => !x.name.Contains("val"));

        txt_Mount_limit_sub = content_Weapon_Info.transform.Find("Limit_Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_limit_sub.RemoveAll(x => !x.name.Contains("limit_sub"));
        txt_Mount_limit_val = content_Weapon_Info.transform.Find("Limit_Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_limit_val.RemoveAll(x => !x.name.Contains("limit_val"));

        txt_Use_sub = content_Weapon_Info.transform.Find("Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_sub.RemoveAll(x => !x.name.Contains("sub"));
        txt_Use_val = content_Weapon_Info.transform.Find("Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_val.RemoveAll(x => !x.name.Contains("val"));

        txt_Use_limit_sub = content_Weapon_Info.transform.Find("Limit_Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_limit_sub.RemoveAll(x => !x.name.Contains("limit_sub"));
        txt_Use_limit_val = content_Weapon_Info.transform.Find("Limit_Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_limit_val.RemoveAll(x => !x.name.Contains("limit_val"));

        #endregion

        #region content_Weapon_Upgrade

        txt_Weapon_Lv_Low_Upgrade = content_Weapon_Upgrade.transform.Find("Lv/txt_Weapon_Lv_Low_Upgrade").GetComponent<Text>();
        txt_Weapon_Lv_Next_Upgrade = content_Weapon_Upgrade.transform.Find("Lv/txt_Weapon_Lv_Next_Upgrade").GetComponent<Text>();
        img_weapon_bg_Upgrade = content_Weapon_Upgrade.transform.Find("img_weapon_bg_Upgrade").GetComponent<Image>();
        img_Weapon_Upgrade = img_weapon_bg_Upgrade.transform.Find("img_Weapon_Upgrade").GetComponent<Image>();
        txt_Weapon_Grade_Upgrade = img_weapon_bg_Upgrade.transform.Find("txt_Weapon_Grade_Upgrade").GetComponent<Text>();

        txt_Mount_sub_Upgrade = content_Weapon_Upgrade.transform.Find("Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_sub_Upgrade.RemoveAll(x => !x.name.Contains("sub"));
        txt_Mount_val_Upgrade = content_Weapon_Upgrade.transform.Find("Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_val_Upgrade.RemoveAll(x => !x.name.Contains("val"));

        txt_Mount_limit_sub_Upgrade = content_Weapon_Upgrade.transform.Find("Limit_Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_limit_sub_Upgrade.RemoveAll(x => !x.name.Contains("limit_sub"));
        txt_Mount_limit_val_Upgrade = content_Weapon_Upgrade.transform.Find("Limit_Mount").GetComponentsInChildren<Text>(true).ToList();
        txt_Mount_limit_val_Upgrade.RemoveAll(x => !x.name.Contains("limit_val"));

        txt_Use_sub_Upgrade = content_Weapon_Upgrade.transform.Find("Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_sub_Upgrade.RemoveAll(x => !x.name.Contains("sub"));
        txt_Use_val_Upgrade = content_Weapon_Upgrade.transform.Find("Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_val_Upgrade.RemoveAll(x => !x.name.Contains("val"));

        txt_Use_limit_sub_Upgrade = content_Weapon_Upgrade.transform.Find("Limit_Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_limit_sub_Upgrade.RemoveAll(x => !x.name.Contains("limit_sub"));
        txt_Use_limit_val_Upgrade = content_Weapon_Upgrade.transform.Find("Limit_Use").GetComponentsInChildren<Text>(true).ToList();
        txt_Use_limit_val_Upgrade.RemoveAll(x => !x.name.Contains("limit_val"));

        img_Upgrade_Stone = content_Weapon_Upgrade.transform.Find("Obj_Upgrade/img_Upgrade_Stone").GetComponent<Image>();
        txt_My_Upgrade_Stone = content_Weapon_Upgrade.transform.Find("Obj_Upgrade/txt_My_Upgrade_Stone").GetComponent<Text>();
        txt_Upgrade_Stone = content_Weapon_Upgrade.transform.Find("Obj_Upgrade/txt_Upgrade_Stone").GetComponent<Text>();
        btn_Weapon_Upgrade = content_Weapon_Upgrade.transform.Find("Obj_Upgrade/btn_Weapon_Upgrade").GetComponent<Button>();

        #endregion

        #region content_Weapon_Mix

        img_my_weapon_bg_Mix = content_Weapon_Mix.transform.Find("img_my_weapon_bg_Mix").GetComponent<Image>();
        img_my_Weapon_Mix = img_my_weapon_bg_Mix.transform.Find("img_my_Weapon_Mix").GetComponent<Image>();
        txt_my_Weapon_Grade_Mix = img_my_weapon_bg_Mix.transform.Find("txt_my_Weapon_Grade_Mix").GetComponent<Text>();
        txt_my_Weapon_Lv_Mix = img_my_weapon_bg_Mix.transform.Find("txt_my_Weapon_Lv_Mix").GetComponent<Text>();
        txt_my_Weapon_Ea_Mix = img_my_weapon_bg_Mix.transform.Find("txt_my_Weapon_Ea_Mix").GetComponent<Text>();

        img_next_weapon_bg_Mix = content_Weapon_Mix.transform.Find("img_next_weapon_bg_Mix").GetComponent<Image>();
        img_next_Weapon_Mix = img_next_weapon_bg_Mix.transform.Find("img_next_Weapon_Mix").GetComponent<Image>();
        txt_next_Weapon_Grade_Mix = img_next_weapon_bg_Mix.transform.Find("txt_next_Weapon_Grade_Mix").GetComponent<Text>();
        txt_next_Weapon_Lv_Mix = img_next_weapon_bg_Mix.transform.Find("txt_next_Weapon_Lv_Mix").GetComponent<Text>();
        txt_next_Weapon_Ea_Mix = img_next_weapon_bg_Mix.transform.Find("txt_next_Weapon_Ea_Mix").GetComponent<Text>();

        btn_Mix_Mius = content_Weapon_Mix.transform.Find("btn_Mix_Mius").GetComponent<Button>();
        txt_Mix_val = content_Weapon_Mix.transform.Find("txt_Mix_val").GetComponent<Text>();
        btn_Mix_Plus = content_Weapon_Mix.transform.Find("btn_Mix_Plus").GetComponent<Button>();

        img_Mix_Stone = content_Weapon_Mix.transform.Find("Obj_Mix/img_Mix_Stone").GetComponent<Image>();
        txt_My_Mix_Stone = content_Weapon_Mix.transform.Find("Obj_Mix/txt_My_Mix_Stone").GetComponent<Text>();
        txt_Mix_Stone = content_Weapon_Mix.transform.Find("Obj_Mix/txt_Mix_Stone").GetComponent<Text>();

        btn_Mix = content_Weapon_Mix.transform.Find("Obj_Mix/btn_Mix").GetComponent<Button>();

        #endregion

        #region content_Weapon_Roon

        img_weapon_bg_roon = content_Weapon_Roon.transform.Find("img_weapon_bg_roon").GetComponent<Image>();
        img_Weapon_roon = img_weapon_bg_roon.transform.Find("img_Weapon_roon").GetComponent<Image>();

        mount_roons = content_Weapon_Roon.transform.Find("obj_roon").GetComponentsInChildren<Roon>(true).ToList();

        My_Roon = content_Weapon_Roon.transform.Find("My_Roon").gameObject;

        btn_roon_close = My_Roon.transform.Find("btn_roon_close").GetComponent<Button>();

        Roon_Stat = content_Weapon_Roon.transform.Find("Roon_Stat").gameObject;

        img_select_roon = Roon_Stat.transform.Find("img_select_roon").GetComponent<Image>();
        txt_select_roon_stat = Roon_Stat.transform.Find("txt_select_roon_stat").GetComponent<Text>();
        txt_select_roon_stat_val = Roon_Stat.transform.Find("txt_select_roon_stat_val").GetComponent<Text>();
        btn_roon_release = Roon_Stat.transform.Find("btn_roon_release").GetComponent<Button>();
        btn_roon_mount = Roon_Stat.transform.Find("btn_roon_mount").GetComponent<Button>();
        btn_roon_stat_close = Roon_Stat.transform.Find("btn_roon_stat_close").GetComponent<Button>();

        #endregion

        #region content_Weapon_Decom

        btn_Decom = content_Weapon_Decom.transform.Find("btn_Decom").GetComponent<Button>();

        img_weapon_bg_decom = content_Weapon_Decom.transform.Find("img_weapon_bg_decom").GetComponent<Image>();
        img_Weapon_decom = img_weapon_bg_decom.transform.Find("img_Weapon_decom").GetComponent<Image>();
        txt_Weapon_Grade_decom = img_weapon_bg_decom.transform.Find("txt_Weapon_Grade_decom").GetComponent<Text>();
        txt_Weapon_Lv_decom = img_weapon_bg_decom.transform.Find("txt_Weapon_Lv_decom").GetComponent<Text>();
        txt_Weapon_Ea_decom = img_weapon_bg_decom.transform.Find("txt_Weapon_Ea_decom").GetComponent<Text>();

        img_Decom_bg = content_Weapon_Decom.transform.Find("img_Decom_bg").GetComponent<Image>();
        img_Decom = img_Decom_bg.transform.Find("img_Decom").GetComponent<Image>();
        txt_Decom_Ea_decom = img_Decom_bg.transform.Find("txt_Decom_Ea_decom").GetComponent<Text>();

        btn_Decom_Mius = content_Weapon_Decom.transform.Find("btn_Decom_Mius").GetComponent<Button>();
        txt_Decom_val = content_Weapon_Decom.transform.Find("txt_Decom_val").GetComponent<Text>();
        btn_Decom_Plus = content_Weapon_Decom.transform.Find("btn_Decom_Plus").GetComponent<Button>();

        #endregion

        #endregion

        #region UndergroundPopup

        txt_Underground_Soul_Stone_Val = Content_UndergroundPopup.transform.Find("Underground_Goods/Underground_Soul_Stone/txt_Underground_Soul_Stone_Val").GetComponent<Text>();
        txt_Underground_Upgread_Stone_Val = Content_UndergroundPopup.transform.Find("Underground_Goods/Underground_Upgread_Stone/txt_Underground_Upgread_Stone_Val").GetComponent<Text>();
        txt_Underground_Ticket_Val = Content_UndergroundPopup.transform.Find("Underground_Goods/Underground_Ticket/txt_Underground_Ticket_Val").GetComponent<Text>();

        Transform Underground_Stat = Content_UndergroundPopup.transform.Find("Underground_Stat");

        btn_Underground_In = Underground_Stat.Find("btn_Underground_In").GetComponent<Button>();
        btn_Underground_Sweep_10 = Underground_Stat.Find("btn_Underground_Sweep_10").GetComponent<Button>();
        btn_Underground_Sweep_1 = Underground_Stat.Find("btn_Underground_Sweep_1").GetComponent<Button>();

        Transform img_stat_bg = Underground_Stat.Find("img_stat_bg");

        txt_Max_Monster_Val = img_stat_bg.Find("txt_Max_Monster_Val").GetComponent<Text>();
        txt_Max_Boss_Val = img_stat_bg.Find("txt_Max_Boss_Val").GetComponent<Text>();
        txt_Boss_Percent_Val = img_stat_bg.Find("txt_Boss_Percent_Val").GetComponent<Text>();
        txt_Dungeon_Time_Val = img_stat_bg.Find("txt_Dungeon_Time_Val").GetComponent<Text>();
        img_Dungeon_Reward_0 = img_stat_bg.Find("img_Dungeon_Reward_0").GetComponent<Image>();
        txt_Dungeon_Reward_0 = img_stat_bg.Find("txt_Dungeon_Reward_0").GetComponent<Text>();
        img_Dungeon_Reward_1 = img_stat_bg.Find("img_Dungeon_Reward_1").GetComponent<Image>();
        txt_Dungeon_Reward_1 = img_stat_bg.Find("txt_Dungeon_Reward_1").GetComponent<Text>();


        btn_Underground_Dungeon_Close = Content_UndergroundPopup.transform.Find("btn_Underground_Dungeon_Close").GetComponent<Button>();

        #endregion

        #region UndergroundDungeon

        txt_Underground_Time = UndergroundDungeon.transform.Find("txt_Underground_Time").GetComponent<Text>();
        Transform pos_Underground_Character = UndergroundDungeon.transform.Find("pos_Underground_Character");
        Transform pos_Underground_Monster = UndergroundDungeon.transform.Find("pos_Underground_Monster");

        txt_Underground_Kill_Monster = UndergroundDungeon.transform.Find("obj_Underground/txt_Underground_Kill_Monster").GetComponent<Text>();
        txt_Underground_Kill_Boss = UndergroundDungeon.transform.Find("obj_Underground/txt_Underground_Kill_Boss").GetComponent<Text>();
        txt_Underground_Reward_0 = UndergroundDungeon.transform.Find("obj_Underground/txt_Underground_Reward_0").GetComponent<Text>();
        txt_Underground_Reward_1 = UndergroundDungeon.transform.Find("obj_Underground/txt_Underground_Reward_1").GetComponent<Text>();

        img_Underground_Kill_Monster = UndergroundDungeon.transform.Find("obj_Underground/img_Underground_Kill_Monster").GetComponent<Image>();
        img_Underground_Kill_Boss = UndergroundDungeon.transform.Find("obj_Underground/img_Underground_Kill_Boss").GetComponent<Image>();
        img_Underground_Reward_0 = UndergroundDungeon.transform.Find("obj_Underground/img_Underground_Reward_0").GetComponent<Image>();
        img_Underground_Reward_1 = UndergroundDungeon.transform.Find("obj_Underground/img_Underground_Reward_1").GetComponent<Image>();


        #endregion

        #region UndergroundRewardPopup

        txt_UndergroundReward_Kill_Monster = UndergroundRewardPopup.transform.Find("txt_UndergroundReward_Kill_Monster").GetComponent<Text>();
        txt_UndergroundReward_Kill_Boss = UndergroundRewardPopup.transform.Find("txt_UndergroundReward_Kill_Boss").GetComponent<Text>();
        txt_UndergroundReward_Reward_0 = UndergroundRewardPopup.transform.Find("txt_UndergroundReward_Reward_0").GetComponent<Text>();
        txt_UndergroundReward_Reward_1 = UndergroundRewardPopup.transform.Find("txt_UndergroundReward_Reward_1").GetComponent<Text>();

        img_UndergroundReward_Kill_Monster = UndergroundRewardPopup.transform.Find("img_UndergroundReward_Kill_Monster").GetComponent<Image>();
        img_UndergroundReward_Kill_Boss = UndergroundRewardPopup.transform.Find("img_UndergroundReward_Kill_Boss").GetComponent<Image>();
        img_UndergroundReward_Reward_0 = UndergroundRewardPopup.transform.Find("img_UndergroundReward_Reward_0").GetComponent<Image>();
        img_UndergroundReward_Reward_1 = UndergroundRewardPopup.transform.Find("img_UndergroundReward_Reward_1").GetComponent<Image>();

        Btn_UndergroundReward_Ok = UndergroundRewardPopup.transform.Find("Btn_UndergroundReward_Ok").GetComponent<Button>();

        #endregion

        #region Content_UpgradePopup

        Scroll_Content_Upgrade = Content_UpgradePopup.transform.Find("Scroll_Content_Upgrade");

        txt_Content_Upgrade_Steel_Val = Content_UpgradePopup.transform.Find("Content_Upgrade_Goods/Content_Upgrade_Steel/txt_Content_Upgrade_Steel_Val").GetComponent<Text>();
        txt_Content_Upgrade_Upgread_Stone_Val = Content_UpgradePopup.transform.Find("Content_Upgrade_Goods/Content_Upgrade_Upgread_Stone/txt_Content_Upgrade_Upgread_Stone_Val").GetComponent<Text>();
        txt_Content_Upgrade_Ticket_Val = Content_UpgradePopup.transform.Find("Content_Upgrade_Goods/Content_Upgrade_Ticket/txt_Content_Upgrade_Ticket_Val").GetComponent<Text>();

        btn_Content_Upgrade_Close = Content_UpgradePopup.transform.Find("btn_Content_Upgrade_Close").GetComponent<Button>();

        #endregion

        #region UpgradeDungeon

        img_Upgrade_Reward_0 = UpgradeDungeon.transform.Find("obj_Upgrade/img_Upgrade_Reward_0").GetComponent<Image>();
        txt_Upgrade_Reward_0 = UpgradeDungeon.transform.Find("obj_Upgrade/txt_Upgrade_Reward_0").GetComponent<Text>();
        img_Upgrade_Reward_1 = UpgradeDungeon.transform.Find("obj_Upgrade/img_Upgrade_Reward_1").GetComponent<Image>();
        txt_Upgrade_Reward_1 = UpgradeDungeon.transform.Find("obj_Upgrade/txt_Upgrade_Reward_1").GetComponent<Text>();

        txt_Upgrade_Time = UpgradeDungeon.transform.Find("txt_Upgrade_Time").GetComponent<Text>();
        pos_Upgrade_Character = UpgradeDungeon.transform.Find("pos_Upgrade_Character");
        pos_Upgrade_Monster = UpgradeDungeon.transform.Find("pos_Upgrade_Monster");

        #endregion

        #region UpgradeRewardPopup

        txt_UpgradeReward_Succese = UpgradeRewardPopup.transform.Find("img_Title_Bg/txt_UpgradeReward_Succese").GetComponent<Text>();
        txt_UpgradeReward_Fail = UpgradeRewardPopup.transform.Find("img_Title_Bg/txt_UpgradeReward_Fail").GetComponent<Text>();
        txt_UpgradeReward_Reward_0 = UpgradeRewardPopup.transform.Find("txt_UpgradeReward_Reward_0").GetComponent<Text>();
        img_UpgradeReward_Reward_0 = UpgradeRewardPopup.transform.Find("img_UpgradeReward_Reward_0").GetComponent<Image>();
        txt_UpgradeReward_Reward_1 = UpgradeRewardPopup.transform.Find("txt_UpgradeReward_Reward_1").GetComponent<Text>();
        img_UpgradeReward_Reward_1 = UpgradeRewardPopup.transform.Find("img_UpgradeReward_Reward_1").GetComponent<Image>();

        Btn_UpgradeReward_Ok = UpgradeRewardPopup.transform.Find("Btn_UpgradeReward_Ok").GetComponent<Button>();

        #endregion

        #region Content_HellPopup

        Scroll_Content_Hell = Content_HellPopup.transform.Find("Scroll_Content_Hell");

        txt_Content_Hell_Black_Stone_Val = Content_HellPopup.transform.Find("Content_Hell_Goods/Content_Hell_Black_Stone/txt_Content_Hell_Black_Stone_Val").GetComponent<Text>();
        txt_Content_Hell_Upgread_Stone_Val = Content_HellPopup.transform.Find("Content_Hell_Goods/Content_Hell_Upgread_Stone/txt_Content_Hell_Upgread_Stone_Val").GetComponent<Text>();
        txt_Content_Hell_Ticket_Val = Content_HellPopup.transform.Find("Content_Hell_Goods/Content_Hell_Ticket/txt_Content_Hell_Ticket_Val").GetComponent<Text>();

        btn_Content_Hell_Close = Content_HellPopup.transform.Find("btn_Content_Hell_Close").GetComponent<Button>();

        #endregion

        #region HellDungeon

        img_Hell_Kill_Monster = HellDungeon.transform.Find("obj_Hell/img_Hell_Kill_Monster").GetComponent<Image>();
        txt_Hell_Kill_Monster = HellDungeon.transform.Find("obj_Hell/txt_Hell_Kill_Monster").GetComponent<Text>();

        img_Hell_Reward_0 = HellDungeon.transform.Find("obj_Hell/img_Hell_Reward_0").GetComponent<Image>();
        txt_Hell_Reward_0 = HellDungeon.transform.Find("obj_Hell/txt_Hell_Reward_0").GetComponent<Text>();
        img_Hell_Reward_1 = HellDungeon.transform.Find("obj_Hell/img_Hell_Reward_1").GetComponent<Image>();
        txt_Hell_Reward_1 = HellDungeon.transform.Find("obj_Hell/txt_Hell_Reward_1").GetComponent<Text>();

        txt_Hell_Time = HellDungeon.transform.Find("txt_Hell_Time").GetComponent<Text>();
        pos_Hell_Character = HellDungeon.transform.Find("pos_Hell_Character");
        pos_Hell_Monster = HellDungeon.transform.Find("pos_Hell_Monster");

        #endregion

        #region HellRewardPopup

        img_HellReward_Kill_Monster = HellRewardPopup.transform.Find("img_HellReward_Kill_Monster").GetComponent<Image>();
        txt_HellReward_Kill_Monster = HellRewardPopup.transform.Find("txt_HellReward_Kill_Monster").GetComponent<Text>();
        img_HellReward_Reward_0 = HellRewardPopup.transform.Find("img_HellReward_Reward_0").GetComponent<Image>();
        txt_HellReward_Reward_0 = HellRewardPopup.transform.Find("txt_HellReward_Reward_0").GetComponent<Text>();
        img_HellReward_Reward_1 = HellRewardPopup.transform.Find("img_HellReward_Reward_1").GetComponent<Image>();
        txt_HellReward_Reward_1 = HellRewardPopup.transform.Find("txt_HellReward_Reward_1").GetComponent<Text>();

        Btn_HellReward_Ok = HellRewardPopup.transform.Find("Btn_HellReward_Ok").GetComponent<Button>();

        #endregion

        #region PetPopup

        btn_Pet_Close = PetPopup.transform.Find("btn_Pet_Close").GetComponent<Button>();
        img_pet = PetPopup.transform.Find("img_pet").GetComponent<Image>();

        btn_pet_lv_1 = PetPopup.transform.Find("btn_pet_lv_1").GetComponent<Button>();
        img_pet_lv_1 = btn_pet_lv_1.transform.Find("img_pet_lv_1").GetComponent<Image>();
        txt_pet_lv_1_val = btn_pet_lv_1.transform.Find("txt_pet_lv_1_val").GetComponent<Text>();
        btn_pet_lv_10 = PetPopup.transform.Find("btn_pet_lv_10").GetComponent<Button>();
        img_pet_lv_10 = btn_pet_lv_10.transform.Find("img_pet_lv_10").GetComponent<Image>();
        txt_pet_lv_10_val = btn_pet_lv_10.transform.Find("txt_pet_lv_10_val").GetComponent<Text>();
        btn_pet_lv_100 = PetPopup.transform.Find("btn_pet_lv_100").GetComponent<Button>();
        img_pet_lv_100 = btn_pet_lv_100.transform.Find("img_pet_lv_100").GetComponent<Image>();
        txt_pet_lv_100_val = btn_pet_lv_100.transform.Find("txt_pet_lv_100_val").GetComponent<Text>();

        txt_pet_name = PetPopup.transform.Find("txt_pet_name").GetComponent<Text>();
        txt_pet_name_val = PetPopup.transform.Find("txt_pet_name_val").GetComponent<Text>();
        txt_pet_lv_val = PetPopup.transform.Find("txt_pet_lv_val").GetComponent<Text>();
        txt_pet_stat_sub_0 = PetPopup.transform.Find("txt_pet_stat_sub_0").GetComponent<Text>();
        txt_pet_stat_0_val = PetPopup.transform.Find("txt_pet_stat_0_val").GetComponent<Text>();
        txt_pet_stat_sub_1 = PetPopup.transform.Find("txt_pet_stat_sub_1").GetComponent<Text>();
        txt_pet_stat_1_val = PetPopup.transform.Find("txt_pet_stat_1_val").GetComponent<Text>();
        btn_pet_buy = PetPopup.transform.Find("btn_pet_buy").GetComponent<Button>();
        img_pet_buy = btn_pet_buy.transform.Find("img_pet_buy").GetComponent<Image>();
        txt_pet_buy = btn_pet_buy.transform.Find("txt_pet_buy").GetComponent<Text>();
        btn_pet_spawn = PetPopup.transform.Find("btn_pet_spawn").GetComponent<Button>();
        btn_pet_limit = PetPopup.transform.Find("btn_pet_limit").GetComponent<Button>();


        #endregion

        #region Content_Job

        scroll_Job = Content_Job.transform.Find("scroll_Job");


        btn_Job_Lv1 = Content_Job.transform.Find("btn_Job_Lv1").GetComponent<Button>();
        btn_Job_Lv10 = Content_Job.transform.Find("btn_Job_Lv10").GetComponent<Button>();
        btn_Job_Lv100 = Content_Job.transform.Find("btn_Job_Lv100").GetComponent<Button>();

        #endregion

        #region Content_Totem

        scroll_Totem = Content_Totem.transform.Find("scroll_Totem");

        btn_Totem_Lv1 = Content_Totem.transform.Find("btn_Totem_Lv1").GetComponent<Button>();
        btn_Totem_Lv10 = Content_Totem.transform.Find("btn_Totem_Lv10").GetComponent<Button>();
        btn_Totem_Lv100 = Content_Totem.transform.Find("btn_Totem_Lv100").GetComponent<Button>();

        #endregion

        #region ShopPopup

        btn_shop_event = ShopPopup.transform.Find("btn_grids/btn_shop_event").GetComponent<Button>();
        btn_shop_gacha = ShopPopup.transform.Find("btn_grids/btn_shop_gacha").GetComponent<Button>();
        btn_shop_goods = ShopPopup.transform.Find("btn_grids/btn_shop_goods").GetComponent<Button>();
        btn_shop_mileage = ShopPopup.transform.Find("btn_grids/btn_shop_mileage").GetComponent<Button>();
        btn_shop_other = ShopPopup.transform.Find("btn_grids/btn_shop_other").GetComponent<Button>();

        Content_Event = ShopPopup.transform.Find("contents/Content_Event").gameObject;
        Content_Gacha = ShopPopup.transform.Find("contents/Content_Gacha").gameObject;
        Content_Goods = ShopPopup.transform.Find("contents/Content_Goods").gameObject;
        Content_Mileage = ShopPopup.transform.Find("contents/Content_Mileage").gameObject;
        Content_Other = ShopPopup.transform.Find("contents/Content_Other").gameObject;

        btn_shop_close = ShopPopup.transform.Find("btn_shop_close").GetComponent<Button>();

        #endregion

        #region GoodsPopup

        img_goods_upgrade = GoodsPopup.transform.Find("content_grid/Goods_Upgrade/img_goods_upgrade").GetComponent<Image>();
        txt_goods_upgrade = GoodsPopup.transform.Find("content_grid/Goods_Upgrade/txt_goods_upgrade").GetComponent<Text>();
        btn_goods_upgrade = GoodsPopup.transform.Find("content_grid/Goods_Upgrade/btn_goods_upgrade").GetComponent<Button>();

        img_goods_soul_stone = GoodsPopup.transform.Find("content_grid/Goods_Soul_Stone/img_goods_soul_stone").GetComponent<Image>();
        txt_goods_soul_stone = GoodsPopup.transform.Find("content_grid/Goods_Soul_Stone/txt_goods_soul_stone").GetComponent<Text>();
        btn_goods_soul_stone = GoodsPopup.transform.Find("content_grid/Goods_Soul_Stone/btn_goods_soul_stone").GetComponent<Button>();

        img_goods_black_stone = GoodsPopup.transform.Find("content_grid/Goods_Black_Stone/img_goods_black_stone").GetComponent<Image>();
        txt_goods_black_stone = GoodsPopup.transform.Find("content_grid/Goods_Black_Stone/txt_goods_black_stone").GetComponent<Text>();
        btn_goods_black_stone = GoodsPopup.transform.Find("content_grid/Goods_Black_Stone/btn_goods_black_stone").GetComponent<Button>();

        img_goods_steel = GoodsPopup.transform.Find("content_grid/Goods_Steel/img_goods_steel").GetComponent<Image>();
        txt_goods_steel = GoodsPopup.transform.Find("content_grid/Goods_Steel/txt_goods_steel").GetComponent<Text>();
        btn_goods_steel = GoodsPopup.transform.Find("content_grid/Goods_Steel/btn_goods_steel").GetComponent<Button>();

        img_goods_mileage = GoodsPopup.transform.Find("content_grid/Goods_Mileage/img_goods_mileage").GetComponent<Image>();
        txt_goods_mileage = GoodsPopup.transform.Find("content_grid/Goods_Mileage/txt_goods_mileage").GetComponent<Text>();
        btn_goods_mileage = GoodsPopup.transform.Find("content_grid/Goods_Mileage/btn_goods_mileage").GetComponent<Button>();

        img_goods_guild_coin = GoodsPopup.transform.Find("content_grid/Goods_Guild_Coin/img_goods_guild_coin").GetComponent<Image>();
        txt_goods_guild_coin = GoodsPopup.transform.Find("content_grid/Goods_Guild_Coin/txt_goods_guild_coin").GetComponent<Text>();
        btn_goods_guild_coin = GoodsPopup.transform.Find("content_grid/Goods_Guild_Coin/btn_goods_guild_coin").GetComponent<Button>();

        #endregion

        #region SettingPopup

        btn_setting_close = SettingPopup.transform.Find("btn_setting_close").GetComponent<Button>();
        btn_setting_repaer = SettingPopup.transform.Find("btn_setting_repaer").GetComponent<Button>();
        btn_setting_language = SettingPopup.transform.Find("btn_setting_language").GetComponent<Button>();
        btn_setting_cupon = SettingPopup.transform.Find("btn_setting_cupon").GetComponent<Button>();
        btn_setting_power = SettingPopup.transform.Find("btn_setting_power").GetComponent<Button>();
        btn_setting_music = SettingPopup.transform.Find("btn_setting_music").GetComponent<Button>();
        txt_setting_music_on = btn_setting_music.transform.Find("txt_setting_music_on").GetComponent<Text>();
        txt_setting_music_off = btn_setting_music.transform.Find("txt_setting_music_off").GetComponent<Text>();
        btn_setting_effect = SettingPopup.transform.Find("btn_setting_effect").GetComponent<Button>();
        txt_setting_effect_on = btn_setting_effect.transform.Find("txt_setting_effect_on").GetComponent<Text>();
        txt_setting_effect_off = btn_setting_effect.transform.Find("txt_setting_effect_off").GetComponent<Text>();
        btn_setting_push = SettingPopup.transform.Find("btn_setting_push").GetComponent<Button>();
        txt_setting_push_on = btn_setting_push.transform.Find("txt_setting_push_on").GetComponent<Text>();
        txt_setting_push_off = btn_setting_push.transform.Find("txt_setting_push_off").GetComponent<Text>();
        btn_setting_grapic = SettingPopup.transform.Find("btn_setting_grapic").GetComponent<Button>();
        txt_setting_grapic_on = btn_setting_grapic.transform.Find("txt_setting_grapic_on").GetComponent<Text>();
        txt_setting_grapic_off = btn_setting_grapic.transform.Find("txt_setting_grapic_off").GetComponent<Text>();
        btn_setting_google = SettingPopup.transform.Find("btn_setting_google").GetComponent<Button>();
        txt_setting_google_login = btn_setting_google.transform.Find("txt_setting_google_login").GetComponent<Text>();
        txt_setting_google_logout = btn_setting_google.transform.Find("txt_setting_google_logout").GetComponent<Text>();
        btn_setting_gameCenter = SettingPopup.transform.Find("btn_setting_gameCenter").GetComponent<Button>();
        txt_setting_gamecenter_login = btn_setting_gameCenter.transform.Find("txt_setting_gamecenter_login").GetComponent<Text>();
        txt_setting_gamecenter_logout = btn_setting_gameCenter.transform.Find("txt_setting_gamecenter_logout").GetComponent<Text>();
        btn_setting_terms = SettingPopup.transform.Find("btn_setting_terms").GetComponent<Button>();
        btn_setting_privacy = SettingPopup.transform.Find("btn_setting_privacy").GetComponent<Button>();
        btn_setting_mail = SettingPopup.transform.Find("btn_setting_mail").GetComponent<Button>();
        btn_setting_exit = SettingPopup.transform.Find("btn_setting_exit").GetComponent<Button>();
        btn_setting_help = SettingPopup.transform.Find("btn_setting_help").GetComponent<Button>();
        btn_setting_logout = SettingPopup.transform.Find("btn_setting_logout").GetComponent<Button>();
        txt_setting_version = SettingPopup.transform.Find("txt_setting_version").GetComponent<Text>();

        #endregion

        #region RepaerPopup

        txt_repear_success = RepaerPopup.transform.Find("txt_repear_success").GetComponent<Text>();
        txt_repear_fail = RepaerPopup.transform.Find("txt_repear_fail").GetComponent<Text>();
        btn_repaer_ok = RepaerPopup.transform.Find("btn_repaer_ok").GetComponent<Button>();

        #endregion

        #region LanguagePopup

        btn_Language_Back = LanguagePopup.transform.Find("btn_Language_Back").GetComponent<Button>();
        btn_Languages = LanguagePopup.transform.Find("btn_Languages").GetComponentsInChildren<Button>(true).ToList();

        #endregion

        #region CuponPopup

        cupon = CuponPopup.transform.Find("cupon").gameObject;
        input_cupon = cupon.transform.Find("input_cupon").GetComponent<InputField>();
        btn_cupon_close = cupon.transform.Find("btn_cupon_close").GetComponent<Button>();
        btn_cupon_ok = cupon.transform.Find("btn_cupon_ok").GetComponent<Button>();

        cupon_success = CuponPopup.transform.Find("cupon_success").gameObject;
        btn_cupon_success = cupon_success.transform.Find("btn_cupon_success").GetComponent<Button>();

        cupon_fail = CuponPopup.transform.Find("cupon_fail").gameObject;
        btn_cupon_fail = cupon_fail.transform.Find("btn_cupon_fail").GetComponent<Button>();
        txt_none_fail = cupon_fail.transform.Find("txt_none_fail").gameObject;
        txt_overlap_fail = cupon_fail.transform.Find("txt_overlap_fail").gameObject;

        #endregion

        #region PowerPopup

        txt_power_time = PowerPopup.transform.Find("txt_power_time").GetComponent<Text>();
        btn_power_close = PowerPopup.transform.Find("btn_power_close").GetComponent<Button>();

        #endregion

        #region ExitPopup

        btn_exit_close = ExitPopup.transform.Find("btn_exit_close").GetComponent<Button>();
        btn_exit_ok = ExitPopup.transform.Find("btn_exit_ok").GetComponent<Button>();

        #endregion

        #region HelpPopup

        btn_help_close = HelpPopup.transform.Find("btn_help_close").GetComponent<Button>();
        btn_help_skill = HelpPopup.transform.Find("btns/btn_help_skill").GetComponent<Button>();
        btn_help_weapon = HelpPopup.transform.Find("btns/btn_help_weapon").GetComponent<Button>();
        btn_help_job = HelpPopup.transform.Find("btns/btn_help_job").GetComponent<Button>();
        btn_help_costume = HelpPopup.transform.Find("btns/btn_help_costume").GetComponent<Button>();
        btn_help_totem = HelpPopup.transform.Find("btns/btn_help_totem").GetComponent<Button>();
        btn_help_roon = HelpPopup.transform.Find("btns/btn_help_roon").GetComponent<Button>();
        btn_help_guild = HelpPopup.transform.Find("btns/btn_help_guild").GetComponent<Button>();
        btn_help_dungeon = HelpPopup.transform.Find("btns/btn_help_dungeon").GetComponent<Button>();
        btn_help_quest = HelpPopup.transform.Find("btns/btn_help_quest").GetComponent<Button>();
        btn_help_pet = HelpPopup.transform.Find("btns/btn_help_pet").GetComponent<Button>();

        submit = HelpPopup.transform.Find("submit").gameObject;

        btn_submit_close = submit.transform.Find("btn_submit_close").GetComponent<Button>();

        submit_skill = submit.transform.Find("submit_skill").gameObject;
        submit_weapon = submit.transform.Find("submit_weapon").gameObject;
        submit_job = submit.transform.Find("submit_job").gameObject;
        submit_costume = submit.transform.Find("submit_costume").gameObject;
        submit_totem = submit.transform.Find("submit_totem").gameObject;
        submit_roon = submit.transform.Find("submit_roon").gameObject;
        submit_guild = submit.transform.Find("submit_guild").gameObject;
        submit_dungeon = submit.transform.Find("submit_dungeon").gameObject;
        submit_quest = submit.transform.Find("submit_quest").gameObject;
        submit_pet = submit.transform.Find("submit_pet").gameObject;

        #endregion

        #region PostPopup

        scroll_Post = PostPopup.transform.Find("scroll_Post");
        btn_Post_Close = PostPopup.transform.Find("btn_Post_Close").GetComponent<Button>();

        #endregion

        #region QuestPopup

        btn_quest_close = QuestPopup.transform.Find("btn_quest_close").GetComponent<Button>();

        btn_daily_quest = QuestPopup.transform.Find("btn_daily_quest").GetComponent<Button>();
        btn_accumulate_quest = QuestPopup.transform.Find("btn_accumulate_quest").GetComponent<Button>();

        scroll_daily_quset = QuestPopup.transform.Find("scroll_daily_quset");
        scroll_accumulate_quest = QuestPopup.transform.Find("scroll_accumulate_quest");

        txt_quset_time = QuestPopup.transform.Find("txt_quset_time").GetComponent<Text>();

        #endregion

        #region QuestItemPopup

        btn_quest_item = QuestItemPopup.transform.Find("btn_quest_item").GetComponent<Button>();
        img_quset_item = btn_quest_item.transform.Find("img_quset_item").GetComponent<Image>();
        txt_quset_item = btn_quest_item.transform.Find("txt_quset_item").GetComponent<Text>();

        #endregion

        #region GiftPopup

        img_gift = GiftPopup.transform.Find("img_gift").GetComponent<Image>();
        txt_gift = GiftPopup.transform.Find("txt_gift").GetComponent<Text>();
        btn_gift_ads = GiftPopup.transform.Find("btn_gift_ads").GetComponent<Button>();
        btn_gift_get = GiftPopup.transform.Find("btn_gift_get").GetComponent<Button>();

        #endregion


        #region CalendarPopup

        calendar_Panels = CalendarPopup.transform.GetComponentsInChildren<Calendar_panel>(true).ToList();
       btn_calendar_get = CalendarPopup.transform.Find("btn_calendar_get").GetComponent<Button>();
       btn_calendar_close = CalendarPopup.transform.Find("btn_calendar_close").GetComponent<Button>();

        #endregion

    }

    private void Check_Popup(GameObject Popup)
    {
        if (Popup.activeSelf)
            PopupManager.Close_Popup();
        else
        {
            PopupManager.Open_Popup(Popup);
        }
    }

    private void AddListener()
    {
        btn_NickName_Ok.onClick.AddListener(() => Check_Nickname());

        Btn_Goods_All.onClick.AddListener(() => Check_Popup(GoodsPopup));



        #region Content_Character

        btn_State.onClick.AddListener(() => Change_Content_Content(Character_Contnet.State));
        btn_Skill.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Skill));
        btn_Upgrade.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Upgrade));
        btn_Limit.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Limit));

        #endregion

        #region Content_Weapon

        btn_Weapon.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Sword));
        btn_Shield.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Shield));
        btn_Accessory.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Accessory));
        btn_Costume.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Costume));

        #endregion

        #region  popup_State

        btn_Lv_1.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_1));
        btn_Lv_10.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_10));
        btn_Lv_100.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_100));

        btn_Icon_Content.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Content));
        btn_Icon_Content.onClick.AddListener(() => BackEndDataManager.instance.Check_Time_Item());


        btn_Icon_Character.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Character));
        btn_Icon_Pet.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Pet));
        btn_Icon_Weapon.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Weapon));
        btn_Icon_Job.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Job));
        btn_Icon_Relics.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Totem));
        btn_Icon_Shop.onClick.AddListener(() => PopupManager.Open_Popup(ShopPopup));

        btn_Invantory_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        btn_Skill_Lv1.onClick.AddListener(() => Set_Skill_Val(Character_Lv.lv_1));
        btn_Skill_Lv10.onClick.AddListener(() => Set_Skill_Val(Character_Lv.lv_10));
        btn_Skill_Lv100.onClick.AddListener(() => Set_Skill_Val(Character_Lv.lv_100));

        btn_Upgrade_1.onClick.AddListener(() => Upgrade_Buy(Character_Lv.lv_1));
        btn_Upgrade_10.onClick.AddListener(() => Upgrade_Buy(Character_Lv.lv_10));
        btn_Upgrade_100.onClick.AddListener(() => Upgrade_Buy(Character_Lv.lv_100));

        #endregion

        #region obj_Stage

        for (int i = 0; i < btn_Pet.Count; i++)
        {
            int pos = i + 1;
            btn_Pet[i].onClick.AddListener(() => Set_Pet_Pos(pos));
        }

        #endregion

        #region obj_Btns


        btn_Boss.onClick.AddListener(() => PlayManager.instance.Start_Boss_Stage());
        btn_Boss_Exit.onClick.AddListener(() => PlayManager.instance.Stop_Boss_Timer(true));
        btn_Inventory.onClick.AddListener(() => PopupManager.Open_Popup(InventoryPopup));
        btn_setting.onClick.AddListener(() => PopupManager.Open_Popup(SettingPopup));
        btn_post.onClick.AddListener(() => PopupManager.Open_Popup(PostPopup));
        btn_quest.onClick.AddListener(() => Change_Quest_Popup(Quest_Popup.daily));
        btn_quest.onClick.AddListener(() => PopupManager.Open_Popup(QuestPopup));
        btn_quest.onClick.AddListener(() => BackEndDataManager.instance.Check_Time_Item());

        btn_progress_reward.onClick.AddListener(() => Add_Progress_Reward());

        btn_gift.onClick.AddListener(() => Set_Gift());

        btn_calendar.onClick.AddListener(() => PopupManager.Open_Popup(CalendarPopup));

        #endregion

        #region WeaponPopup

        btn_Weapon_Info_Popup.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.info));
        btn_Weapon_Upgrade_Popup.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.upgrade));
        btn_Weapon_Mix_Popup.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.mix));
        btn_Weapon_Roon_Popup.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.roon));
        btn_Weapon_Decom_Popup.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.decom));

        btn_Weapon_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        #region content_Weapon_Info

        //btn_Weapon_Limit = content_Weapon_Info.transform.Find("btn_Weapon_Limit").GetComponent<Button>();
        //btn_Weapon_Mount = content_Weapon_Info.transform.Find("btn_Weapon_Mount").GetComponent<Button>();

        #endregion

        #region content_Weapon_Upgrade

        btn_Weapon_Upgrade.onClick.AddListener(() => Buy_Weapon_Upgrade());

        #endregion


        #region content_Weapon_Mix

        btn_Mix_Mius.onClick.AddListener(() => Mix_Plus_Mius(Calculate_Type.mius));
        btn_Mix_Plus.onClick.AddListener(() => Mix_Plus_Mius(Calculate_Type.plus));

        btn_Mix.onClick.AddListener(() => Weapon_Mix());

        #endregion

        #region content_Weapon_roon

        btn_roon_close.onClick.AddListener(() => PopupManager.Close_Popup());

        btn_roon_release.onClick.AddListener(() => Roon_Release());
        btn_roon_mount.onClick.AddListener(() => Roon_Mount());
        btn_roon_stat_close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region content_Weapon_Decom

        btn_Decom.onClick.AddListener(() => Weapon_Decom());

        btn_Decom_Mius.onClick.AddListener(() => Decom_Plus_Mius(Calculate_Type.mius));
        btn_Decom_Plus.onClick.AddListener(() => Decom_Plus_Mius(Calculate_Type.plus));

        #endregion

        #region SettingPopup

        btn_setting_close.onClick.AddListener(() => PopupManager.Close_Popup());
        btn_setting_repaer.onClick.AddListener(() => Setting_Repear());
        btn_setting_language.onClick.AddListener(() => Setting_Language());
        btn_setting_cupon.onClick.AddListener(() => Setting_Cupon());
        btn_setting_power.onClick.AddListener(() => Setting_Power(true));
        btn_setting_music.onClick.AddListener(() => Setting_Music());
        btn_setting_effect.onClick.AddListener(() => Setting_Effect());
        btn_setting_push.onClick.AddListener(() => Setting_Push());
        btn_setting_grapic.onClick.AddListener(() => Setting_Grapic());
        btn_setting_terms.onClick.AddListener(() => Setting_Terms());
        btn_setting_privacy.onClick.AddListener(() => Setting_Privacy());
        btn_setting_mail.onClick.AddListener(() => Setting_Mail());
        btn_setting_exit.onClick.AddListener(() => Setting_Exit());
        btn_setting_help.onClick.AddListener(() => Setting_Help());


        #endregion

        #endregion


        #region UndergroundPopup

        btn_Underground_In.onClick.AddListener(() => PlayManager.instance.Check_Underground());
        btn_Underground_Sweep_10.onClick.AddListener(() => Underground_.Get_Sweep(10));
        btn_Underground_Sweep_1.onClick.AddListener(() => Underground_.Get_Sweep(1));


        btn_Underground_Dungeon_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion


        #region Content_UpgradePopup

        btn_Content_Upgrade_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        Btn_UndergroundReward_Ok.onClick.AddListener(() => Set_Reward_Close());

        #region UpgradeRewardPopup

        Btn_UpgradeReward_Ok.onClick.AddListener(() => Set_Reward_Close());

        #endregion

        #region Content_HellPopup

        btn_Content_Hell_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region HellRewardPopup

        Btn_HellReward_Ok.onClick.AddListener(() => Set_Reward_Close());

        #endregion


        #region PetPopup

        btn_Pet_Close.onClick.AddListener(() => PopupManager.Close_Popup());
        btn_pet_lv_1.onClick.AddListener(() => Buy_Pet(Character_Lv.lv_1));
        btn_pet_lv_10.onClick.AddListener(() => Buy_Pet(Character_Lv.lv_10));
        btn_pet_lv_100.onClick.AddListener(() => Buy_Pet(Character_Lv.lv_100));

        btn_pet_buy.onClick.AddListener(() => Buy_Pet(Character_Lv.lv_1));
        btn_pet_spawn.onClick.AddListener(() => Set_Pet_Btn());
        //btn_pet_limit = PetPopup.transform.Find("btn_pet_limit").GetComponent<Button>();

        #endregion

        #region Content_Job

        btn_Job_Lv1.onClick.AddListener(() => Change_Job_Lv(Character_Lv.lv_1));
        btn_Job_Lv10.onClick.AddListener(() => Change_Job_Lv(Character_Lv.lv_10));
        btn_Job_Lv100.onClick.AddListener(() => Change_Job_Lv(Character_Lv.lv_100));

        #endregion

        #region Content_Totem

        btn_Totem_Lv1.onClick.AddListener(() => Check_Totem_Item(Character_Lv.lv_1));
        btn_Totem_Lv10.onClick.AddListener(() => Check_Totem_Item(Character_Lv.lv_10));
        btn_Totem_Lv100.onClick.AddListener(() => Check_Totem_Item(Character_Lv.lv_100));

        #endregion

        #region ShopPopup

        btn_shop_event.onClick.AddListener(() => Change_Shop_Contnet(Shop_Content.Event));
        btn_shop_gacha.onClick.AddListener(() => Change_Shop_Contnet(Shop_Content.Gacha));
        btn_shop_goods.onClick.AddListener(() => Change_Shop_Contnet(Shop_Content.Goods));
        btn_shop_mileage.onClick.AddListener(() => Change_Shop_Contnet(Shop_Content.Mileage));
        btn_shop_other.onClick.AddListener(() => Change_Shop_Contnet(Shop_Content.Other));

        btn_shop_close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region GoodsPopup

        btn_goods_upgrade.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.upgrade_stone));
        btn_goods_soul_stone.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.soul_stone));
        btn_goods_black_stone.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.black_stone));
        btn_goods_steel.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.steel));
        btn_goods_mileage.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.mileage));
        btn_goods_guild_coin.onClick.AddListener(() => Change_Goods_Contnet(Item_Type.guild_coin));

        #endregion


        #region RepaerPopup

        btn_repaer_ok.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region LanguagePopup

        btn_Language_Back.onClick.AddListener(() => PopupManager.Close_Popup());

        for (int i = 0; i < btn_Languages.Count; i++)
        {
            SystemLanguage lng = (SystemLanguage)langeuae[i];
            btn_Languages[i].onClick.AddListener(() => Language.GetInstance().Set(lng));

        }

        #endregion

        #region CuponPopup

        input_cupon = cupon.transform.Find("input_cupon").GetComponent<InputField>();
        btn_cupon_close.onClick.AddListener(() => PopupManager.Close_Popup());
        btn_cupon_ok.onClick.AddListener(() => Check_Cupon());

        btn_cupon_success.onClick.AddListener(() => PopupManager.Close_Popup());

        btn_cupon_fail.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region PowerPopup

        btn_power_close.onClick.AddListener(() => Setting_Power(false));

        #endregion

        #region HelpPopup

        btn_help_close.onClick.AddListener(() => PopupManager.Close_Popup());

        btn_help_skill.onClick.AddListener(() => Change_Help_Contnet(Help_Type.skill));
        btn_help_weapon.onClick.AddListener(() => Change_Help_Contnet(Help_Type.weapom));
        btn_help_job.onClick.AddListener(() => Change_Help_Contnet(Help_Type.job));
        btn_help_costume.onClick.AddListener(() => Change_Help_Contnet(Help_Type.costume));
        btn_help_totem.onClick.AddListener(() => Change_Help_Contnet(Help_Type.totem));
        btn_help_roon.onClick.AddListener(() => Change_Help_Contnet(Help_Type.roon));
        btn_help_guild.onClick.AddListener(() => Change_Help_Contnet(Help_Type.guild));
        btn_help_dungeon.onClick.AddListener(() => Change_Help_Contnet(Help_Type.dungeon));
        btn_help_quest.onClick.AddListener(() => Change_Help_Contnet(Help_Type.quest));
        btn_help_pet.onClick.AddListener(() => Change_Help_Contnet(Help_Type.pet));

        btn_submit_close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        btn_exit_close.onClick.AddListener(() => PopupManager.Close_Popup());
        btn_exit_ok.onClick.AddListener(() => App_Exit());

        #region PostPopup

        btn_Post_Close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion

        #region QuestPopup

        btn_quest_close.onClick.AddListener(() => PopupManager.Close_Popup());

        btn_daily_quest.onClick.AddListener(() => Change_Quest_Popup(Quest_Popup.daily));
        btn_accumulate_quest.onClick.AddListener(() => Change_Quest_Popup(Quest_Popup.accumulate));

        #endregion


        #region QuestItemPopup

        btn_quest_item.onClick.AddListener(() => QuestItem_Exit());

        #endregion


        #region GiftPopup

        btn_gift_ads.onClick.AddListener(() => Get_Ads_Gift());
        btn_gift_get.onClick.AddListener(() => Get_Gift());

        #endregion

        #region CalendarPopup
        
        btn_calendar_get.onClick.AddListener(() => Get_Calendar());
        btn_calendar_close.onClick.AddListener(() => PopupManager.Close_Popup());

        #endregion
    }

    private void Start()
    {
        Check_Nick_Popup();
        Change_Icon_Content(Icon_Content.Character);
        Change_Content_Content(Character_Contnet.State);
        StartCoroutine("Co_Join_Time");

    }

    public void Set_Ui()
    {
        Set_Progress_Reward_Txt();

        Set_Item_Img();

        Set_Img_Character();
        Set_Txt_Lv();
        Set_Txt_NickName();
        Set_Txt_Exp();
        Set_Txt_Steel();
        Set_Txt_Coin();
        Set_Txt_Crystal();
        Set_Txt_Chapter();
        Set_Txt_Stage();
        Set_Txt_Soul_Stone();
        Set_Txt_Upgrade_Stone();
        Set_Txt_Underground_Ticket();
        Check_Underground_Ticket();
        Set_Txt_Upgrade_Ticket();
        Set_Txt_Black_Stone();
        Set_Txt_Hell_Ticket();
        Set_Txt_Mileage();
        Set_Txt_Guild_Coin();

        Set_Character_Name();
        Set_Character_Lv();
        Set_Character_obj();
        Set_Character_Stat();
        Set_Buy_Lv();

        Set_Quest_Panel();

        Set_Inventory();
        Set_Sword_Panel();
        Set_Shield_Panel();
        Set_Accessory_Panel();
        Set_Content_Panel();
        Set_Underground_Panel();
        Set_Upgrade_Panel();
        Set_Skill_Panel();
        Set_Upgrade_Stat();
        Set_Hell_Panel();
        Set_Pet_Panel();
        Set_Job_Panel();
        Set_Totem_Panel();
        Set_Post_Panel();

        Pet_Init();
        Set_MyRoon();

        Set_Music();
        Set_Effect();
        Set_Push();
        Set_Grapic();

        Check_Gift();

        Set_Calendar();
    }

    public string GetGoldString(BigInteger gold)
    {
        if (gold >= 1000)
        {
            BigInteger total_Gold = gold;

            int count = gold.ToString("n0").Split(',').Length - 1;

            for (int i = 0; i < count - 1; i++)
            {
                gold /= 1000;
            }

            float so = (int)gold / 1000.0f;

            return so.ToString("n2") + (char)(64 + count);
        }

        return gold.ToString("n0");
    }

    #region 닉네임 체크

    /// <summary>
    /// 처음 닉네임 생성 확인
    /// </summary>
    private void Check_Nick_Popup()
    {
        Debug.Log(BackEndDataManager.instance.Player_Data.str_nick);

        if (BackEndDataManager.instance.Player_Data.str_nick.Equals("null"))
        {
            //닉네임 팝업
            PopupManager.Open_Popup(NickNamePopup);
        }
        else
        {
            //게임시작
            PlayManager.instance.Play_Game();
        }

    }

    private void Check_Nickname()
    {
        Debug.Log(Regex.IsMatch(Input_NickName.text, "^[0-9a-zA-Z가-힣]*$") + "   " +
           string.IsNullOrWhiteSpace(Input_NickName.text));

        if (!Regex.IsMatch(Input_NickName.text, "^[0-9a-zA-Z가-힣]*$")
            || string.IsNullOrWhiteSpace(Input_NickName.text) || Input_NickName.text.Equals("null"))
        {
            Check_Nick_State(false);
            return;
        }

        BackEndDataManager.instance.Set_NickName(Input_NickName.text);

    }

    public void Check_Nick_State(bool isActive)
    {
        txt_NickName_Fail.SetActive(!isActive);
    }

    #endregion

    #region PlayerUI 세팅

    public void Set_Item_Img()
    {

        img_Skill_0.sprite = Utill.Get_Skill_Sp((int)Ability_Type.skill_atk);
        img_Skill_1.sprite = Utill.Get_Skill_Sp((int)Ability_Type.skill_atk_speed);
        img_Skill_2.sprite = Utill.Get_Skill_Sp((int)Ability_Type.skill_speed);

        img_top_steel.sprite = Utill.Get_Item_Sp(Item_Type.steel);
        img_top_dia.sprite = Utill.Get_Item_Sp(Item_Type.dia);

        img_goods_upgrade.sprite = Utill.Get_Item_Sp(Item_Type.upgrade_stone);
        img_goods_black_stone.sprite = Utill.Get_Item_Sp(Item_Type.black_stone);
        img_goods_steel.sprite = Utill.Get_Item_Sp(Item_Type.steel);
        img_goods_mileage.sprite = Utill.Get_Item_Sp(Item_Type.mileage);
        img_goods_guild_coin.sprite = Utill.Get_Item_Sp(Item_Type.guild_coin);

        img_Lv_1_Coin.sprite = img_Lv_10_Coin.sprite = img_Lv_100_Coin.sprite = img_top_coin.sprite
            = Utill.Get_Item_Sp(Item_Type.coin);


        img_Upgrade_1_Soul_stone.sprite = img_Upgrade_10_Soul_stone.sprite = img_Upgrade_100_Soul_stone.sprite =
        img_Upgrade_Soul_Stone.sprite = img_Skill_Soul.sprite = img_goods_soul_stone.sprite
            = Utill.Get_Item_Sp(Item_Type.soul_stone);
    }

    public void Set_Img_Character()
    {
        img_Character.sprite = Utill.Get_Character_Sp(BackEndDataManager.instance.Character_Data.Int_character_Num);
    }

    StringBuilder sb;

    public void Set_Txt_Lv()
    {
        sb = new StringBuilder();
        sb.Append("LV.");
        sb.Append(BackEndDataManager.instance.Player_Data.int_lv);

        txt_Lv.text = sb.ToString();
    }

    public void Set_Txt_NickName()
    {
        txt_NickName.text = BackEndDataManager.instance.Player_Data.str_nick;
    }



    public void Set_Txt_Exp()
    {

        slider_Exp.value = (float)Math.Exp(BigInteger.Log(BackEndDataManager.instance.Int_exp) -
            BigInteger.Log(BackEndDataManager.instance.Total_exp()));

    }

    public void Set_Txt_Steel()
    {
        txt_Steel_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.steel));
        txt_Content_Upgrade_Steel_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.steel));
        txt_goods_steel.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.steel));
    }

    public void Set_Txt_Coin()
    {
        txt_Coin_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.coin));
    }

    public void Set_Txt_Crystal()
    {
        txt_Dia_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.dia));
    }

    public void Set_Txt_Upgrade_Stone()
    {
        txt_Underground_Upgread_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));
        txt_Content_Upgrade_Upgread_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));
        txt_Content_Hell_Upgread_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));
        txt_My_Upgrade_Stone.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));
        txt_My_Mix_Stone.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));
        txt_goods_upgrade.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_stone));

    }

    public void Set_Txt_Underground_Ticket()
    {
        txt_Underground_Ticket_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket));
    }

    public void Set_Txt_Upgrade_Ticket()
    {
        txt_Content_Upgrade_Ticket_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.upgrade_ticket));
    }

    public void Set_Txt_Soul_Stone()
    {
        txt_Skill_Soul_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.soul_stone));
        txt_Upgrade_Soul_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.soul_stone));
        txt_Underground_Soul_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.soul_stone));
        txt_goods_soul_stone.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.soul_stone));

    }

    public void Set_Txt_Black_Stone()
    {
        txt_Content_Hell_Black_Stone_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.black_stone));
        txt_goods_black_stone.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.black_stone));

    }

    public void Set_Txt_Mileage()
    {
        txt_goods_mileage.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.mileage));

    }

    public void Set_Txt_Guild_Coin()
    {
        txt_goods_guild_coin.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.guild_coin));

    }

    public void Set_Txt_Hell_Ticket()
    {
        txt_Content_Hell_Ticket_Val.text = GetGoldString(BackEndDataManager.instance.Get_Item(Item_Type.hell_ticket));
    }

    #endregion

    #region StageUI 세팅

    public void Set_Txt_Chapter()
    {
        txt_State_Chapter.text = "챕터 " + BackEndDataManager.instance.Stage_Data.int_chapter.ToString();
    }

    public void Set_Txt_Stage()
    {
        if (BackEndDataManager.instance.Stage_Data.int_step <= 10)
        {
            txt_State_Stage.text = BackEndDataManager.instance.Stage_Data.int_stage.ToString() + " 스테이지 " +
              BackEndDataManager.instance.Stage_Data.int_step.ToString() + "/10";

            btn_Boss.gameObject.SetActive(false);
            btn_Boss_Exit.gameObject.SetActive(false);
        }
        else
        {
            if (!BackEndDataManager.instance.Stage_Data.is_boss)
            {
                txt_State_Stage.text = BackEndDataManager.instance.Stage_Data.int_stage.ToString() + " 스테이지 " + "보스";
                btn_Boss.gameObject.SetActive(false);
                btn_Boss_Exit.gameObject.SetActive(true);
            }
            else
            {
                txt_State_Stage.text = BackEndDataManager.instance.Stage_Data.int_stage.ToString() + " 스테이지 " + "무한";
                btn_Boss.gameObject.SetActive(true);
                btn_Boss_Exit.gameObject.SetActive(false);
            }
        }
    }

    public void Check_Skill()
    {


        Skill skill = Skill_s.skills.Find(x => x.ability_type.Equals((int)Ability_Type.skill_atk));
        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));
        img_Skill_0_lock.gameObject.SetActive(skill_Info == null);

        skill = Skill_s.skills.Find(x => x.ability_type.Equals((int)Ability_Type.skill_atk_speed));
        skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));
        img_Skill_1_lock.gameObject.SetActive(skill_Info == null);

        skill = Skill_s.skills.Find(x => x.ability_type.Equals((int)Ability_Type.skill_speed));
        skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));
        img_Skill_2_lock.gameObject.SetActive(skill_Info == null);


    }

    public void Set_Skill_0_Bg()
    {
        img_Skill_0_bg.gameObject.SetActive(!Player_stat.Use_skill_0);
    }

    public void Set_Skill_0_txt(float fill, int val)
    {

        img_Skill_0_bg.fillAmount = fill;
        txt_Skill_0.text = val.ToString();
    }



    public void Set_Skill_1_Bg()
    {
        img_Skill_1_bg.gameObject.SetActive(!Player_stat.Use_skill_1);

    }

    public void Set_Skill_1_txt(float fill, int val)
    {

        img_Skill_1_bg.fillAmount = fill;
        txt_Skill_1.text = val.ToString();
    }


    public void Set_Skill_2_Bg()
    {
        img_Skill_2_bg.gameObject.SetActive(!Player_stat.Use_skill_2);

    }

    public void Set_Skill_2_txt(float fill, int val)
    {

        img_Skill_2_bg.fillAmount = fill;
        txt_Skill_2.text = val.ToString();
    }
    #endregion

    #region CharacterUI 세팅

    public void Set_Character_Name()
    {
        txt_State_Name.text = "데스나이트";

    }

    public void Set_Character_Lv()
    {
        txt_State_Lv.text = string.Format("Lv.{0}(+{1})",
            BackEndDataManager.instance.Character_Data.int_character_Lv,
            Skill_s.Get_Skill_Val(Ability_Type.add_level));

    }

    public void Set_Character_obj()
    {
        Instantiate(PlayManager.instance.
            Characters[BackEndDataManager.instance.Character_Data.Int_character_Num],
            pos_Character);
    }

    public void Set_Buy_Lv()
    {
        int lv = BackEndDataManager.instance.Character_Data.int_character_Lv;



        txt_Lv_1_Val.text = GetGoldString(Calculate.Price(500, 5, lv, 1));
        txt_Lv_10_Val.text = GetGoldString(Calculate.Price(500, 5, lv, 10));
        txt_Lv_100_Val.text = GetGoldString(Calculate.Price(500, 5, lv, 100));

        BigInteger coin = BackEndDataManager.instance.Get_Item(Item_Type.coin);

        btn_Lv_1.interactable = coin >= Calculate.Price(500, 5, lv, 1);
        btn_Lv_10.interactable = coin >= Calculate.Price(500, 5, lv, 10);
        btn_Lv_100.interactable = coin >= Calculate.Price(500, 5, lv, 100);

    }

    #endregion

    #region Popup 
    Icon_Content icon_Content = Icon_Content.Character;

    public void Change_Icon_Content(Icon_Content popup)
    {
        icon_Content = popup;

        Content_Content.SetActive(popup.Equals(Icon_Content.Content));
        Content_Character.SetActive(popup.Equals(Icon_Content.Character));
        Content_Pet.SetActive(popup.Equals(Icon_Content.Pet));
        Content_Weapon.SetActive(popup.Equals(Icon_Content.Weapon));
        Content_Job.SetActive(popup.Equals(Icon_Content.Job));
        Content_Totem.SetActive(popup.Equals(Icon_Content.Totem));

    }

    public void Change_Content_Content(Character_Contnet popup)
    {
        popup_State.SetActive(popup.Equals(Character_Contnet.State));
        popup_Skill.SetActive(popup.Equals(Character_Contnet.Skill));
        popup_Upgrade.SetActive(popup.Equals(Character_Contnet.Upgrade));
        popup_Limit.SetActive(popup.Equals(Character_Contnet.Limit));
    }

    public void Change_Weapon_Contnet(Weapon_Content popup)
    {
        popup_Sword.SetActive(popup.Equals(Weapon_Content.Sword));
        popup_Shield.SetActive(popup.Equals(Weapon_Content.Shield));
        popup_Accessory.SetActive(popup.Equals(Weapon_Content.Accessory));
        popup_Costume.SetActive(popup.Equals(Weapon_Content.Costume));
    }

    public void Change_Shop_Contnet(Shop_Content popup)
    {
        Content_Event.SetActive(popup.Equals(Shop_Content.Event));
        Content_Gacha.SetActive(popup.Equals(Shop_Content.Gacha));
        Content_Goods.SetActive(popup.Equals(Shop_Content.Goods));
        Content_Mileage.SetActive(popup.Equals(Shop_Content.Mileage));
        Content_Other.SetActive(popup.Equals(Shop_Content.Other));

    }

    public void Change_Help_Contnet(Help_Type popup)
    {
        submit_skill.SetActive(popup.Equals(Help_Type.skill));
        submit_weapon.SetActive(popup.Equals(Help_Type.weapom));
        submit_job.SetActive(popup.Equals(Help_Type.job));
        submit_costume.SetActive(popup.Equals(Help_Type.costume));
        submit_totem.SetActive(popup.Equals(Help_Type.totem));
        submit_roon.SetActive(popup.Equals(Help_Type.roon));
        submit_guild.SetActive(popup.Equals(Help_Type.guild));
        submit_dungeon.SetActive(popup.Equals(Help_Type.dungeon));
        submit_quest.SetActive(popup.Equals(Help_Type.quest));
        submit_pet.SetActive(popup.Equals(Help_Type.pet));

        PopupManager.Open_Popup(submit);

    }


    public void Change_Goods_Contnet(Item_Type popup)
    {
        PopupManager.Close_Popup();

        switch (popup)
        {

            case Item_Type.upgrade_stone:
                Change_Icon_Content(Icon_Content.Weapon);
                Change_Weapon_Contnet(Weapon_Content.Sword);
                break;
            case Item_Type.soul_stone:
                Change_Icon_Content(Icon_Content.Character);
                Change_Content_Content(Character_Contnet.Skill);
                break;
            case Item_Type.black_stone:

                Change_Icon_Content(Icon_Content.Pet);

                break;
            case Item_Type.steel:
                Change_Icon_Content(Icon_Content.Totem);

                break;
            case Item_Type.mileage:

                PopupManager.Open_Popup(ShopPopup);
                Change_Shop_Contnet(Shop_Content.Mileage);
                break;
            case Item_Type.guild_coin:
                PopupManager.Open_Popup(ShopPopup);
                Change_Shop_Contnet(Shop_Content.Other);

                break;


            default:
                break;
        }
    }

    public void Change_Weapon_Popup(Weapon_Popup popup)
    {

        switch (popup)
        {
            case Weapon_Popup.info:
                Set_Weapon_Info();

                break;
            case Weapon_Popup.upgrade:
                Set_Weapon_Upgrade();

                break;
            case Weapon_Popup.mix:
                Set_Weapon_Mix();
                break;
            case Weapon_Popup.roon:
                Set_Weapon_Roon();
                break;
            case Weapon_Popup.decom:
                Set_Weapon_Decom();
                break;
            default:
                break;
        }

        content_Weapon_Info.SetActive(popup.Equals(Weapon_Popup.info));
        content_Weapon_Upgrade.SetActive(popup.Equals(Weapon_Popup.upgrade));
        content_Weapon_Mix.SetActive(popup.Equals(Weapon_Popup.mix));
        content_Weapon_Roon.SetActive(popup.Equals(Weapon_Popup.roon));
        content_Weapon_Decom.SetActive(popup.Equals(Weapon_Popup.decom));

    }

    public void Change_Content_Popup(Popup_Type popup_Type)
    {
        switch (popup_Type)
        {
            case Popup_Type.underground_dungeon:
                PopupManager.Open_Popup(Content_UndergroundPopup);
                break;
            case Popup_Type.upgrade_dungeon:
                PopupManager.Open_Popup(Content_UpgradePopup);

                break;
            case Popup_Type.hell_dungeon:
                PopupManager.Open_Popup(Content_HellPopup);

                break;
            default:
                break;
        }
    }

    public void Change_Quest_Popup(Quest_Popup popup)
    {
        scroll_accumulate_quest.gameObject.SetActive(popup.Equals(Quest_Popup.accumulate));
        scroll_daily_quset.gameObject.SetActive(popup.Equals(Quest_Popup.daily));
    }

    bool ispopup = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !ispopup)
        {
            StartCoroutine("Co_Close_Popop");
            PopupManager.Close_Popup();
        }
    }

    IEnumerator Co_Close_Popop()
    {
        ispopup = true;

        yield return new WaitForSeconds(0.1f);

        ispopup = false;
    }


    #endregion

    #region Content

    public void Set_Content_Panel()
    {
        foreach (var item in BackEndDataManager.instance.content_csv_data)
        {

            Content_Panel content = Instantiate(Content_Panel, Content_Content.transform
                .Find("scroll_content/Viewport/Content")).GetComponent<Content_Panel>();

            content.Set_Panel(item);
        }

    }

    #region Underground_Dungeon


    public void Set_Underground_Panel()
    {
        for (int i = 0; i < BackEndDataManager.instance.underground_dungeon_csv_data.Count; i++)
        {
            GameObject under = Instantiate(Underground_Panel, Content_UndergroundPopup.transform
        .Find("Scroll_Underground/Viewport/Content"));

            int lv = i;

            under.transform.Find("txt_Underground_Lv").GetComponent<Text>().text = string.Format("{0}.{1}", "Lv", lv + 1);
            under.transform.Find("txt_Underground_Lock").GetComponent<Text>().text = string.Format("{0} {1} {2}", "스테이지 ", BackEndDataManager.instance.underground_dungeon_csv_data[i]["unlock_lv"].ToString(), "도달");

            under.GetComponent<Button>().onClick.AddListener(() => Set_Underground_Txt(lv));
            Undergrounds.Add(under);

        }

        Set_Underground_Txt(BackEndDataManager.instance.Content_Data.underground_info.Count - 1);
        Check_Underground_Unlock();
    }

    public void Check_Underground_Unlock()
    {
        for (int i = 0; i < BackEndDataManager.instance.underground_dungeon_csv_data.Count; i++)
        {
            int Lv = (int)BackEndDataManager.instance.underground_dungeon_csv_data[i]["unlock_lv"];

            Undergrounds[i].GetComponent<Button>().interactable = Lv <= BackEndDataManager.instance.Stage_Data.int_stage;
            Undergrounds[i].transform.Find("txt_Underground_Lock").gameObject.SetActive(Lv > BackEndDataManager.instance.Stage_Data.int_stage);

        }
    }


    public void Set_Underground_Txt(int lv)
    {
        for (int i = 0; i < Undergrounds.Count; i++)
        {
            Undergrounds[i].GetComponent<Image>().color = i == lv ? Color.yellow : Color.white;

        }

        Underground_.Underground_Lv = lv;

        Underground_info underground_Info = BackEndDataManager.instance.Content_Data.underground_info
            .Find(x => x.int_num.Equals(lv));

        txt_Max_Monster_Val.text = underground_Info == null ? "0" : underground_Info.int_Max_Monster.ToString();
        txt_Max_Boss_Val.text = underground_Info == null ? "0" : underground_Info.int_Max_Boss.ToString();
        Underground_.Boss_Percent = 5;
        txt_Boss_Percent_Val.text = string.Format("{0}%", Underground_.Boss_Percent);

        txt_Dungeon_Time_Val.text = BackEndDataManager.instance.underground_dungeon_csv_data[lv]["time"].ToString();
        BigInteger reward_0 = BigInteger.Parse(BackEndDataManager.instance.underground_dungeon_csv_data[lv]["reward_val_0"].ToString());
        BigInteger reward_1 = BigInteger.Parse(BackEndDataManager.instance.underground_dungeon_csv_data[lv]["reward_val_1"].ToString());
        txt_Dungeon_Reward_0.text = GetGoldString(reward_0);
        txt_Dungeon_Reward_1.text = GetGoldString(reward_1);

        img_Dungeon_Reward_0.sprite = Underground_.Get_Img_Reward_0();
        img_Dungeon_Reward_1.sprite = Underground_.Get_Img_Reward_1();

    }

    public void Open_Underground()
    {
        Game_info_.Set_Game_Info(Game_Info_Type.undergroind_join, 1);

        Reset_Underground_Item();

        img_Underground_Reward_0.sprite = Underground_.Get_Img_Reward_0();
        img_Underground_Reward_1.sprite = Underground_.Get_Img_Reward_1();

        PopupManager.Close_Popup();
        PopupManager.Open_Popup(UndergroundDungeon);
    }

    public void Set_Underground_timer(float timer)
    {
        txt_Underground_Time.text = string.Format("{0:00}:{1:00}", 0, timer);

    }

    public void Set_Underground_Info()
    {
        txt_Underground_Kill_Monster.text = string.Format("x{0}", Underground_.underground_Info.int_Max_Monster);
        txt_Underground_Kill_Boss.text = string.Format("x{0}", Underground_.underground_Info.int_Max_Boss);
        txt_Underground_Reward_0.text = string.Format("x{0}", GetGoldString(Underground_.Get_Reward_0()));
        txt_Underground_Reward_1.text = string.Format("x{0}", GetGoldString(Underground_.Get_Reward_1()));
    }

    public void Set_Underground_Reward()
    {
        Game_info_.Set_Game_Info(Game_Info_Type.undergroind_clear, 1);

        Debug.Log("Lb v " + Underground_.Underground_Lv);

        BackEndDataManager.instance.Set_Item(Underground_.Get_Reward_0_Type(), Underground_.Get_Reward_0(), Calculate_Type.plus);
        BackEndDataManager.instance.Set_Item(Underground_.Get_Reward_1_Type(), Underground_.Get_Reward_1(), Calculate_Type.plus);

        BackEndDataManager.instance.Check_Underground_Info();

        Set_Underground_Reward_Txt(1);

    }

    public void Reset_Underground_Item()
    {
        foreach (var item in under_list_0)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in under_list_1)
        {
            item.gameObject.SetActive(false);
        }


    }
    public void Set_Underground_Reward_Txt(int val)
    {


        img_UndergroundReward_Reward_0.sprite = Underground_.Get_Img_Reward_0();
        img_UndergroundReward_Reward_1.sprite = Underground_.Get_Img_Reward_1();

        txt_UndergroundReward_Kill_Monster.text = string.Format("x{0}", Underground_.underground_Info.int_Max_Monster * val);
        txt_UndergroundReward_Kill_Boss.text = string.Format("x{0}", Underground_.underground_Info.int_Max_Boss * val);
        txt_UndergroundReward_Reward_0.text = string.Format("x{0}", GetGoldString(Underground_.Get_Reward_0() * val));
        txt_UndergroundReward_Reward_1.text = string.Format("x{0}", GetGoldString(Underground_.Get_Reward_1() * val));

        PopupManager.Open_Popup(UndergroundRewardPopup);

    }

    public void Set_Reward_Close()
    {

        switch (PlayManager.instance.Stage_State)
        {
            case Stage_State.stage:
                PopupManager.Close_Popup();

                break;
            case Stage_State.underground:

                Set_Underground_Txt(Underground_.Underground_Lv);

                PopupManager.All_Close_Popup();

                break;
            case Stage_State.upgrade:

                PopupManager.All_Close_Popup();

                break;
            case Stage_State.hell:

                PopupManager.All_Close_Popup();

                break;

            default:
                break;
        }

        PlayManager.instance.Start_Game(Stage_State.stage);

    }

    public void Check_Underground_Ticket()
    {
        btn_Underground_In.interactable = BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket) >= 1;
        btn_Underground_Sweep_1.interactable = BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket) >= 1;
        btn_Underground_Sweep_10.interactable = BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket) >= 10;
    }

    List<Inventory_Panel> under_list_0 = new List<Inventory_Panel>();
    List<Inventory_Panel> under_list_1 = new List<Inventory_Panel>();

    public void Set_Underground_Val(Item_Type i, int val)
    {
        Debug.Log("Underground 아이템 세팅");

        Inventory_Panel inven_0 = under_list_0.Find(x => x.Item_Type.Equals(i));
        Inventory_Panel inven_1 = under_list_1.Find(x => x.Item_Type.Equals(i));

        if (inven_0 == null)
        {
            Debug.Log("Underground 아이템 없다");

            GameObject obj_0 = Instantiate(Inventory_Panel, UndergroundDungeon.transform
            .Find("Underground_Item"));

            GameObject obj_1 = Instantiate(Inventory_Panel, UndergroundRewardPopup.transform
            .Find("Underground_Item"));


            Inventory_Panel Inventory_0 = obj_0.GetComponent<Inventory_Panel>();
            Inventory_Panel Inventory_1 = obj_1.GetComponent<Inventory_Panel>();

            under_list_0.Add(Inventory_0);
            under_list_1.Add(Inventory_1);

            obj_0.GetComponent<Inventory_Panel>().Set_Panel(i, val);
            obj_1.GetComponent<Inventory_Panel>().Set_Panel(i, val);

        }
        else
        {
            Debug.Log("Underground 아이템 있다");

            inven_0.Set_Inventory_Val(val);
            inven_0.gameObject.SetActive(true);

            inven_1.Set_Inventory_Val(val);
            inven_1.gameObject.SetActive(true);
        }


    }



    #endregion

    #region Upgrade_Dungeon


    public void Set_Upgrade_Panel()
    {
        for (int i = 0; i < BackEndDataManager.instance.upgrade_dungeon_csv_data.Count; i++)
        {
            GameObject under = Instantiate(Content_Upgrade_Panel, Scroll_Content_Upgrade.transform
        .Find("Viewport/Content"));

            under.GetComponent<Content_Upgrade_Panel>().Set_Panel(i);
            content_Upgrade_s.Add(under.GetComponent<Content_Upgrade_Panel>());
        }

    }

    public void Check_Upgrade_Unlock()
    {
        foreach (var item in content_Upgrade_s)
        {
            item.UnLock();
        }
    }

    public void Open_Upgrade()
    {

        Game_info_.Set_Game_Info(Game_Info_Type.upgrade_join, 1);

        img_Upgrade_Reward_0.sprite = Upgrade_.Get_Img_Reward_0();
        img_Upgrade_Reward_1.sprite = Upgrade_.Get_Img_Reward_1();
        txt_Upgrade_Reward_0.text = GetGoldString(Upgrade_.Get_Reward_0());
        txt_Upgrade_Reward_1.text = GetGoldString(Upgrade_.Get_Reward_1());

        PopupManager.Close_Popup();
        PopupManager.Open_Popup(UpgradeDungeon);
    }

    public void Set_Upgrade_timer(float timer)
    {
        txt_Upgrade_Time.text = string.Format("{0:00}:{1:00}", 0, timer);

    }

    public void Set_Upgrade_Reward(bool isSuccess)
    {
        Debug.Log("Lb v " + Underground_.Underground_Lv);

        txt_UpgradeReward_Succese.gameObject.SetActive(isSuccess);
        txt_UpgradeReward_Fail.gameObject.SetActive(!isSuccess);

        if (isSuccess)
        {
            Game_info_.Set_Game_Info(Game_Info_Type.upgrade_clear, 1);

            BackEndDataManager.instance.Set_Item(Upgrade_.Get_Reward_0_Type(), Upgrade_.Get_Reward_0(), Calculate_Type.plus);
            BackEndDataManager.instance.Set_Item(Upgrade_.Get_Reward_1_Type(), Upgrade_.Get_Reward_1(), Calculate_Type.plus);

            Upgrade_info upgrade_Info = BackEndDataManager.instance.Content_Data.upgrade_info.Find(x => x.int_num.Equals(Upgrade_.Upgrade_Lv));

            if (upgrade_Info == null)
            {
                Upgrade_info upgrade_ = new Upgrade_info
                {
                    int_num = Upgrade_.Upgrade_Lv
                };

                BackEndDataManager.instance.Content_Data.upgrade_info.Add(upgrade_);

                BackEndDataManager.instance.Save_Content_Data();

            }

            Check_Upgrade_Unlock();
        }

        Set_Upgrade_Reward_Txt(isSuccess);

    }

    public void Set_Upgrade_Reward_Txt(bool isSuccess)
    {

        img_UpgradeReward_Reward_0.sprite = Upgrade_.Get_Img_Reward_0();
        img_UpgradeReward_Reward_1.sprite = Upgrade_.Get_Img_Reward_1();

        txt_UpgradeReward_Reward_0.text = string.Format("x{0}", isSuccess ? GetGoldString(Upgrade_.Get_Reward_0()) : "0");
        txt_UpgradeReward_Reward_1.text = string.Format("x{0}", isSuccess ? GetGoldString(Upgrade_.Get_Reward_0()) : "0");

        PopupManager.Open_Popup(UpgradeRewardPopup);

    }

    #endregion

    #region Hell_Dungeon


    public void Set_Hell_Panel()
    {
        for (int i = 0; i < BackEndDataManager.instance.hell_dungeon_csv_data.Count; i++)
        {
            GameObject under = Instantiate(Content_Hell_Panel, Scroll_Content_Hell.transform
        .Find("Viewport/Content"));

            under.GetComponent<Content_Hell_Panel>().Set_Panel(i);
            content_Hell_s.Add(under.GetComponent<Content_Hell_Panel>());
        }

    }


    public void Check_Hell_Unlock()
    {
        foreach (var item in content_Hell_s)
        {
            item.UnLock();
        }
    }

    public void Open_Hell()
    {
        Game_info_.Set_Game_Info(Game_Info_Type.hell_join, 1);

        img_Hell_Reward_0.sprite = Hell_.Get_Img_Reward_0();
        img_Hell_Reward_1.sprite = Hell_.Get_Img_Reward_1();

        PopupManager.Close_Popup();
        PopupManager.Open_Popup(HellDungeon);
    }

    public void Set_Hell_timer(float timer)
    {
        txt_Hell_Time.text = string.Format("{0:00}:{1:00}", 0, timer);

    }

    public void Set_Hell_Info()
    {
        txt_Hell_Kill_Monster.text = string.Format("x{0}", Hell_.int_Max_Monster);
        txt_Hell_Reward_0.text = string.Format("x{0}", GetGoldString(Hell_.Get_Reward_0()));
        txt_Hell_Reward_1.text = string.Format("x{0}", GetGoldString(Hell_.Get_Reward_1()));
    }

    public void Set_Hell_Reward()
    {

        Game_info_.Set_Game_Info(Game_Info_Type.hell_clear, 1);

        Debug.Log("Lb v " + Underground_.Underground_Lv);

        BackEndDataManager.instance.Set_Item(Hell_.Get_Reward_0_Type(), Hell_.Get_Reward_0(), Calculate_Type.plus);
        BackEndDataManager.instance.Set_Item(Hell_.Get_Reward_1_Type(), Hell_.Get_Reward_1(), Calculate_Type.plus);

        Hell_info hell_info = BackEndDataManager.instance.Content_Data.hell_info.Find(x => x.int_num.Equals(Hell_.Hell_Lv));

        if (hell_info == null)
        {
            Hell_info hell_ = new Hell_info
            {
                int_num = Hell_.Hell_Lv
            };

            BackEndDataManager.instance.Content_Data.hell_info.Add(hell_);

            BackEndDataManager.instance.Save_Content_Data();

            Check_Hell_Unlock();

        }

        Set_Hell_Reward_Txt();

    }
    public void Set_Hell_Reward_Txt()
    {

        txt_HellReward_Kill_Monster.text = string.Format("x{0}", Hell_.int_Max_Monster);
        img_HellReward_Reward_0.sprite = Hell_.Get_Img_Reward_0();
        img_HellReward_Reward_1.sprite = Hell_.Get_Img_Reward_1();

        txt_HellReward_Reward_0.text = string.Format("x{0}", GetGoldString(Hell_.Get_Reward_0()));
        txt_HellReward_Reward_1.text = string.Format("x{0}", GetGoldString(Hell_.Get_Reward_0()));

        PopupManager.Open_Popup(HellRewardPopup);

    }


    #endregion

    #endregion

    #region Character

    public void Set_Character_Stat()
    {
        txt_State_Atk_Val.text = GetGoldString(Player_stat.int_Total_Atk);
        txt_State_Hp_Val.text = GetGoldString(Player_stat.int_Hp);
        txt_State_Atk_Speed_Val.text = Player_stat.int_Atk_Speed.ToString();
        txt_State_Critical_Val.text = string.Format("{0}{1}", Player_stat.int_Critical_Damege, "%");
        txt_State_Critical_Percent_Val.text = string.Format("{0}{1}", Player_stat.int_Critical_Percent, "%");
        txt_State_Speed_Val.text = Player_stat.int_Speed.ToString();
    }

    #region Skill

    public void Set_Skill_Panel()
    {
        Debug.Log(BackEndDataManager.instance.skill_csv_data.Count);

        foreach (var item in BackEndDataManager.instance.skill_csv_data)
        {


            Skill_Panel skill_ = Instantiate(Skill_Panel, popup_Skill.transform
                .Find("scroll_skill/Viewport/Content")).GetComponent<Skill_Panel>();

            skill_Panels.Add(skill_);

            skill_.Set_Panel((int)item["ability_type"]);

        }

    }


    public void Set_Skill_Val(Character_Lv up_lv)
    {
        foreach (var item in skill_Panels)
        {
            item.Set_Upgrade(up_lv);
        }

    }


    public void Set_Skill_Buy()
    {
        foreach (var item in skill_Panels)
        {
            item.Set_Upgrade(Skill_s.skill_lv);
        }

    }

    #endregion

    #region Upgrade

    public void Set_Upgrade_Stat()
    {
        int My_Lv = BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv;
        int Add_Lv = BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv + 1;

        txt_Upgrade_title.text = string.Format("{0} {1}%{2}", "기본 공격력", My_Lv * 5, "증가");
        txt_Upgrade_Lv.text = string.Format("LV.{0}", My_Lv);
        txt_Upgrade_Next_Lv.text = string.Format("LV.{0}", Add_Lv);
        txt_Upgrade_Percent.text = string.Format("{0}%", 5 * My_Lv);
        txt_Upgrade_Next_Percent.text = string.Format("{0}%", 5 * Add_Lv);

        txt_Upgrade_1_Val.text = GetGoldString(Calculate.Price(500, 5, My_Lv, 1));
        txt_Upgrade_10_Val.text = GetGoldString(Calculate.Price(500, 5, My_Lv, 10));
        txt_Upgrade_100_Val.text = GetGoldString(Calculate.Price(500, 5, My_Lv, 100));

        Check_Upgrade();
    }

    public void Check_Upgrade()
    {
        int My_Lv = BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv;
        BigInteger My_Coin = BackEndDataManager.instance.Get_Item(Item_Type.soul_stone);

        btn_Upgrade_1.interactable = My_Coin >= Calculate.Price(500, 5, My_Lv, 1);
        btn_Upgrade_10.interactable = My_Coin >= Calculate.Price(500, 5, My_Lv, 10);
        btn_Upgrade_100.interactable = My_Coin >= Calculate.Price(500, 5, My_Lv, 100);
    }

    public void Upgrade_Buy(Character_Lv character_Lv)
    {
        Game_info_.Set_Game_Info(Game_Info_Type.upgrade_upgrade, (int)character_Lv);

        UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.upgrade_upgrade, (int)character_Lv);

        int lv = BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv;
        BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv += (int)character_Lv;
        BackEndDataManager.instance.Save_Character_Data();

        BackEndDataManager.instance.Set_Item(Item_Type.soul_stone, Calculate.Price(500, 5, lv, (int)character_Lv), Calculate_Type.mius);

        Set_Upgrade_Stat();

        Player_stat.Set_Player_Stat(Ability_Type.add_atk);

    }

    #endregion

    #endregion

    #region Pet

    public void Set_Pet_Panel()
    {
        for (int i = 0; i < BackEndDataManager.instance.pet_csv_data.Count; i++)
        {
            Pet_Panel pet = Instantiate(Pet_Panel, scroll_pet.transform
                .Find("Viewport/Content")).GetComponent<Pet_Panel>();

            pet.Set_Panel(i);
            pet_Panels.Add(pet);
        }


    }

    public void Open_Pet_Panel(int num)
    {
        Set_Pet_Txt(num);
        PopupManager.Open_Popup(PetPopup);
    }

    public void Set_Pet_Txt(int num)
    {
        Pet_.int_pet = num;

        Pet_info pet_info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(num));

        btn_pet_buy.gameObject.SetActive(pet_info == null);
        btn_pet_spawn.gameObject.SetActive(pet_info != null);
        btn_pet_limit.gameObject.SetActive(pet_info != null);


        int Pet_Ability_type_0 = Pet_.Pet_Ability_type_0();
        int Pet_Ability_type_1 = Pet_.Pet_Ability_type_1();

        Sprite sprite = Utill.Get_Item_Sp((Item_Type)Pet_.Pet_Price_Type());

        img_pet.sprite = Utill.Get_Pet_Sp(num);
        img_pet_buy.sprite = img_pet_lv_1.sprite = img_pet_lv_10.sprite = img_pet_lv_100.sprite = sprite;

        txt_pet_buy.text = GetGoldString(Pet_.Price(pet_info == null ? 0 : pet_info.int_lv, (int)Character_Lv.lv_1));

        txt_pet_lv_1_val.text = GetGoldString(Pet_.Price(pet_info == null ? 0 : pet_info.int_lv, (int)Character_Lv.lv_1));
        txt_pet_lv_10_val.text = GetGoldString(Pet_.Price(pet_info == null ? 0 : pet_info.int_lv, (int)Character_Lv.lv_10));
        txt_pet_lv_100_val.text = GetGoldString(Pet_.Price(pet_info == null ? 0 : pet_info.int_lv, (int)Character_Lv.lv_100));

        txt_pet_name_val.text = Pet_.Pet_Name();
        txt_pet_stat_sub_0.text = Ability_.Get_Ability_Nmae(Pet_Ability_type_0);
        txt_pet_stat_sub_1.text = Ability_.Get_Ability_Nmae(Pet_Ability_type_1);

        txt_pet_lv_val.text = pet_info == null ? "0" : pet_info.int_lv.ToString();

        txt_pet_stat_0_val.text = Pet_Ability_type_0 != -1 ? Pet_.Pet_Ability_type_0_Val().ToString() + Ability_.Ability_Type_Sign(Pet_Ability_type_0) : "";
        txt_pet_stat_1_val.text = Pet_Ability_type_1 != -1 ? Pet_.Pet_Ability_type_1_Val().ToString() + Ability_.Ability_Type_Sign(Pet_Ability_type_1) : "";

    }

    public void Pet_Init()
    {
        for (int i = 0; i < BackEndDataManager.instance.pet_csv_data.Count; i++)
        {
            Pet obj_Pet = Instantiate(Resources.Load<GameObject>("Prefabs/Pet/Pet_" + i), Pet_Spawn).GetComponent<Pet>();
            obj_Pet.gameObject.SetActive(false);
            obj_Pets.Add(obj_Pet);
            obj_Pet.Set_item(i);
        }

        foreach (var item in BackEndDataManager.instance.Pet_Data.pet_info)
        {
            if (item.int_pos != 0)
            {
                Pet_.int_pet = item.int_num;

                Set_Pet_Pos(item.int_pos);
            }
        }
    }

    public void Buy_Pet(Character_Lv _Lv)
    {
        Pet_info pet_info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(Pet_.int_pet));

        BigInteger bigInteger = Pet_.Price(pet_info == null ? 0 : pet_info.int_lv, (int)_Lv);

        if (BackEndDataManager.instance.Get_Item(Pet_.Pet_Price_Type()) >= bigInteger)
        {
            Game_info_.Set_Game_Info(Game_Info_Type.pet_upgrade, (int)_Lv);

            UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.pet_upgrade, (int)_Lv);

            if (pet_info == null)
            {
                pet_info = new Pet_info
                {
                    int_num = Pet_.int_pet,
                    int_lv = (int)_Lv
                };

                BackEndDataManager.instance.Pet_Data.pet_info.Add(pet_info);
            }
            else
            {
                pet_info.int_lv += (int)_Lv;
            }

            pet_Panels[pet_info.int_num].Set_Panel(pet_info.int_num);
            BackEndDataManager.instance.Save_Pet_Data();
            Set_Pet_Txt(Pet_.int_pet);
        }

    }

    public void Pet_Btn_Active(bool active)
    {
        foreach (var item in btn_Pet)
        {
            item.gameObject.SetActive(active);
        }
    }

    public void Set_Pet_Btn()
    {
        Pet_Btn_Active(true);
        PopupManager.Close_Popup();
    }

    public void Set_Pet_Pos(int pos)
    {
        Pet_info pet_info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_pos.Equals(pos));

        if (pet_info != null)
        {
            pet_info.int_pos = 0;

            obj_Pets[pet_info.int_num].gameObject.SetActive(false);

        }

        pet_info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(Pet_.int_pet));

        pet_info.int_pos = pos;

        obj_Pets[pet_info.int_num].transform.position = btn_Pet[pos - 1].transform.position;
        obj_Pets[pet_info.int_num].gameObject.SetActive(true);
        obj_Pets[pet_info.int_num].Set_Move();

        BackEndDataManager.instance.Save_Pet_Data();

        Pet_Btn_Active(false);

    }

    #endregion

    #region Inventory

    public void Set_Inventory()
    {

        foreach (var item in BackEndDataManager.instance.Item_Data.item_Info)
        {
            GameObject obj = Instantiate(Inventory_Panel, InventoryPopup.transform
                .Find("scroll_Invantory/Viewport/Content"));

            Inventory_Panel Inventory = obj.GetComponent<Inventory_Panel>();
            Inventory_Panels.Add(Inventory);

            obj.GetComponent<Inventory_Panel>().Set_Panel((Item_Type)item.type,
                BigInteger.Parse(item.str_val));
        }

    }

    public void Set_Inventory_Val(Item_Type i)
    {
        Item_Info item_Info = BackEndDataManager.instance.Item_Data.item_Info.Find(x => x.type.Equals((int)i));


        Inventory_Panel inven = Inventory_Panels.Find(x => x.Item_Type.Equals(i));

        if (inven == null)
        {
            GameObject obj = Instantiate(Inventory_Panel, InventoryPopup.transform
        .Find("scroll_Invantory/Viewport/Content"));
            Inventory_Panel Inventory = obj.GetComponent<Inventory_Panel>();
            Inventory_Panels.Add(Inventory);

            obj.GetComponent<Inventory_Panel>().Set_Panel(i,
                BigInteger.Parse(item_Info.str_val));
        }
        else
        {
            inven.Set_Inventory_Val(BigInteger.Parse(item_Info.str_val));

        }
    }

    #endregion

    #region Content_Weapon

    //popup_Weapon;
    //popup_Shield;
    //popup_Accessory;
    //popup_Costume;

    public void Set_Sword_Panel()
    {

        for (int i = 0; i < BackEndDataManager.instance.sword_csv_data.Count; i++)
        {
            Weapon_Panel weapon_ = Instantiate(weapon_Panel, popup_Sword.transform
            .Find("scroll_sword/Viewport/Content")).GetComponent<Weapon_Panel>();

            weapon_.Set_Panel(i, Weapon_Content.Sword);
        }


    }


    public void Set_Shield_Panel()
    {

        for (int i = 0; i < BackEndDataManager.instance.shield_csv_data.Count; i++)
        {
            Weapon_Panel weapon_ = Instantiate(weapon_Panel, popup_Shield.transform
            .Find("scroll_shield/Viewport/Content")).GetComponent<Weapon_Panel>();

            weapon_.Set_Panel(i, Weapon_Content.Shield);
        }


    }

    public void Set_Accessory_Panel()
    {

        for (int i = 0; i < BackEndDataManager.instance.accessory_csv_data.Count; i++)
        {
            Weapon_Panel weapon_ = Instantiate(weapon_Panel, popup_Accessory.transform
            .Find("scroll_accessory/Viewport/Content")).GetComponent<Weapon_Panel>();

            weapon_.Set_Panel(i, Weapon_Content.Accessory);
        }


    }
    #endregion

    #region WeaponPopup

    Color[] grade_colors = new Color[] { Color.gray, Color.green, Color.blue, Color.black, Color.red, Color.yellow };
    string[] grade = new string[] { "D", "C", "B", "A", "S", "SS" };
    int[] grade_decom = new int[] { 100, 80, 60, 50, 30, 15 };

    Dictionary<string, object> my_data = new Dictionary<string, object>();
    Dictionary<string, object> next_data = new Dictionary<string, object>();
    Weapon_info my_Info = new Weapon_info();
    Weapon_info next_Info = new Weapon_info();

    bool isData = false;

    public void Open_WeaponPopup()
    {
        PopupManager.Open_Popup(WeaponPopup);
        Change_Weapon_Popup(Weapon_Popup.info);
    }

    #region weapon_info

    public void Set_Weapon_Info()
    {

        Debug.Log("we " + Weapon_.Select_Weapon + "   " + Weapon_.Weapon_Content);


        my_Info = BackEndDataManager.instance.Weapon_Data.weapon_Info.Find(x => x.int_num.Equals(Weapon_.Select_Weapon) && x.enum_weapon.Equals(Weapon_.Weapon_Content));
        next_Info = BackEndDataManager.instance.Weapon_Data.weapon_Info.Find(x => x.int_num.Equals(Weapon_.Select_Weapon + 1) && x.enum_weapon.Equals(Weapon_.Weapon_Content));

        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:
                my_data = BackEndDataManager.instance.sword_csv_data[Weapon_.Select_Weapon];

                isData = Weapon_.Select_Weapon + 1 < BackEndDataManager.instance.sword_csv_data.Count;

                if (isData)
                {
                    next_data = BackEndDataManager.instance.sword_csv_data[Weapon_.Select_Weapon + 1];
                }

                img_Weapon.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon);
                btn_Weapon_Mount.gameObject.SetActive(my_Info != null && !BackEndDataManager.instance.Weapon_Data.sword_mount.Equals(Weapon_.Select_Weapon));

                break;
            case Weapon_Content.Shield:
                my_data = BackEndDataManager.instance.shield_csv_data[Weapon_.Select_Weapon];

                isData = Weapon_.Select_Weapon + 1 < BackEndDataManager.instance.shield_csv_data.Count;

                if (isData)
                {
                    next_data = BackEndDataManager.instance.shield_csv_data[Weapon_.Select_Weapon + 1];
                }

                img_Weapon.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon);
                btn_Weapon_Mount.gameObject.SetActive(my_Info != null && !BackEndDataManager.instance.Weapon_Data.shield_mount.Equals(Weapon_.Select_Weapon));

                break;
            case Weapon_Content.Accessory:
                my_data = BackEndDataManager.instance.accessory_csv_data[Weapon_.Select_Weapon];

                isData = Weapon_.Select_Weapon + 1 < BackEndDataManager.instance.accessory_csv_data.Count;

                if (isData)
                {
                    next_data = BackEndDataManager.instance.accessory_csv_data[Weapon_.Select_Weapon + 1];
                }

                img_Weapon.sprite = Utill.Get_Accessory_Sp(Weapon_.Select_Weapon);
                btn_Weapon_Mount.gameObject.SetActive(my_Info != null && !BackEndDataManager.instance.Weapon_Data.accessory_mount.Equals(Weapon_.Select_Weapon));

                break;
            case Weapon_Content.Costume:
                // data = BackEndDataManager.instance.co[Weapon_.Select_Weapon];

                break;
            default:
                break;
        }


        txt_Weapon_name.text = my_data["name"].ToString();
        img_weapon_bg.color = grade_colors[Array.FindIndex(grade, i => i == my_data["grade"].ToString())];
        txt_Weapon_Grade.text = my_data["grade"].ToString();


        txt_Weapon_Lv.text = string.Format("{0}{1}", "Lv", my_Info == null ? 0 : my_Info.int_lv);

        btn_Weapon_Limit.gameObject.SetActive(my_Info != null);


        Set_Weapon_Info_Stat();
    }

    public void Set_Weapon_Info_Stat()
    {
        for (int i = 0; i < txt_Mount_sub.Count; i++)
        {
            bool isActive = (int)my_data["ability_type_" + i] != -1;

            txt_Mount_sub[i].gameObject.SetActive(isActive);
            txt_Mount_val[i].gameObject.SetActive(isActive);
            txt_Use_sub[i].gameObject.SetActive(isActive);
            txt_Use_val[i].gameObject.SetActive(isActive);

            int ability_type_ = (int)my_data["ability_type_" + i];
            float ability_val_ = (float)my_data["ability_val_" + i];
            float ability_val_amount = (float)my_data["ability_val_amount_" + i];

            Debug.Log(ability_type_);

            if (isActive)
            {
                if (my_Info == null)
                {
                    txt_Mount_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Use_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Mount_val[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                    txt_Use_val[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                }
                else
                {

                    txt_Mount_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Use_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Mount_val[i].text = (ability_val_ + ability_val_amount * my_Info.int_lv) + Ability_.Ability_Type_Sign(ability_type_);
                    txt_Use_val[i].text = (ability_val_ + ability_val_amount * my_Info.int_lv) + Ability_.Ability_Type_Sign(ability_type_);
                }


            }


        }


        for (int i = 0; i < 2; i++)
        {
            bool isActive = (int)my_data["limit_ability_type_" + i] != -1;

            txt_Mount_limit_sub[i].gameObject.SetActive(true);
            txt_Mount_limit_val[i].gameObject.SetActive(isActive);
            txt_Use_limit_sub[i].gameObject.SetActive(true);
            txt_Use_limit_val[i].gameObject.SetActive(isActive);


            int ability_type_ = (int)my_data["limit_ability_type_" + i];
            float ability_val_ = (float)my_data["limit_ability_val_" + i];


            txt_Mount_limit_val[i].text = string.Format("{0}{1}{2}", "초월", i + 1, "필요");
            txt_Use_limit_val[i].text = string.Format("{0}{1}{2}", "초월", i + 1, "필요");


            if (isActive)
            {
                txt_Mount_limit_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                txt_Use_limit_sub[i].text = Ability_.Get_Ability_Nmae(ability_type_);

                if (my_Info != null)
                {
                    Debug.Log(i + "    " + my_Info.int_limit);
                    if (my_Info.int_limit > i)
                    {
                        txt_Mount_limit_val[i].gameObject.SetActive(true);
                        txt_Use_limit_val[i].gameObject.SetActive(true);

                        txt_Mount_limit_val[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                        txt_Use_limit_val[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                    }
                }
            }

        }



    }

    #endregion

    #region wepon_upgrade

    public void Set_Weapon_Upgrade()
    {

        img_weapon_bg_Upgrade.color = grade_colors[Array.FindIndex(grade, i => i == my_data["grade"].ToString())];
        txt_Weapon_Grade_Upgrade.text = my_data["grade"].ToString();


        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:
                img_Weapon_Upgrade.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon);

                break;
            case Weapon_Content.Shield:
                img_Weapon_Upgrade.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon);

                break;
            case Weapon_Content.Accessory:
                img_Weapon_Upgrade.sprite = Utill.Get_Accessory_Sp(Weapon_.Select_Weapon);

                break;
            case Weapon_Content.Costume:

                break;
            default:
                break;
        }

        img_Upgrade_Stone.sprite = Utill.Get_Item_Sp((Item_Type)my_data["upgrade_type"]);

        Set_Weapon_Upgrade_Stat();

    }

    public void Set_Weapon_Upgrade_Stat()
    {
        BigInteger big = Calculate.Percent((int)my_data["upgrade_val"], 0.05f, my_Info == null ? 1 : my_Info.int_lv, 1);

        Debug.Log(big);

        txt_Upgrade_Stone.text = GetGoldString(big);

        btn_Weapon_Upgrade.interactable = my_Info != null && BackEndDataManager.instance.Get_Item((Item_Type)my_data["upgrade_type"]) >= big;

        for (int i = 0; i < txt_Mount_sub_Upgrade.Count; i++)
        {
            bool isActive = (int)my_data["ability_type_" + i] != -1;

            txt_Mount_sub_Upgrade[i].gameObject.SetActive(isActive);
            txt_Mount_val_Upgrade[i].gameObject.SetActive(isActive);
            txt_Use_sub_Upgrade[i].gameObject.SetActive(isActive);
            txt_Use_val_Upgrade[i].gameObject.SetActive(isActive);

            int ability_type_ = (int)my_data["ability_type_" + i];
            float ability_val_ = (float)my_data["ability_val_" + i];
            float ability_val_amount = (float)my_data["ability_val_amount_" + i];

            Debug.Log(ability_type_);

            if (isActive)
            {
                if (my_Info == null)
                {
                    txt_Mount_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Use_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Mount_val_Upgrade[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                    txt_Use_val_Upgrade[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                }
                else
                {

                    txt_Mount_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Use_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                    txt_Mount_val_Upgrade[i].text = (ability_val_ + ability_val_amount * my_Info.int_lv) + Ability_.Ability_Type_Sign(ability_type_);
                    txt_Use_val_Upgrade[i].text = (ability_val_ + ability_val_amount * my_Info.int_lv) + Ability_.Ability_Type_Sign(ability_type_);
                }


            }


        }


        for (int i = 0; i < txt_Mount_limit_sub_Upgrade.Count; i++)
        {
            bool isActive = (int)my_data["limit_ability_type_" + i] != -1;

            txt_Mount_limit_sub_Upgrade[i].gameObject.SetActive(true);
            txt_Mount_limit_val_Upgrade[i].gameObject.SetActive(isActive);
            txt_Use_limit_sub_Upgrade[i].gameObject.SetActive(true);
            txt_Use_limit_val_Upgrade[i].gameObject.SetActive(isActive);


            int ability_type_ = (int)my_data["limit_ability_type_" + i];
            float ability_val_ = (float)my_data["limit_ability_val_" + i];


            txt_Mount_limit_val_Upgrade[i].text = string.Format("{0}{1}{2}", "초월", i + 1, "필요");
            txt_Use_limit_val_Upgrade[i].text = string.Format("{0}{1}{2}", "초월", i + 1, "필요");


            if (isActive)
            {
                txt_Mount_limit_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);
                txt_Use_limit_sub_Upgrade[i].text = Ability_.Get_Ability_Nmae(ability_type_);

                if (my_Info != null)
                {
                    Debug.Log(i + "    " + my_Info.int_limit);
                    if (my_Info.int_limit > i)
                    {
                        txt_Mount_limit_val_Upgrade[i].gameObject.SetActive(true);
                        txt_Use_limit_val_Upgrade[i].gameObject.SetActive(true);

                        txt_Mount_limit_val_Upgrade[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                        txt_Use_limit_val_Upgrade[i].text = ability_val_ + Ability_.Ability_Type_Sign(ability_type_);
                    }
                }
            }

        }

        txt_Weapon_Lv_Low_Upgrade.text = string.Format("{0}{1}", "Lv.", my_Info == null ? 0 : my_Info.int_lv);
        txt_Weapon_Lv_Next_Upgrade.text = string.Format("{0}{1}", "Lv.", my_Info == null ? 1 : my_Info.int_lv + 1);

    }

    public void Buy_Weapon_Upgrade()
    {


        BigInteger big = Calculate.Percent((int)my_data["upgrade_val"], 0.05f, my_Info == null ? 1 : my_Info.int_lv, 1);

        if (BackEndDataManager.instance.Get_Item((Item_Type)my_data["upgrade_type"]) >= big)
        {
            switch (Weapon_.Weapon_Content)
            {
                case Weapon_Content.Sword:
                    Check_Progress_Reward(Progress_Reward_Type.weapon_upgrade, 1);
                    Game_info_.Set_Game_Info(Game_Info_Type.weapon_upgrade, 1);
                    Quest_.Check_Daily_Quest(Daily_Quest_Type.weapon_upgrade, 1);

                    break;
                case Weapon_Content.Shield:
                    Check_Progress_Reward(Progress_Reward_Type.shield_upgrade, 1);
                    Game_info_.Set_Game_Info(Game_Info_Type.shield_upgrade, 1);

                    break;
                case Weapon_Content.Accessory:
                    Check_Progress_Reward(Progress_Reward_Type.accessory_upgrade, 1);
                    Game_info_.Set_Game_Info(Game_Info_Type.accessory_upgrade, 1);

                    break;
                case Weapon_Content.Costume:
                    break;
                default:
                    break;
            }
            BackEndDataManager.instance.Set_Item((Item_Type)my_data["upgrade_type"], big, Calculate_Type.mius);

            my_Info.int_lv += 1;
            BackEndDataManager.instance.Save_Weapon_Data();

            Set_Weapon_Upgrade_Stat();
        }

    }

    #endregion

    #region weapon_mix

    public void Set_Weapon_Mix()
    {



        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:

                img_my_Weapon_Mix.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon);
                img_next_Weapon_Mix.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon + 1);
                break;
            case Weapon_Content.Shield:

                img_my_Weapon_Mix.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon);
                img_next_Weapon_Mix.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon + 1);
                break;
            case Weapon_Content.Accessory:

                img_my_Weapon_Mix.sprite = Utill.Get_Accessory_Sp(Weapon_.Select_Weapon);
                img_next_Weapon_Mix.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon + 1);
                break;
            case Weapon_Content.Costume:

                break;
            default:
                break;
        }


        img_my_weapon_bg_Mix.color = grade_colors[Array.FindIndex(grade, i => i == my_data["grade"].ToString())];
        txt_my_Weapon_Grade_Mix.text = my_data["grade"].ToString();
        txt_my_Weapon_Lv_Mix.text = string.Format("{0}{1}", "Lv", my_Info == null ? 0 : my_Info.int_lv);

        img_next_weapon_bg_Mix.gameObject.SetActive(isData);
        txt_next_Weapon_Grade_Mix.gameObject.SetActive(isData);
        txt_next_Weapon_Lv_Mix.gameObject.SetActive(isData);

        if (isData)
        {
            img_next_weapon_bg_Mix.color = grade_colors[Array.FindIndex(grade, i => i == next_data["grade"].ToString())];
            txt_next_Weapon_Grade_Mix.text = next_data["grade"].ToString();
            txt_next_Weapon_Lv_Mix.text = string.Format("{0}{1}", "Lv", next_Info == null ? 0 : next_Info.int_lv);

        }

        img_Mix_Stone.sprite = Utill.Get_Item_Sp((Item_Type)my_data["upgrade_type"]);

        Weapon_.Mix_Count = my_Info == null ? 0 : my_Info.int_val / 10;

        Set_Weapon_Mix_Val();
    }

    public void Set_Weapon_Mix_Val()
    {

        txt_my_Weapon_Ea_Mix.text = string.Format("{0}(-{1})", my_Info == null ? 0 : my_Info.int_val, Weapon_.Mix_Count * 10);
        txt_next_Weapon_Ea_Mix.text = string.Format("{0}(+{1})", next_Info == null ? 0 : next_Info.int_val, Weapon_.Mix_Count);

        txt_Mix_val.text = Weapon_.Mix_Count.ToString();

        txt_Mix_Stone.text = ((int)my_data["mix"] * Weapon_.Mix_Count).ToString();

        btn_Mix.interactable = my_Info != null && my_Info.int_val >= 10
            && BackEndDataManager.instance.Get_Item((Item_Type)my_data["upgrade_type"]) >= (int)my_data["mix"];

    }

    public void Mix_Plus_Mius(Calculate_Type calculate_Type)
    {
        if (my_Info == null)
            return;

        switch (calculate_Type)
        {
            case Calculate_Type.plus:
                Weapon_.Mix_Count += 1;

                if (Weapon_.Mix_Count > my_Info.int_val / 10)
                    Weapon_.Mix_Count = my_Info.int_val / 10;

                break;
            case Calculate_Type.mius:
                Weapon_.Mix_Count -= 1;

                if (my_Info.int_val / 10 >= 1 && Weapon_.Mix_Count <= 1)
                    Weapon_.Mix_Count = 1;
                else if (my_Info.int_val / 10 < 1)
                    Weapon_.Mix_Count = 0;

                break;
            default:
                break;
        }



        Set_Weapon_Mix_Val();
    }

    public void Weapon_Mix()
    {

        BackEndDataManager.instance.Set_Item((Item_Type)my_data["upgrade_type"],
            (int)my_data["mix"] * Weapon_.Mix_Count, Calculate_Type.mius);

        my_Info.int_val -= Weapon_.Mix_Count * 10;

        if (next_Info == null)
        {
            Weapon_info weapon_Info = new Weapon_info
            {
                int_num = Weapon_.Select_Weapon + 1,
                enum_weapon = Weapon_.Weapon_Content,
                int_val = Weapon_.Mix_Count,
                int_lv = 1,
                int_upgread = 0,
                int_limit = 0
            };

            BackEndDataManager.instance.Weapon_Data.weapon_Info.Add(weapon_Info);


        }
        else
        {
            next_Info.int_val = Weapon_.Mix_Count;
        }

        List<Weapon_Panel> weapon_s = new List<Weapon_Panel>();

        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:
                weapon_s = popup_Sword.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Check_Progress_Reward(Progress_Reward_Type.weapon_mix, Weapon_.Mix_Count);
                Game_info_.Set_Game_Info(Game_Info_Type.weapon_mix, Weapon_.Mix_Count);
                Quest_.Check_Daily_Quest(Daily_Quest_Type.weapon_mix, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Shield:
                weapon_s = popup_Shield.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Game_info_.Set_Game_Info(Game_Info_Type.shield_mix, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Accessory:
                weapon_s = popup_Accessory.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Game_info_.Set_Game_Info(Game_Info_Type.accessory_mix, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Costume:
                break;
            default:
                break;
        }

        weapon_s.Find(x => x.item_num.Equals(Weapon_.Select_Weapon + 1)).Set_Weapon_Lv();

        BackEndDataManager.instance.Save_Weapon_Data();

        Set_Weapon_Mix();

    }

    #endregion

    #region weapon_roon

    public void Set_Weapon_Roon()
    {
        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:

                img_Weapon_roon.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Shield:

                img_Weapon_roon.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Accessory:

                img_Weapon_roon.sprite = Utill.Get_Accessory_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Costume:

                break;
            default:
                break;
        }


        img_weapon_bg_roon.color = grade_colors[Array.FindIndex(grade, i => i == my_data["grade"].ToString())];

        if (my_Info.list_roon == null)
        {
            my_Info.list_roon = new List<Roon_Slot>();

            for (int i = 0; i < 6; i++)
            {

                Roon_Slot roon_Slot = new Roon_Slot
                {
                    int_slot = i,
                    int_roon = new Roon_Info(),
                    isLock = i >= 3
                };

                my_Info.list_roon.Add(roon_Slot);

            }

            BackEndDataManager.instance.Save_Weapon_Data();
        }

        for (int i = 0; i < mount_roons.Count; i++)
        {
            mount_roons[i].Set_Item_Slot(my_Info.list_roon[i]);

        }

        Roon_Stat = content_Weapon_Roon.transform.Find("Roon_Stat").gameObject;

        img_select_roon = Roon_Stat.transform.Find("img_select_roon").GetComponent<Image>();
        txt_select_roon_stat = Roon_Stat.transform.Find("txt_select_roon_stat").GetComponent<Text>();

    }

    List<Roon> roons = new List<Roon>();

    public void Set_MyRoon()
    {
        foreach (var item in roons)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < BackEndDataManager.instance.Item_Data.roon_Info.Count; i++)
        {
            if (i >= roons.Count)
            {
                Roon roon = Instantiate(pef_roon, My_Roon.transform.Find("scroll_roon/Viewport/Content")).GetComponent<Roon>();
                roons.Add(roon);
                roon.Set_Item(BackEndDataManager.instance.Item_Data.roon_Info[i]);
            }
            else
            {
                roons[i].Set_Item(BackEndDataManager.instance.Item_Data.roon_Info[i]);
                roons[i].gameObject.SetActive(true);
            }

        }


    }

    public void Open_My_Roon()
    {
        PopupManager.Open_Popup(My_Roon);
    }

    public void Open_Roon_Stat(bool isMount)
    {

        img_select_roon.sprite = Utill.Get_Roon_Sp(Weapon_.roon_Info.type);
        int ability_Type = (int)BackEndDataManager.instance.roon_csv_data[Weapon_.roon_Info.type]["ability_type_0"];
        txt_select_roon_stat.text = Ability_.Get_Ability_Nmae(ability_Type);
        txt_select_roon_stat_val.text = (float)BackEndDataManager.instance.roon_csv_data[Weapon_.roon_Info.type]["ability_val_0"] + Ability_.Ability_Type_Sign(ability_Type);

        btn_roon_mount.gameObject.SetActive(isMount);
        btn_roon_release.gameObject.SetActive(!isMount && BackEndDataManager.instance.Get_Item(Item_Type.dia) >= 100);

        PopupManager.Open_Popup(Roon_Stat);

    }

    public void Roon_Mount()
    {
        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:
                Game_info_.Set_Game_Info(Game_Info_Type.weapon_roon, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Shield:
                Game_info_.Set_Game_Info(Game_Info_Type.shield_roon, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Accessory:
                Game_info_.Set_Game_Info(Game_Info_Type.accessory_roon, Weapon_.Mix_Count);

                break;
            case Weapon_Content.Costume:
                break;
            default:
                break;
        }

        my_Info.list_roon[Weapon_.roon_Slot.int_slot].int_roon = Weapon_.roon_Info;

        mount_roons[Weapon_.roon_Slot.int_slot].Set_Item_Slot(my_Info.list_roon[Weapon_.roon_Slot.int_slot]);

        BackEndDataManager.instance.Item_Data.roon_Info.Remove(Weapon_.roon_Info);

        BackEndDataManager.instance.Save_Weapon_Data();
        BackEndDataManager.instance.Save_Item_Data();

        PopupManager.Close_Popup();
        PopupManager.Close_Popup();

        Set_MyRoon();
    }

    public void Roon_Release()
    {
        if (BackEndDataManager.instance.Get_Item(Item_Type.dia) >= 100)
        {
            BackEndDataManager.instance.Set_Item(Item_Type.dia, 100, Calculate_Type.mius);

            Roon_Info _Info = new Roon_Info
            {
                type = Weapon_.roon_Slot.int_roon.type
            };

            Debug.Log("해제 타입 " + _Info.type);

            BackEndDataManager.instance.Item_Data.roon_Info.Add(_Info);

            my_Info.list_roon[Weapon_.roon_Slot.int_slot].int_roon.type = -1;

            mount_roons[Weapon_.roon_Slot.int_slot].Set_Item_Slot(my_Info.list_roon[Weapon_.roon_Slot.int_slot]);

            BackEndDataManager.instance.Save_Weapon_Data();
            BackEndDataManager.instance.Save_Item_Data();

            PopupManager.Close_Popup();
            Set_MyRoon();
        }

    }

    #endregion

    #region wepon_decom

    public void Set_Weapon_Decom()
    {

        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:

                img_Weapon_decom.sprite = Utill.Get_Sword_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Shield:

                img_Weapon_decom.sprite = Utill.Get_Shield_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Accessory:

                img_Weapon_decom.sprite = Utill.Get_Accessory_Sp(Weapon_.Select_Weapon);
                break;
            case Weapon_Content.Costume:

                break;
            default:
                break;
        }

        int int_grade = Array.FindIndex(grade, i => i == my_data["grade"].ToString());
        img_Decom.sprite = Utill.Get_Item_Sp((Item_Type)Item_Type.weapon_limit_stone_d + int_grade);

        img_weapon_bg_decom.color = grade_colors[int_grade];
        txt_Weapon_Grade_decom.text = my_data["grade"].ToString();
        txt_Weapon_Lv_decom.text = string.Format("{0}{1}", "Lv", my_Info == null ? 0 : my_Info.int_lv);

        Weapon_.Decom_Count = my_Info == null ? 0 : my_Info.int_val >= 2 ? my_Info.int_val - 1 : 0;

        Set_Weapon_Decom_Val();
    }

    public void Set_Weapon_Decom_Val()
    {
        int int_grade = Array.FindIndex(grade, i => i == my_data["grade"].ToString());

        int grade_val = grade_decom[int_grade];

        txt_Weapon_Ea_decom.text = string.Format("{0}(-{1})", my_Info == null ? 0 : my_Info.int_val, Weapon_.Decom_Count);
        txt_Decom_Ea_decom.text = string.Format("{0}(+{1})",
            BackEndDataManager.instance.Get_Item(Item_Type.weapon_limit_stone_d + int_grade), Weapon_.Decom_Count * grade_val);

        txt_Decom_val.text = Weapon_.Decom_Count.ToString();

        btn_Decom.interactable = my_Info != null && my_Info.int_val >= 2;

    }

    public void Decom_Plus_Mius(Calculate_Type calculate_Type)
    {
        if (my_Info == null)
            return;

        Debug.Log(calculate_Type);

        switch (calculate_Type)
        {
            case Calculate_Type.plus:
                Weapon_.Decom_Count += 1;

                if (my_Info.int_val >= 2 && Weapon_.Decom_Count > my_Info.int_val - 1)
                    Weapon_.Decom_Count = my_Info.int_val - 1;
                else if (my_Info.int_val < 2)
                    Weapon_.Decom_Count = 0;

                break;
            case Calculate_Type.mius:
                Weapon_.Decom_Count -= 1;

                if (my_Info.int_val >= 2 && Weapon_.Decom_Count < 1)
                    Weapon_.Decom_Count = 1;
                else if (my_Info.int_val < 2)
                    Weapon_.Decom_Count = 0;

                break;
            default:
                break;
        }



        Set_Weapon_Decom_Val();
    }

    public void Weapon_Decom()
    {
        int int_grade = Array.FindIndex(grade, i => i == my_data["grade"].ToString());

        int grade_val = grade_decom[int_grade];


        BackEndDataManager.instance.Set_Item(Item_Type.weapon_limit_stone_d + int_grade,
                    Weapon_.Decom_Count * grade_val, Calculate_Type.plus);

        my_Info.int_val -= Weapon_.Decom_Count;

        List<Weapon_Panel> weapon_s = new List<Weapon_Panel>();

        switch (Weapon_.Weapon_Content)
        {
            case Weapon_Content.Sword:
                weapon_s = popup_Sword.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Game_info_.Set_Game_Info(Game_Info_Type.weapon_decom, Weapon_.Decom_Count);

                break;
            case Weapon_Content.Shield:
                weapon_s = popup_Shield.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Game_info_.Set_Game_Info(Game_Info_Type.shield_decom, Weapon_.Decom_Count);

                break;
            case Weapon_Content.Accessory:
                weapon_s = popup_Accessory.GetComponentsInChildren<Weapon_Panel>(true).ToList();
                Game_info_.Set_Game_Info(Game_Info_Type.accessory_decom, Weapon_.Decom_Count);

                break;
            case Weapon_Content.Costume:
                break;
            default:
                break;
        }

        weapon_s.Find(x => x.item_num.Equals(Weapon_.Select_Weapon)).Set_Weapon_Val();

        BackEndDataManager.instance.Save_Weapon_Data();

        Set_Weapon_Decom();

    }

    #endregion

    #endregion

    #region Job

    public void Set_Job_Panel()
    {
        foreach (var item in BackEndDataManager.instance.job_csv_data)
        {
            Job_Panel job = Instantiate(Job_Panel, scroll_Job.transform
          .Find("Viewport/Content")).GetComponent<Job_Panel>();

            job.Find_obj(item);
            job_Panels.Add(job);
        }

        Job_.Job_Lv = Character_Lv.lv_1;

        StartCoroutine("Check_Job");
    }

    public void Change_Job_Lv(Character_Lv _Lv)
    {
        Job_.Job_Lv = _Lv;

        foreach (var item in job_Panels)
        {
            item.Set_Item_Upgrade(_Lv);
        }
    }

    public void Check_Btn()
    {
        if (icon_Content.Equals(Icon_Content.Job))
        {
            foreach (var item in job_Panels)
            {
                item.Set_Btn();
            }
        }

    }


    IEnumerator Check_Job()
    {
        while (true)
        {
            foreach (var job_ in BackEndDataManager.instance.Job_Data.job_info)
            {
                Dictionary<string, object> data = BackEndDataManager.instance.job_csv_data[job_.int_num];

                int job_time = (int)data["job_time"];

                if (job_.str_time == "")
                {
                    job_.str_time = BackEndDataManager.instance.WebCheck().AddSeconds(job_time + 1).ToString();
                    BackEndDataManager.instance.Save_Job_Data();
                }

                DateTime GiftTime = DateTime.Parse(job_.str_time);

                TimeSpan LateTime = GiftTime - BackEndDataManager.instance.WebCheck();

                if (LateTime.TotalSeconds < 1)
                {
                    job_.str_time = BackEndDataManager.instance.WebCheck().AddSeconds(job_time + 1).ToString();
                    BackEndDataManager.instance.Save_Job_Data();

                    GiftTime = DateTime.Parse(job_.str_time);

                    double reweard_val = (LateTime.TotalSeconds / job_time);

                    BackEndDataManager.instance.Set_Item((Item_Type)data["reward_0"], Job_.Get_Reward(job_.int_num) * (int)(Math.Abs(reweard_val) + 1), Calculate_Type.plus);

                }
            }

            yield return new WaitForSeconds(0.2f);

        }
    }


    #endregion

    #region Totem

    public void Set_Totem_Panel()
    {
        foreach (var item in BackEndDataManager.instance.totem_csv_data)
        {
            Totem_Panel Totem = Instantiate(totem_Panel, scroll_Totem.transform
          .Find("Viewport/Content")).GetComponent<Totem_Panel>();

            Totem.Find_obj(item);
            totem_Panels.Add(Totem);
        }

        Totem_.totem_Lv = Character_Lv.lv_1;

    }

    public void Check_Totem_buy()
    {
        foreach (var item in totem_Panels)
        {
            item.Check_Btn();
        }

    }

    public void Check_Totem_Item(Character_Lv _Lv)
    {
        Totem_.totem_Lv = _Lv;

        foreach (var item in totem_Panels)
        {
            item.Set_Item();
        }

    }

    #endregion

    #region SettingPopup

    public void Setting_Repear()
    {
        Check_Repear(true);
    }

    public void Check_Repear(bool check)
    {
        txt_repear_success.gameObject.SetActive(check);
        txt_repear_fail.gameObject.SetActive(!check);

        PopupManager.Open_Popup(RepaerPopup);
    }

    public void Setting_Language()
    {
        PopupManager.Open_Popup(LanguagePopup);

    }

    public void Setting_Cupon()
    {
        cupon.SetActive(true);
        cupon_success.SetActive(false);
        cupon_fail.SetActive(false);

        PopupManager.Open_Popup(CuponPopup);

    }


    public void Check_Cupon()
    {
        BackEndDataManager.instance.Check_Cupon(input_cupon.text);

        cupon.SetActive(false);
    }

    public void Result_Coupon(Cupon_Type cupon_Type)
    {

        switch (cupon_Type)
        {
            case Cupon_Type.Sussece:
                cupon_success.SetActive(true);
                break;
            case Cupon_Type.fail:
                cupon_fail.SetActive(true);
                txt_none_fail.SetActive(true);
                txt_overlap_fail.SetActive(false);

                break;
            case Cupon_Type.overlab:
                cupon_fail.SetActive(true);
                txt_none_fail.SetActive(false);
                txt_overlap_fail.SetActive(true);
                break;

            default:
                break;

        }
    }

    public void Setting_Power(bool Active)
    {

        obj_Btns.SetActive(!Active);
        obj_Top.SetActive(!Active);
        obj_Content.SetActive(!Active);
        obj_Icon.SetActive(!Active);

        PowerPopup.SetActive(Active);

        if (Active)
            StartCoroutine("Co_Power_Time");
        else
            StopCoroutine("Co_Power_Time");
    }

    IEnumerator Co_Power_Time()
    {
        txt_power_time.DOFade(0.5f, 1).SetLoops(-1, LoopType.Yoyo);

        while (true)
        {

            txt_power_time.text = string.Format("{0:00}:{1:00}", BackEndDataManager.instance.WebCheck().Hour,
                BackEndDataManager.instance.WebCheck().Minute);

            yield return new WaitForSeconds(1f);
        }
    }

    public void Set_Music()
    {
        txt_setting_music_off.gameObject.SetActive(PlayerPrefs.GetInt("music", 1) == 0);
        txt_setting_music_on.gameObject.SetActive(PlayerPrefs.GetInt("music", 1) == 1);
    }

    public void Setting_Music()
    {
        PlayerPrefs.SetInt("music", PlayerPrefs.GetInt("music", 1) == 1 ? 0 : 1);
        Set_Music();
    }

    public void Set_Effect()
    {
        txt_setting_effect_off.gameObject.SetActive(PlayerPrefs.GetInt("effect", 1) == 0);
        txt_setting_effect_on.gameObject.SetActive(PlayerPrefs.GetInt("effect", 1) == 1);
    }


    public void Setting_Effect()
    {
        PlayerPrefs.SetInt("effect", PlayerPrefs.GetInt("effect", 1) == 1 ? 0 : 1);
        Set_Effect();
    }


    public void Set_Push()
    {
        txt_setting_push_off.gameObject.SetActive(PlayerPrefs.GetInt("push", 1) == 0);
        txt_setting_push_on.gameObject.SetActive(PlayerPrefs.GetInt("push", 1) == 1);
    }


    public void Setting_Push()
    {
        PlayerPrefs.SetInt("push", PlayerPrefs.GetInt("push", 1) == 1 ? 0 : 1);
        Set_Push();

    }


    public void Set_Grapic()
    {
        txt_setting_grapic_off.gameObject.SetActive(PlayerPrefs.GetInt("grapic", 1) == 0);
        txt_setting_grapic_on.gameObject.SetActive(PlayerPrefs.GetInt("grapic", 1) == 1);
    }

    public void Setting_Grapic()
    {
        PlayerPrefs.SetInt("grapic", PlayerPrefs.GetInt("grapic", 1) == 1 ? 0 : 1);
        Set_Grapic();
    }

    public void Setting_Terms()
    {
        if (Application.systemLanguage.Equals(SystemLanguage.Korean))
            Application.OpenURL("https://breaktimemobile.com/entry/이용약관?category=869827");
        else
            Application.OpenURL("https://breaktimemobile.com/entry/TERMS-OF-SERVICE");

    }

    public void Setting_Privacy()
    {
        if (Application.systemLanguage.Equals(SystemLanguage.Korean))
            Application.OpenURL("https://breaktimemobile.com/entry/개인정보-처리방침?category=869827");
        else
            Application.OpenURL("https://breaktimemobile.com/entry/Privacy-Policy?category=869827");
    }

    public void Setting_Mail()
    {
        string str = "help.breaktime@gmail.com";
        string str2 = "Puzzle kingdom";
        Application.OpenURL("mailto:" + str + "?subject=" + str2);
    }

    public void Setting_Exit()
    {
        PopupManager.Open_Popup(ExitPopup);

    }

    public void App_Exit()
    {
        Debug.Log("게임 종료");
        Application.Quit();

    }


    public void Setting_Help()
    {
        PopupManager.Open_Popup(HelpPopup);

    }


    public void Set_Version()
    {
        txt_setting_version.text = "ver " + Application.version;
    }

    #endregion

    #region Post

    public void Set_Post_Panel()
    {
        foreach (var item in BackEndDataManager.instance.Post_Data.post_Info)
        {
            Post_Panel post = Instantiate(Post_Panel, scroll_Post.transform
          .Find("Viewport/Content")).GetComponent<Post_Panel>();

            post.Set_Post(item);
        }

        Totem_.totem_Lv = Character_Lv.lv_1;

    }

    #endregion

    #region Progress_Reward
    //텍스트
    public void Set_Progress_Reward_Txt()
    {
        if (BackEndDataManager.instance.Player_Data.int_progress_reward > 4)
        {
            btn_progress_reward.gameObject.SetActive(false);

        }
        else
        {

            if (BackEndDataManager.instance.Player_Data.int_progress_reward_type == -1)
            {
                Reset_Progress_Reward();
                return;
            }
            else
            {

                btn_progress_reward.gameObject.SetActive(true);

                int my = BackEndDataManager.instance.Player_Data.int_progress_reward_type;
                Dictionary<string, object> pairs = BackEndDataManager.instance.progress_reward_csv_data[my];

                txt_progress_name.text = pairs["name"].ToString();

                int max = (int)pairs["max"];

                txt_progress_val.text = string.Format("{0}/{1}", BackEndDataManager.instance.Player_Data.int_progress_reward_val
                    , pairs["max"].ToString());

                btn_progress_reward.interactable = BackEndDataManager.instance.Player_Data.int_progress_reward_val >= max;

            }

        }
    }

    //체크
    public void Check_Progress_Reward(Progress_Reward_Type _Reward_Type, int val)
    {
        Progress_Reward_Type my = (Progress_Reward_Type)BackEndDataManager.instance.Player_Data.int_progress_reward_type;

        if (my.Equals(_Reward_Type))
        {
            BackEndDataManager.instance.Player_Data.int_progress_reward_val += 1;
            BackEndDataManager.instance.Save_Player_Data();
        }

        int max = (int)BackEndDataManager.instance.progress_reward_csv_data[(int)my]["max"];

        txt_progress_val.text = string.Format("{0}/{1}",
            BackEndDataManager.instance.Player_Data.int_progress_reward_val, max);

        btn_progress_reward.interactable = BackEndDataManager.instance.Player_Data.int_progress_reward_val >= max;

    }

    public void Add_Progress_Reward()
    {
        int my = BackEndDataManager.instance.Player_Data.int_progress_reward_type;

        Dictionary<string, object> pairs = BackEndDataManager.instance.progress_reward_csv_data[my];

        int reward_type = (int)pairs["reward_type_0"];
        int reward_val = (int)pairs["reward_val_0"];

        BackEndDataManager.instance.Set_Item((Item_Type)reward_type, reward_val, Calculate_Type.plus);

        BackEndDataManager.instance.Player_Data.int_progress_reward += 1;
        BackEndDataManager.instance.Save_Player_Data();

        Reset_Progress_Reward();
    }

    //얻음
    public void Reset_Progress_Reward()
    {
        int ran = Random.Range(0, BackEndDataManager.instance.progress_reward_csv_data.Count);
        Dictionary<string, object> pairs = BackEndDataManager.instance.progress_reward_csv_data[ran];

        BackEndDataManager.instance.Player_Data.int_progress_reward_type = ran;
        BackEndDataManager.instance.Player_Data.int_progress_reward_val = 0;
        BackEndDataManager.instance.Save_Player_Data();

        Set_Progress_Reward_Txt();
    }

    #endregion


    #region Quest

    List<Quest_Panel> daily_quest_panel = new List<Quest_Panel>();
    List<Quest_Panel> accumulate_quest_panel = new List<Quest_Panel>();

    private void Set_Quest_Panel()
    {

        foreach (var item in BackEndDataManager.instance.daily_quest_csv_data)
        {
            Quest_Panel obj = Instantiate(Quest_Panel, scroll_daily_quset.transform
          .Find("Viewport/Content")).GetComponent<Quest_Panel>();

            obj.Set_Quest(item, Quest_Type.daily);
            daily_quest_panel.Add(obj);
        }

        foreach (var item in BackEndDataManager.instance.accumulate_quest_csv_data)
        {
            Quest_Panel obj = Instantiate(Quest_Panel, scroll_accumulate_quest.transform
          .Find("Viewport/Content")).GetComponent<Quest_Panel>();

            obj.Set_Quest(item, Quest_Type.accumulate);
            accumulate_quest_panel.Add(obj);

        }

        StartCoroutine("Co_Quest_Time");

    }

    public void Set_Quest_(Quest_Type quest_Type, int num)
    {
        switch (quest_Type)
        {
            case Quest_Type.daily:
                daily_quest_panel.Find(x => x.num.Equals(num)).Set_Val();

                break;
            case Quest_Type.accumulate:


                accumulate_quest_panel.Find(x => x.game_info_type.Equals(num))?.Set_Val();

                break;
            default:
                break;
        }
    }

    IEnumerator Co_Quest_Time()
    {
        while (true)
        {

            TimeSpan now = new DateTime(BackEndDataManager.instance.WebCheck().Year,
                BackEndDataManager.instance.WebCheck().Month,
                BackEndDataManager.instance.WebCheck().AddDays(1).Day, 0, 0, 0) - BackEndDataManager.instance.WebCheck();

            txt_quset_time.text = string.Format("{0} {1:00}:{2:00}:{3:00}", "남은시간", now.Hours, now.Minutes, now.Seconds);

            yield return new WaitForSeconds(1f);
        }
    }

    #endregion

    #region QuestItemPopup

    public void Set_QuestItem(Item_Type type, BigInteger val)
    {
        img_quset_item.sprite = Utill.Get_Item_Sp(type);
        txt_quset_item.text = val.ToString();

        StopCoroutine("Co_QuestItem_Exit");

        StartCoroutine("Co_QuestItem_Exit");
    }

    IEnumerator Co_QuestItem_Exit()
    {
        QuestItemPopup.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        QuestItemPopup.SetActive(false);
    }

    private void QuestItem_Exit()
    {
        StopCoroutine("Co_QuestItem_Exit");
        QuestItemPopup.SetActive(false);

    }

    #endregion

    IEnumerator Co_Join_Time()
    {
        while (true)
        {
            Game_info_.Set_Game_Info(Game_Info_Type.join_time, 1);
            yield return new WaitForSeconds(1.0f);
        }
    }




    #region Gift

    public void Set_Gift()
    {
        Debug.Log("한번누름..");
        Item_s.Get_Random_Gift_Item();

        img_gift.sprite = Utill.Get_Item_Sp((Item_Type)Item_s.selet_item.item_num);
        txt_gift.text = Item_s.selet_item.val.ToString();

        GiftPopup.SetActive(true);

        DateTime Web = BackEndDataManager.instance.WebCheck();

        BackEndDataManager.instance.Player_Data.str_Gift_Check = Web.AddHours(1).ToString();
        BackEndDataManager.instance.Save_Player_Data();

        Check_Gift();
    }

    public void Get_Ads_Gift()
    {
        Item item = Item_s.selet_item;
        BackEndDataManager.instance.Set_Item((Item_Type)item.item_num, item.val * 2, Calculate_Type.plus);

        GiftPopup.SetActive(false);

    }

    public void Get_Gift()
    {
        Item item = Item_s.selet_item;
        BackEndDataManager.instance.Set_Item((Item_Type)item.item_num, item.val, Calculate_Type.plus);

        GiftPopup.SetActive(false);

    }

    public void Check_Gift()
    {
        DateTime Web = BackEndDataManager.instance.WebCheck();

        if (String.IsNullOrEmpty(BackEndDataManager.instance.Player_Data.str_Gift_Check))
        {
            btn_gift.interactable = true;
            txt_gift_time.gameObject.SetActive(false);
        }
        else
        {
            DateTime date = DateTime.Parse(BackEndDataManager.instance.Player_Data.str_Gift_Check);

            TimeSpan timeSpan = date - Web;

            if (timeSpan.TotalSeconds < 0)
            {
                btn_gift.interactable = true;
                txt_gift_time.gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine("Co_Gift_Time");
                btn_gift.interactable = false;
                txt_gift_time.gameObject.SetActive(true);
            }


        }
    }

    IEnumerator Co_Gift_Time()
    {
        while (true)
        {
            DateTime Web = BackEndDataManager.instance.WebCheck();

            DateTime date = DateTime.Parse(BackEndDataManager.instance.Player_Data.str_Gift_Check);

            TimeSpan timeSpan = date - Web;

            if (timeSpan.TotalSeconds < 0)
            {
                btn_gift.interactable = true;
                txt_gift_time.gameObject.SetActive(false);
                StopCoroutine("Co_Gift_Time");
            }
            else
            {
                txt_gift_time.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    #endregion

    #region Calendar

    public void Set_Calendar()
    {

        for (int i = 0; i < calendar_Panels.Count; i++)
        {
            calendar_Panels[i].Set_Item(i);
        }

        Check_Calendar();

    }

    public void Check_Calendar()
    {
        if (!BackEndDataManager.instance.Player_Data.is_calendar)
        {
            PopupManager.Open_Popup(CalendarPopup);

            
        }

        btn_calendar_get.interactable = !BackEndDataManager.instance.Player_Data.is_calendar && BackEndDataManager.instance.Player_Data.int_calendar < 25;


    }

    public void Get_Calendar()
    {
        BackEndDataManager.instance.Player_Data.is_calendar = true;
        BackEndDataManager.instance.Player_Data.int_calendar += 1;

        calendar_Panels.Find(x => x.int_day.Equals(BackEndDataManager.instance.Player_Data.int_calendar-1)).Check();

        BackEndDataManager.instance.Save_Player_Data();
        Check_Calendar();
    }

    #endregion

}
