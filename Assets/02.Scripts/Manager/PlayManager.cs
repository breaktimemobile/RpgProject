using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    None,
    Run,
    Fight,
    Reward
}

public enum Stage_State
{
    stage,
    underground,
    upgrade,
    hell
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
            case Player_State.Reward:

                sc_Player.Stop_Atk();


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

        BackEndDataManager.instance.Check_Time_Item();

        UiManager.instance.Set_Ui();
        Set_Character();
        Set_Monster();

        Change_State(Player_State.Run);

    }

    public void Set_Character()
    {
        GameObject obj_Player = Instantiate(Characters[0],UiManager.instance.Character_Spawn);
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
            case Stage_State.upgrade:
                pos = UiManager.instance.UpgradeDungeon.transform;
                break;
            case Stage_State.hell:
                pos = UiManager.instance.HellDungeon.transform;
                break;
            default:
                break;
        }

        UiManager.instance.Spawn.SetParent(pos);
    }

    public void Start_Game(Stage_State stage)
    {
        Set_Change_Stage(stage);

        if(sc_Monster != null)
        Destroy(sc_Monster.gameObject);

        Set_Monster();

        Change_State(Player_State.Run);
    }

    public void Check_Underground()
    {

        if (BackEndDataManager.instance.Get_Item(Item_Type.underground_ticket) >= 1)
        {
            BackEndDataManager.instance.Set_Item(Item_Type.underground_ticket, 1, Calculate_Type.mius);

            Underground_.underground_Info = new Underground_info
            {
                int_num = Underground_.Underground_Lv,
                int_Max_Monster = 0,
                int_Max_Boss = 0
            };

            Underground_.Underground_Item.Clear();

            UiManager.instance.Set_Underground_Info();

            UiManager.instance.Open_Underground();

            Start_Game(Stage_State.underground);

            StartCoroutine("Co_Underground_Timer");
        }
       
    }

    public void Check_Upgrade(int lv)
    {
        if (BackEndDataManager.instance.Get_Item(Item_Type.upgrade_ticket) >= 1)
        {
            BackEndDataManager.instance.Set_Item(Item_Type.upgrade_ticket, 1, Calculate_Type.mius);

            Upgrade_.Upgrade_Lv = lv;

            UiManager.instance.Open_Upgrade();

            Start_Game(Stage_State.upgrade);

            StartCoroutine("Co_Upgrade_Timer");
        }
    }

    public void Check_Hell(int lv)
    {
        if (BackEndDataManager.instance.Get_Item(Item_Type.hell_ticket) >= 1)
        {
            BackEndDataManager.instance.Set_Item(Item_Type.hell_ticket, 1, Calculate_Type.mius);

            Hell_.Hell_Lv = lv;

            Hell_.int_Max_Monster = 0;

            UiManager.instance.Set_Hell_Info();

            UiManager.instance.Open_Hell();

            Start_Game(Stage_State.hell);

            StartCoroutine("Co_Hell_Timer");
        }
    }

    public void Set_Monster()
    {

        GameObject obj_Monster = Instantiate(Monsters[0], UiManager.instance.Monster_Spawn);
        obj_Monster.transform.position = pos_Monster.position;

        sc_Monster = obj_Monster.GetComponent<Monster>();
        sc_Monster.transform.localScale = Vector3.one;

        switch (stage_State)
        {
            case Stage_State.stage:


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

                break;
            case Stage_State.underground:

                sc_Monster = obj_Monster.GetComponent<Monster>();
                sc_Monster.transform.localScale = Vector3.one;

                if (Random.Range(0, 100) <= Underground_.Boss_Percent)
                {
                    sc_Monster.Set_Monster(Monster_Type.underground_Boss, BackEndDataManager.instance.Monster_Hp(true));
                }
                else
                {
                    sc_Monster.Set_Monster(Monster_Type.Basic, BackEndDataManager.instance.Monster_Hp(false));

                }



                break;

            case Stage_State.upgrade:

                sc_Monster = obj_Monster.GetComponent<Monster>();
                sc_Monster.transform.localScale = Vector3.one;

                sc_Monster.Set_Monster(Monster_Type.upgrade_Boss, BackEndDataManager.instance.Monster_Hp(true));

                break;

            case Stage_State.hell:

                sc_Monster = obj_Monster.GetComponent<Monster>();
                sc_Monster.transform.localScale = Vector3.one;


                sc_Monster.Set_Monster(Monster_Type.hell_Boss, BackEndDataManager.instance.Monster_Hp(true));



                break;
            default:
                break;
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

    IEnumerator Co_Underground_Timer()
    {
        float timer = float.Parse(BackEndDataManager.instance.underground_dungeon_csv_data[Underground_.Underground_Lv]["time"].ToString());

        UiManager.instance.Set_Underground_timer(timer);

        while (timer > 0)
        {

            yield return new WaitForSeconds(0.1f);

            timer -= 0.1f;

            UiManager.instance.Set_Underground_timer(timer);

        }

        Change_State(Player_State.Reward);
        UiManager.instance.Set_Underground_Reward();

    }

    public void End_Upgrade()
    {
        StopCoroutine("Co_Upgrade_Timer");
    }

    IEnumerator Co_Upgrade_Timer()
    {
        float timer = float.Parse(BackEndDataManager.instance.upgrade_dungeon_csv_data[Underground_.Underground_Lv]["time"].ToString());

        UiManager.instance.Set_Upgrade_timer(timer);

        while (timer > 0)
        {

            yield return new WaitForSeconds(0.1f);

            timer -= 0.1f;

            UiManager.instance.Set_Upgrade_timer(timer);

        }

        Change_State(Player_State.Reward);
        UiManager.instance.Set_Upgrade_Reward(false);

    }

    IEnumerator Co_Hell_Timer()
    {
        float timer = float.Parse(BackEndDataManager.instance.hell_dungeon_csv_data[Hell_.Hell_Lv]["time"].ToString());

        UiManager.instance.Set_Hell_timer(timer);

        while (timer > 0)
        {

            yield return new WaitForSeconds(0.1f);

            timer -= 0.1f;

            UiManager.instance.Set_Hell_timer(timer);

        }

        Change_State(Player_State.Reward);
        UiManager.instance.Set_Hell_Reward();

    }

    public void Start_Skill()
    {

        if (is_skill)
            return;

        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals((int)Ability_Type.skill_atk));

        if(skill_Info != null)
        {
            if (skill_Info.int_lv >= 1)
            {
                StartCoroutine("Co_Start_Skill");

            }
        }
 
    }

    bool is_skill = false;

    IEnumerator Co_Start_Skill()
    {

        is_skill = true;

        Skill skill = Skill_s.Get_Skill(Ability_Type.skill_atk);

        float skill_time = skill.skill_time;

        Player_stat.Use_skill = true;
        Player_stat.Set_Skill_Stat();
        UiManager.instance.Set_Skill_0_Bg();

        while (skill_time >= 0)
        {

            skill_time -= 0.1f;
            UiManager.instance.Set_Skill_0_txt(0, (int)skill_time);

            yield return new WaitForSeconds(0.1f);

        }


        Player_stat.Use_skill = false;
        Player_stat.Set_Skill_Stat();

        StartCoroutine("Co_Cool_Skill");
    }

    IEnumerator Co_Cool_Skill()
    {

        Skill skill = Skill_s.Get_Skill(Ability_Type.skill_atk);

        float skill_time = skill.cool_time;
        UiManager.instance.Set_Skill_0_Bg();

        while (skill_time >= 0)
        {

            skill_time -= 0.1f;
            UiManager.instance.Set_Skill_0_txt(skill_time / skill.cool_time, (int)skill_time);

            yield return new WaitForSeconds(0.1f);

        }

        is_skill = false;
        Start_Skill();


    }

}
