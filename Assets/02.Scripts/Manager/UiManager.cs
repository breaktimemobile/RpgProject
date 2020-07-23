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

    private Inventory_Panel[] Inventory_Panels;
    private Button btn_Invantory_Close;

    //scroll_Invantory


    #endregion


    #region Prefabs

    public GameObject txt_Damege;
    public GameObject txt_Critical_Damege;

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

        #region NickNamePopup

        Input_NickName = NickNamePopup.transform.Find("Input_NickName").GetComponent<InputField>();

        btn_NickName_Ok = NickNamePopup.transform.Find("btn_NickName_Ok").GetComponent<Button>();
        txt_NickName_Fail = NickNamePopup.transform.Find("txt_NickName_Fail").gameObject;

        #endregion

        #region InvantoryPopup

        Inventory_Panels = InventoryPopup.transform.GetComponentsInChildren<Inventory_Panel>();
        btn_Invantory_Close = InventoryPopup.transform.Find("btn_Invantory_Close").GetComponent<Button>();


        #endregion
    }

    private void AddListener()
    {
        btn_NickName_Ok.onClick.AddListener(() => Check_Nickname());

        btn_State.onClick.AddListener(() => Change_Content_Popup(Character_Popup.State));
        btn_Skill.onClick.AddListener(() => Change_Content_Popup(Character_Popup.Skill));
        btn_Upgrade.onClick.AddListener(() => Change_Content_Popup(Character_Popup.Upgrade));
        btn_Limit.onClick.AddListener(() => Change_Content_Popup(Character_Popup.Limit));

        btn_Boss.onClick.AddListener(() => PlayManager.instance.Start_Boss_Stage());
        btn_Boss_Exit.onClick.AddListener(() => PlayManager.instance.Stop_Boss_Timer(true));
        btn_Inventory.onClick.AddListener(() => PopupManager.Open_Popup(InventoryPopup));

        btn_Lv_1.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_1));
        btn_Lv_10.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_10));
        btn_Lv_100.onClick.AddListener(() => BackEndDataManager.instance.Buy_Character_Lv(Character_Lv.lv_100));

        btn_Icon_Content.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Content));
        btn_Icon_Character.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Character));
        btn_Icon_Pet.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Pet));
        btn_Icon_Weapon.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Weapon));
        btn_Icon_Job.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Job));
        btn_Icon_Relics.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Relics));
        btn_Icon_Shop.onClick.AddListener(() => Change_Icon_Popup(Icon_Popup.Shop));

        btn_Invantory_Close.onClick.AddListener(() => PopupManager.Close_Popup());


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
        Debug.Log(gold);

        if (gold >= 1000)
        {
            BigInteger total_Gold = gold;

            int count = gold.ToString("n0").Split(',').Length - 1;

            for (int i = 0; i < count - 1; i++)
            {
                gold /= 1000;
            }

            float so = (int)gold / 1000.0f;

            return so.ToString("n1") + (char)(64 + count);
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

        Set_Character_Name();
        Set_Character_Lv();
        Set_Character_obj();
        Set_Character_Stat();
        Set_Buy_Lv();

        Set_Inventory();
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
        if (BackEndDataManager.instance.Player_Data.int_exp == 10)
        {
            BackEndDataManager.instance.Player_Data.int_exp = 0;
            BackEndDataManager.instance.Player_Data.int_lv += 1;

            slider_Exp.value = 0;
            Set_Txt_Lv();

        }
        else
        {
            slider_Exp.value = BackEndDataManager.instance.Player_Data.int_exp / 10F;
        }


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

    public void Change_Icon_Popup(Icon_Popup popup)
    {
        Content_Content.SetActive(popup.Equals(Icon_Popup.Content));
        Content_Character.SetActive(popup.Equals(Icon_Popup.Character));
        Content_Pet.SetActive(popup.Equals(Icon_Popup.Pet));
        Content_Weapon.SetActive(popup.Equals(Icon_Popup.Weapon));
        Content_Job.SetActive(popup.Equals(Icon_Popup.Job));
        Content_Relics.SetActive(popup.Equals(Icon_Popup.Relics));
        Content_Shop.SetActive(popup.Equals(Icon_Popup.Shop));

    }

    public void Change_Content_Popup(Character_Popup popup)
    {
        popup_State.SetActive(popup.Equals(Character_Popup.State));
        popup_Skill.SetActive(popup.Equals(Character_Popup.Skill));
        popup_Upgrade.SetActive(popup.Equals(Character_Popup.Upgrade));
        popup_Limit.SetActive(popup.Equals(Character_Popup.Limit));
    }

    #endregion

    #region Character

    public void Set_Character_Stat()
    {
        txt_State_Atk_Val.text = GetGoldString(Player_stat.int_Atk);
        txt_State_Hp_Val.text = GetGoldString(Player_stat.int_Hp);
        txt_State_Atk_Speed_Val.text = Player_stat.int_Atk_Speed.ToString();
        txt_State_Critical_Val.text = string.Format("{0}{1}", Player_stat.int_Critical, "%");
        txt_State_Critical_Percent_Val.text = string.Format("{0}{1}", Player_stat.int_Critical_Percent, "%");
        txt_State_Speed_Val.text = string.Format("{0}{1}", Player_stat.int_Atk_Speed, "%");
    }

    #endregion

    public void Dungeon()
    {
        PopupManager.Open_Popup(DungeonPopup);
    }

    public void Set_Inventory()
    {
        Debug.Log(BackEndDataManager.instance.Item_Data.item_Info.Count);

        for (int i = 0; i < Inventory_Panels.Length; i++)
        {
            Inventory_Panels[i].gameObject.SetActive(false);

            
            if (i < BackEndDataManager.instance.Item_Data.item_Info.Count)
            {
                Inventory_Panels[i].Set_Inventory_Item((Item_Type)BackEndDataManager.instance.Item_Data.item_Info[i].type,
        BigInteger.Parse(BackEndDataManager.instance.Item_Data.item_Info[i].str_val));

                Inventory_Panels[i].gameObject.SetActive(true);
            }

        }

    }
}
