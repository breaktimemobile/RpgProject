using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum Popup
{
    popup_State,
    popup_Skill,
    popup_Upgrade,
    popup_Limit,
}

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    private GameObject NickNamePopup;

    private GameObject obj_Top;
    public GameObject obj_Stage;
    private GameObject obj_Content;
    private GameObject obj_Icon;

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
    private Text txt_State_Add_Lv;

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

    #endregion

    #region NickNamePopup

    private InputField Input_NickName;
    private Button btn_NickName_Ok;
    private GameObject txt_NickName_Fail;

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

        #endregion

        #region obj_Content

        #region Content_Character

        btn_State = obj_Content.transform.Find("Content_Character/grid_Btn/btn_State").GetComponent<Button>();
        btn_Skill = obj_Content.transform.Find("Content_Character/grid_Btn/btn_Skill").GetComponent<Button>();
        btn_Upgrade = obj_Content.transform.Find("Content_Character/grid_Btn/btn_Upgrade").GetComponent<Button>();
        btn_Limit = obj_Content.transform.Find("Content_Character/grid_Btn/btn_Limit").GetComponent<Button>();

        popup_State = obj_Content.transform.Find("Content_Character/contents/popup_State").gameObject;
        popup_Skill = obj_Content.transform.Find("Content_Character/contents/popup_Skill").gameObject;
        popup_Upgrade = obj_Content.transform.Find("Content_Character/contents/popup_Upgrade").gameObject;
        popup_Limit = obj_Content.transform.Find("Content_Character/contents/popup_Limit").gameObject;

        #endregion

        #endregion

        #region  popup_State;

        txt_State_Name = popup_State.transform.Find("img_State_Bg/txt_State_Name").GetComponent<Text>();
        txt_State_Lv = popup_State.transform.Find("img_State_Bg/txt_State_Lv").GetComponent<Text>();
        txt_State_Add_Lv = popup_State.transform.Find("img_State_Bg/txt_State_Add_Lv").GetComponent<Text>();

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

    }

    private void AddListener()
    {
        btn_NickName_Ok.onClick.AddListener(() => Check_Nickname());

        btn_State.onClick.AddListener(() => Change_Content_Popup(Popup.popup_State));
        btn_Skill.onClick.AddListener(() => Change_Content_Popup(Popup.popup_Skill));
        btn_Upgrade.onClick.AddListener(() => Change_Content_Popup(Popup.popup_Upgrade));
        btn_Limit.onClick.AddListener(() => Change_Content_Popup(Popup.popup_Limit));
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
        Debug.Log(BackEndDataManager.instance.User_Data.str_nick);

#if UNITY_EDITOR
        PlayManager.instance.Play_Game();

#elif UNITY_ANDROID

        if (BackEndDataManager.instance.User_Data.str_nick.Equals("null"))
        {
            //닉네임 팝업
            PopupManager.Open_Popup(NickNamePopup);
        }
        else
        {
            //게임시작
            PlayManager.instance.Play_Game();
        }
#endif


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
        txt_NickName.text = BackEndDataManager.instance.User_Data.str_nick;
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
        txt_Steel_Val.text = BackEndDataManager.instance.Player_Data.int_steel.ToString();
    }

    public void Set_Txt_Coin()
    {
        txt_Coin_Val.text = BackEndDataManager.instance.Player_Data.int_coin.ToString();

    }

    public void Set_Txt_Dia()
    {
        txt_Dia_Val.text = BackEndDataManager.instance.Player_Data.int_dia.ToString();
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
        }
        else
        {
            txt_State_Stage.text = BackEndDataManager.instance.Stage_Data.int_stage.ToString() + " 스테이지 " + "보스";
        }
    }


    #endregion

    #region CharacterUI 세팅

    #endregion

    #region Popup 

    public void Change_Main_Popup()
    {

    }

    public void Change_Content_Popup(Popup popup)
    {
        popup_State.SetActive(popup.Equals(Popup.popup_State));
        popup_Skill.SetActive(popup.Equals(Popup.popup_Skill));
        popup_Upgrade.SetActive(popup.Equals(Popup.popup_Upgrade));
        popup_Limit.SetActive(popup.Equals(Popup.popup_Limit));
    }

    #endregion
}
