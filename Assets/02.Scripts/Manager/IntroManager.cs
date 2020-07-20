using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Intro_State
{
    Service,
    Login,
    Touch
}

/// <summary>
/// 순서 : 게임이용약관 -> 로그인 -> 터치
/// </summary>

public class IntroManager : MonoBehaviour
{
    public static IntroManager instance;

    private GameObject ServicePopup;
    private GameObject LoginPopup;
    private GameObject NextPopup;


    #region ServicePopup

    private Toggle toggle_Service;
    private Button btn_Service;
    private Toggle toggle_Privacy;
    private Button btn_Privacy;
    private Button btn_Service_Ok;

    #endregion

    #region LoginPopup

    private Button btn_Google;
    private Button btn_Guest;

    #endregion

    #region NextPopup

    private Text txt_Next;
    private Button btn_Next;
    private Image img_Return;
    private Text txt_Loading;

    #endregion

    private void Awake()
    {
        instance = this;

        Find_Obj();
        AddListener();

        BackEndAuthManager.init();
        SocalManager.Init();


    }

    private void Start()
    {
        Check_Service();

    }

    private void Find_Obj()
    {

        Transform canvas = GameObject.Find("Canvas").transform;

        ServicePopup = canvas.Find("ServicePopup").gameObject;
        LoginPopup = canvas.Find("LoginPopup").gameObject;
        NextPopup = canvas.Find("NextPopup").gameObject;

        toggle_Service = ServicePopup.transform.Find("obj_Service/toggle_Service").GetComponent<Toggle>();
        btn_Service = ServicePopup.transform.Find("obj_Service/btn_Service").GetComponent<Button>();
        toggle_Privacy = ServicePopup.transform.Find("obj_Privacy/toggle_Privacy").GetComponent<Toggle>();
        btn_Privacy = ServicePopup.transform.Find("obj_Privacy/btn_Privacy").GetComponent<Button>();
        btn_Service_Ok = ServicePopup.transform.Find("btn_Service_Ok").GetComponent<Button>();

        btn_Google = LoginPopup.transform.Find("btn_Google").GetComponent<Button>();
        btn_Guest = LoginPopup.transform.Find("btn_Guest").GetComponent<Button>();

        txt_Next = NextPopup.transform.Find("img_Bg/txt_Next").GetComponent<Text>();
        btn_Next = NextPopup.transform.Find("btn_Next").GetComponent<Button>();
        img_Return = NextPopup.transform.Find("img_Return").GetComponent<Image>();
        txt_Loading = NextPopup.transform.Find("txt_Loading").GetComponent<Text>();
    }

    private void AddListener()
    {

        toggle_Service.onValueChanged.AddListener((bool ison) => Check_Toggle());
        btn_Service.onClick.AddListener(() => Application.OpenURL(" https://sites.google.com/site/breaktieme/terms-of-service"));
        toggle_Privacy.onValueChanged.AddListener((bool ison) => Check_Toggle());
        btn_Privacy.onClick.AddListener(() => Application.OpenURL("https://sites.google.com/site/breaktieme/privacy-policy_kr"));
        btn_Service_Ok.onClick.AddListener(() => Open_Login());

        btn_Google.onClick.AddListener(() => SocalManager.Login());
        //btn_Guest.onClick.AddListener(() => BackEndAuthManager.OnClickSignUp());

        btn_Next.onClick.AddListener(() => Main_Scene());

    }

    /// <summary>
    /// 1.게임 이용 약관
    /// </summary>
    public void Check_Service()
    {
        if (PlayerPrefs.GetInt("Service", 0).Equals(0))
        {
            toggle_Service.isOn = false;
            toggle_Privacy.isOn = false;
            btn_Service_Ok.interactable = false;

            PopupManager.Open_Popup(ServicePopup);
        }
        else
        {
            Check_Login();
        }
    }

    public void Check_Toggle()
    {
        Debug.Log(toggle_Service + "   " + toggle_Service.isOn);

        btn_Service_Ok.interactable = (toggle_Privacy.isOn && toggle_Service.isOn) ? true : false;
    }

    public void Open_Login()
    {
        PlayerPrefs.SetInt("Service", 1);

        PopupManager.Close_Popup();
        PopupManager.Open_Popup(LoginPopup);

    }

    /// <summary>
    /// 2. 로그인
    /// </summary>
    void Check_Login()
    {
        //구글에 로그인 안됐을때
        //그냥 로그인 안됏을때

        if (BackEndAuthManager.Get_Join_User())
        {
            Debug.Log("로그인 되있음");
            SocalManager.Login();

        }
        else
        {
            Debug.Log("로그인 안되있음");
            PopupManager.Open_Popup(LoginPopup);

        }
    }

    /// <summary>
    /// 3.터치
    /// </summary>
    public void Check_Next()
    {
        PopupManager.Open_Popup(NextPopup);
        txt_Next.DOFade(0, 2).SetLoops(-1, LoopType.Yoyo);

    }




    /// <summary>
    /// 4.화면 전환
    /// </summary>
    public void Main_Scene()
    {
        StartCoroutine("Co_Main_Scene");
    }


    IEnumerator Co_Main_Scene()
    {
        img_Return.gameObject.SetActive(true);
        txt_Loading.gameObject.SetActive(true);

        img_Return.transform.DORotate(new Vector3(0, 0, 360), 2.5f, RotateMode.FastBeyond360)
                     .SetEase(Ease.Linear)
                     .SetLoops(-1);

        AsyncOperation async = SceneManager.LoadSceneAsync("Main");
        async.allowSceneActivation = false; //퍼센트 딜레이용

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; //씬 전환 준비 완료
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            txt_Loading.text = percentage.ToString("0") + "%"; //로딩 퍼센트 표기
        }
    }

    public void GetTokens()
    {
        Debug.Log(SocalManager.GetTokens());

    }

    public void OnClickGetUserInfo()
    {
        //BackEndAuthManager.OnClickGetUserInfo();
    }
}
