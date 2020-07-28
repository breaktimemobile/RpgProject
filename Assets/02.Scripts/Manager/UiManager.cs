using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    private GameObject NickNamePopup;
    private GameObject DungeonPopup;
    private GameObject InventoryPopup;
    private GameObject WeaponPopup;

    private GameObject obj_Top;
    public GameObject obj_Stage;
    private GameObject obj_Content;
    private GameObject obj_Icon;

    private GameObject Content_Content;
    private GameObject Content_Character;
    private GameObject Content_Pet;
    private GameObject Content_Weapon;
    private GameObject Content_Job;
    private GameObject Content_Relics;
    private GameObject Content_Shop;

    #region obj_Top

    private Image img_Character;
    private Text txt_Lv;
    private Text txt_NickName;
    private Slider slider_Exp;

    private Text txt_Steel_Val;
    private Text txt_Coin_Val;
    private Text txt_Dia_Val;

    #endregion

    #region obj_Stage

    private Text txt_State_Chapter;
    private Text txt_State_Stage;

    public Slider slider_Boss_Timer;
    public Text txt_Boss_Timer;

    public Button btn_Boss;
    public Button btn_Boss_Exit;
    public Button btn_Inventory;

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

    private GameObject popup_Weapon;
    private GameObject popup_Shield;
    private GameObject popup_Accessory;
    private GameObject popup_Costume;

    private Weapon_Panel[] Weapon_Panels;
    private Weapon_Panel[] Shield_Panels;
    private Weapon_Panel[] Accessory_Panels;
    private Weapon_Panel[] Costume_Panels;

    #endregion

    #region  popup_State;

    private Text txt_State_Name;
    private Text txt_State_Lv;

    private Transform pos_Character;

    private Button btn_Lv_1;
    private Button btn_Lv_10;
    private Button btn_Lv_100;

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

    private Button btn_Skill_Lv1;
    private Button btn_Skill_Lv10;
    private Button btn_Skill_Lv100;

    private Text txt_Skill_Soul_Val;

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

    #region DungeonPopup

    //private InputField Input_NickName;
    //private Button btn_NickName_Ok;
    //private GameObject txt_NickName_Fail;

    #endregion

    #region InvantoryPopup

    private List<Inventory_Panel> Inventory_Panels = new List<Inventory_Panel>();
    private Button btn_Invantory_Close;

    #endregion

    #region WeaponPopup

    private Button btn_Weapon_Info;
    private Button btn_Weapon_Upgrade;
    private Button btn_Weapon_Mix;
    private Button btn_Weapon_Roon;
    private Button btn_Weapon_Decom;

    private GameObject content_Weapon_Info;
    private GameObject content_Weapon_Upgrade;
    private GameObject content_Weapon_Mix;
    private GameObject content_Weapon_Roon;
    private GameObject content_Weapon_Decom;

    #endregion


    #region Prefabs

    public GameObject txt_Damege;
    public GameObject txt_Critical_Damege;
    public GameObject weapon_Panel;
    public GameObject Inventory_Panel;
    public GameObject Skill_Panel;

    #endregion

    private void Awake()
    {
        instance = this;

        Find_Obj();
        AddListener();

    }

    private void Find_Obj()
    {

        Transform Game = GameObject.Find("Game").transform;
        Transform Popup = GameObject.Find("Popup").transform;

        NickNamePopup = Popup.Find("NickNamePopup").gameObject;
        DungeonPopup = Popup.Find("DungeonPopup").gameObject;
        InventoryPopup = Popup.Find("InventoryPopup").gameObject;
        WeaponPopup = Popup.Find("WeaponPopup").gameObject;

        obj_Top = Game.Find("obj_Top").gameObject;
        obj_Stage = Game.Find("obj_Stage").gameObject;
        obj_Content = Game.Find("obj_Content").gameObject;
        obj_Icon = Game.Find("obj_Icon").gameObject;

        #region obj_Top

        img_Character = obj_Top.transform.Find("Profil/img_Character").GetComponent<Image>();
        txt_Lv = obj_Top.transform.Find("Profil/txt_Lv").GetComponent<Text>();
        txt_NickName = obj_Top.transform.Find("Profil/txt_NickName").GetComponent<Text>();
        slider_Exp = obj_Top.transform.Find("Profil/slider_Exp").GetComponent<Slider>();

        txt_Steel_Val = obj_Top.transform.Find("Goods/Steel/txt_Steel_Val").GetComponent<Text>();
        txt_Coin_Val = obj_Top.transform.Find("Goods/Coin/txt_Coin_Val").GetComponent<Text>();
        txt_Dia_Val = obj_Top.transform.Find("Goods/Dia/txt_Dia_Val").GetComponent<Text>();

        #endregion

        #region obj_Stage

        txt_State_Chapter = obj_Stage.transform.Find("state_Stage/txt_State_Chapter").GetComponent<Text>();
        txt_State_Stage = obj_Stage.transform.Find("state_Stage/txt_State_Stage").GetComponent<Text>();

        slider_Boss_Timer = obj_Stage.transform.Find("slider_Boss_Timer").GetComponent<Slider>();
        txt_Boss_Timer = slider_Boss_Timer.transform.Find("txt_Boss_Timer").GetComponent<Text>();

        btn_Boss = obj_Stage.transform.Find("Stage_Content/btn_Boss").GetComponent<Button>();
        btn_Boss_Exit = obj_Stage.transform.Find("Stage_Content/btn_Boss_Exit").GetComponent<Button>();
        btn_Inventory = obj_Stage.transform.Find("Stage_Content/btn_Inventory").GetComponent<Button>();

        #endregion

        #region obj_Content

        Content_Content = obj_Content.transform.Find("Content_Content").gameObject;
        Content_Character = obj_Content.transform.Find("Content_Character").gameObject;
        Content_Pet = obj_Content.transform.Find("Content_Pet").gameObject;
        Content_Weapon = obj_Content.transform.Find("Content_Weapon").gameObject;
        Content_Job = obj_Content.transform.Find("Content_Job").gameObject;
        Content_Relics = obj_Content.transform.Find("Content_Relics").gameObject;
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

        popup_Weapon = Content_Weapon.transform.Find("contents/popup_Weapon").gameObject;
        popup_Shield = Content_Weapon.transform.Find("contents/popup_Shield").gameObject;
        popup_Accessory = Content_Weapon.transform.Find("contents/popup_Accessory").gameObject;
        popup_Costume = Content_Weapon.transform.Find("contents/popup_Costume").gameObject;

        Weapon_Panels = popup_Weapon.GetComponentsInChildren<Weapon_Panel>();

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

        txt_State_Name = popup_State.transform.Find("img_State_Bg/txt_State_Name").GetComponent<Text>();
        txt_State_Lv = popup_State.transform.Find("img_State_Bg/txt_State_Lv").GetComponent<Text>();

        pos_Character = popup_State.transform.Find("img_Chatacter_Bg/pos_Character");

        btn_Lv_1 = popup_State.transform.Find("lv_Ups/btn_Lv_1").GetComponent<Button>();
        btn_Lv_10 = popup_State.transform.Find("lv_Ups/btn_Lv_10").GetComponent<Button>();
        btn_Lv_100 = popup_State.transform.Find("lv_Ups/btn_Lv_100").GetComponent<Button>();

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

        btn_Skill_Lv1 = popup_Skill.transform.Find("btn_Skill_Lv1").GetComponent<Button>();
        btn_Skill_Lv10 = popup_Skill.transform.Find("btn_Skill_Lv10").GetComponent<Button>();
        btn_Skill_Lv100 = popup_Skill.transform.Find("btn_Skill_Lv100").GetComponent<Button>();

        txt_Skill_Soul_Val = popup_Skill.transform.Find("Soul_stone/txt_Skill_Soul_Val").GetComponent<Text>();

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

        btn_Weapon_Info = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info").GetComponent<Button>();
        btn_Weapon_Upgrade = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info").GetComponent<Button>();
        btn_Weapon_Mix = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info").GetComponent<Button>();
        btn_Weapon_Roon = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info").GetComponent<Button>();
        btn_Weapon_Decom = WeaponPopup.transform.Find("btn_grids/btn_Weapon_Info").GetComponent<Button>();

        content_Weapon_Info = WeaponPopup.transform.Find("contents/content_Weapon_Info").gameObject;
        content_Weapon_Upgrade = WeaponPopup.transform.Find("contents/content_Weapon_Upgrade").gameObject;
        content_Weapon_Mix = WeaponPopup.transform.Find("contents/content_Weapon_Mix").gameObject;
        content_Weapon_Roon = WeaponPopup.transform.Find("contents/content_Weapon_Roon").gameObject;
        content_Weapon_Decom = WeaponPopup.transform.Find("contents/content_Weapon_Decom").gameObject;

        #endregion
    }

    private void AddListener()
    {
        btn_NickName_Ok.onClick.AddListener(() => Check_Nickname());

        #region Content_Character

        btn_State.onClick.AddListener(() => Change_Content_Content(Character_Contnet.State));
        btn_Skill.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Skill));
        btn_Upgrade.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Upgrade));
        btn_Limit.onClick.AddListener(() => Change_Content_Content(Character_Contnet.Limit));

        #endregion

        #region Content_Weapon

        btn_Weapon.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Weapon));
        btn_Shield.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Shield));
        btn_Accessory.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Accessory));
        btn_Costume.onClick.AddListener(() => Change_Weapon_Contnet(Weapon_Content.Costume));

        #endregion

        btn_Boss.onClick.AddListener(() => PlayManager.instance.Start_Boss_Stage());
        btn_Boss_Exit.onClick.AddListener(() => PlayManager.instance.Stop_Boss_Timer(true));
        btn_Inventory.onClick.AddListener(() => PopupManager.Open_Popup(InventoryPopup));

        btn_Lv_1.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_1));
        btn_Lv_10.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_10));
        btn_Lv_100.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_100));

        btn_Icon_Content.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Content));
        btn_Icon_Character.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Character));
        btn_Icon_Pet.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Pet));
        btn_Icon_Weapon.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Weapon));
        btn_Icon_Job.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Job));
        btn_Icon_Relics.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Relics));
        btn_Icon_Shop.onClick.AddListener(() => Change_Icon_Content(Icon_Content.Shop));

        btn_Invantory_Close.onClick.AddListener(() => PopupManager.Close_Popup());
        
        btn_Skill_Lv1.onClick.AddListener(() => Set_Skill_Val(1));
        btn_Skill_Lv10.onClick.AddListener(() => Set_Skill_Val(10));
        btn_Skill_Lv100.onClick.AddListener(() => Set_Skill_Val(100));

        #region WeaponPopup

        btn_Weapon_Info.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.info));
        btn_Weapon_Upgrade.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.upgrade));
        btn_Weapon_Mix.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.mix));
        btn_Weapon_Roon.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.roon));
        btn_Weapon_Decom.onClick.AddListener(() => Change_Weapon_Popup(Weapon_Popup.decom));

        #endregion
    }

    private void Start()
    {
        Check_Nick_Popup();
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

    public void Set_Ui()
    {

        Set_Img_Character();
        Set_Txt_Lv();
        Set_Txt_NickName();
        Set_Txt_Exp();
        Set_Txt_Steel();
        Set_Txt_Coin();
        Set_Txt_Dia();
        Set_Txt_Chapter();
        Set_Txt_Stage();
        Set_Txt_Soul_Stone();

        Set_Character_Name();
        Set_Character_Lv();
        Set_Character_obj();
        Set_Character_Stat();
        Set_Buy_Lv();

        Set_Inventory();
        Set_Weapon_Popup();
        Set_Skill_Popup();
    }

    #region PlayerUI 세팅

    public void Set_Img_Character()
    {
        img_Character.sprite = null;
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
        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.Get_Item(Item_Type.steel));
        txt_Steel_Val.text = GetGoldString(big);
    }

    public void Set_Txt_Coin()
    {
        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.Get_Item(Item_Type.coin));
        txt_Coin_Val.text = GetGoldString(big);
    }

    public void Set_Txt_Dia()
    {
        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.Get_Item(Item_Type.crystal));
        txt_Dia_Val.text = GetGoldString(big);
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
            0);

    }

    public void Set_Character_obj()
    {
        Instantiate(PlayManager.instance.
            Characters[BackEndDataManager.instance.Character_Data.Int_character_Num],
            pos_Character);
    }

    public void Set_Buy_Lv()
    {
        ulong lv = (ulong)BackEndDataManager.instance.Character_Data.int_character_Lv;
        ulong lv_1 = 500 + (500 / 20) * (lv - 1);


        txt_Lv_1_Val.text = GetGoldString(lv_1);
        txt_Lv_10_Val.text = GetGoldString(lv_1 * 10);
        txt_Lv_100_Val.text = GetGoldString(lv_1 * 100);

        btn_Lv_1.interactable = BackEndDataManager.instance.Int_coin >= lv_1;
        btn_Lv_10.interactable = BackEndDataManager.instance.Int_coin >= lv_1 * 10;
        btn_Lv_100.interactable = BackEndDataManager.instance.Int_coin >= lv_1 * 100;


    }

    #endregion

    #region Popup 

    public void Change_Icon_Content(Icon_Content popup)
    {
        Content_Content.SetActive(popup.Equals(Icon_Content.Content));
        Content_Character.SetActive(popup.Equals(Icon_Content.Character));
        Content_Pet.SetActive(popup.Equals(Icon_Content.Pet));
        Content_Weapon.SetActive(popup.Equals(Icon_Content.Weapon));
        Content_Job.SetActive(popup.Equals(Icon_Content.Job));
        Content_Relics.SetActive(popup.Equals(Icon_Content.Relics));
        Content_Shop.SetActive(popup.Equals(Icon_Content.Shop));

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
        popup_Weapon.SetActive(popup.Equals(Weapon_Content.Weapon));
        popup_Shield.SetActive(popup.Equals(Weapon_Content.Shield));
        popup_Accessory.SetActive(popup.Equals(Weapon_Content.Accessory));
        popup_Costume.SetActive(popup.Equals(Weapon_Content.Costume));
    }

    public void Change_Weapon_Popup(Weapon_Popup popup)
    {
        content_Weapon_Info.SetActive(popup.Equals(Weapon_Popup.info));
        content_Weapon_Upgrade.SetActive(popup.Equals(Weapon_Popup.upgrade));
        content_Weapon_Mix.SetActive(popup.Equals(Weapon_Popup.mix));
        content_Weapon_Roon.SetActive(popup.Equals(Weapon_Popup.roon));
        content_Weapon_Decom.SetActive(popup.Equals(Weapon_Popup.decom));

    }

    #endregion

    #region Character

    public void Set_Character_Stat()
    {
        txt_State_Atk_Val.text = GetGoldString(Player_stat.int_Atk);
        txt_State_Hp_Val.text = GetGoldString(Player_stat.int_Hp);
        txt_State_Atk_Speed_Val.text = Player_stat.int_Atk_Speed.ToString();
        txt_State_Critical_Val.text = string.Format("{0}{1}", Player_stat.int_Critical_Damege, "%");
        txt_State_Critical_Percent_Val.text = string.Format("{0}{1}", Player_stat.int_Critical_Percent, "%");
        txt_State_Speed_Val.text = string.Format("{0}{1}", Player_stat.int_Atk_Speed, "%");
    }

    #region Skill

    public void Set_Skill_Popup()
    {
        Debug.Log(BackEndDataManager.instance.skill_csv_data.Count);

        foreach (var item in BackEndDataManager.instance.skill_csv_data)
        {

            
            Skill_Panel skill_ = Instantiate(Skill_Panel, popup_Skill.transform
                .Find("scroll_skill/Viewport/Content")).GetComponent<Skill_Panel>();

            skill_Panels.Add(skill_);

            skill_.Set_Skill_Item(item);

        }

    }


    public void Set_Txt_Soul_Stone()
    {

        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.Get_Item(Item_Type.soul_stone));
        txt_Skill_Soul_Val.text = GetGoldString(big);

    }

    public void Set_Skill_Val(int up_lv)
    {
        foreach (var item in skill_Panels)
        {
            item.Set_Upgrade(up_lv);
        }
        
    }

    #endregion

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

            obj.GetComponent<Inventory_Panel>().Set_Inventory_Item((Item_Type)item.type,
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

            obj.GetComponent<Inventory_Panel>().Set_Inventory_Item(i,
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

    public void Set_Weapon_Popup()
    {
        foreach (var item in BackEndDataManager.instance.weapon_csv_data)
        {

            Weapon_Panel weapon_ = Instantiate(weapon_Panel, popup_Weapon.transform
                .Find("scroll_weapon/Viewport/Content")).GetComponent<Weapon_Panel>();

            weapon_.Set_Weapon_Item(item);

        }

    }

    #endregion
}
