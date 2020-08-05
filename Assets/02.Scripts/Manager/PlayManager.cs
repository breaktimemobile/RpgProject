using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    None,
    Run,
    Fight
}

public enum Stage_State
{
    stage,
    underground
}

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;

    Player_State player_State = Player_State.None;
    Stage_State stage_State = Stage_State.stage;

    public List<GameObject> Characters;
    public List<GameObject> Monsters;

    Transform pos_Character;
    Transform pos_Monster;

    Player sc_Player;
    public Monster sc_Monster;

    public Player_State Player_State { get => player_State; set => player_State = value; }
    public Stage_State Stage_State { get => stage_State; set => stage_State = value; }

    public void Change_State(Player_State _State)
    {
        Player_State = _State;

        switch (Player_State)
        {
            case Player_State.None:
                break;
            case Player_State.Run:
                sc_Player.Stop_Atk();
                sc_Player.Start_Run();
                break;
            case Player_State.Fight:

                sc_Player.Start_Atk();

                if (sc_Monster.monster_Type.Equals(Monster_Type.Boss))
                    Start_Boss_Timer();

                break;

            default:
                break;
        }
    }

    private void Awake()
    {
        instance = this;

        pos_Character = UiManager.instance.obj_Stage.transform.Find("pos_Character");
        pos_Monster = UiManager.instance.obj_Stage.transform.Find("pos_Monster");
    }

    public void Play_Game()
    {
        Debug.Log("플레이 게임");
        UiManager.instance.Set_Ui();
        Set_Character();
        Set_Monster();

        Change_State(Player_State.Run);

    }

    public void Set_Character()
    {
        GameObject obj_Player = Instantiate(Characters[0]);
        obj_Player.transform.position = pos_Character.position;

        sc_Player = obj_Player.GetComponent<Player>();
        sc_Player.Init();

        Set_Change_Stage(Stage_State.stage);


    }

    private void Set_Change_Stage(Stage_State stage)
    {
        stage_State = stage;

        Transform pos = UiManager.instance.obj_Stage.transform;

        switch (stage_State)
        {
            case Stage_State.stage:
                pos = UiManager.instance.obj_Stage.transform;
                break;
            case Stage_State.underground:
                pos = UiManager.instance.UndergroundDungeon.transform;
                break;
            default:
                break;
        }

        sc_Player.transform.SetParent(pos);
        sc_Player.transform.localScale = Vector3.one;
    }

    public void Start_Game(Stage_State stage)
    {
        Set_Change_Stage(stage);

        Destroy(sc_Monster.gameObject);

        Set_Monster();

        Change_State(Player_State.Run);
    }

    public void Check_Stage()
    {

       PopupManager.Close_Popup();

        Start_Game(Stage_State.stage);

    }

    public void Check_Underground()
    {

        //if (BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket) >= 1)
        //{
            BackEndDataManager.instance.Set_Item(Item_Type.underground_ticket, 1, Calculate_Type.mius);

            UiManager.instance.Open_Underground();

            Start_Game(Stage_State.underground);

        //}


    }

    public void Set_Monster()
    {

        Transform pos = UiManager.instance.obj_Stage.transform;

        switch (stage_State)
        {
            case Stage_State.stage:
                pos = UiManager.instance.obj_Stage.transform;
                break;
            case Stage_State.underground:
                pos = UiManager.instance.UndergroundDungeon.transform;
                break;
            default:
                break;
        }


        GameObject obj_Monster = Instantiate(Monsters[0], pos);
        obj_Monster.transform.position = pos_Monster.position;

        sc_Monster = obj_Monster.GetComponent<Monster>();
        sc_Monster.transform.localScale = Vector3.one;

        if (BackEndDataManager.instance.Stage_Data.int_step > 10)
        {
            if (!BackEndDataManager.instance.Stage_Data.is_boss)
            {
                sc_Monster.Set_Monster(Monster_Type.Boss, BackEndDataManager.instance.Monster_Hp(true));

            }
            else
            {
                sc_Monster.Set_Monster(Monster_Type.Basic, BackEndDataManager.instance.Monster_Hp(false));

            }
        }
        else
        {
            sc_Monster.Set_Monster(Monster_Type.Basic, BackEndDataManager.instance.Monster_Hp(false));

        }
    }

    public void Start_Boss_Timer()
    {
        StartCoroutine("Co_Boss_Timer");
    }

    public void Stop_Boss_Timer(bool isboss)
    {
        StopCoroutine("Co_Boss_Timer");

        BackEndDataManager.instance.Stage_Data.is_boss = isboss;
        BackEndDataManager.instance.Save_Stage_Data();

        UiManager.instance.slider_Boss_Timer.gameObject.SetActive(false);

        Destroy(sc_Monster.gameObject);

        Set_Monster();

        Change_State(Player_State.Run);

        UiManager.instance.Set_Txt_Stage();

    }

    IEnumerator Co_Boss_Timer()
    {
        Debug.Log(BackEndDataManager.instance.monster_csv_data[0]["Boss_Time"]);
        float timer = float.Parse(BackEndDataManager.instance.monster_csv_data[0]["Boss_Time"].ToString());

        UiManager.instance.slider_Boss_Timer.maxValue = timer;
        UiManager.instance.slider_Boss_Timer.value = timer;

        UiManager.instance.slider_Boss_Timer.gameObject.SetActive(true);

        UiManager.instance.txt_Boss_Timer.text = string.Format("{0:00}:{1:00}", 0, timer);

        while (timer > 0)
        {

            yield return new WaitForSeconds(0.1f);

            timer -= 0.1f;

            UiManager.instance.slider_Boss_Timer.value = timer;

            UiManager.instance.txt_Boss_Timer.text = string.Format("{0:00}:{1:00}", 0, (int)timer);

        }

        //보스 못잡음 
        Stop_Boss_Timer(true);
    }

    public void Start_Boss_Stage()
    {

        BackEndDataManager.instance.Stage_Data.is_boss = false;
        BackEndDataManager.instance.Save_Stage_Data();

        Destroy(sc_Monster.gameObject);

        Set_Monster();

        Change_State(Player_State.Run);

        UiManager.instance.Set_Txt_Stage();
    }
}
