using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Player_stat
{
    public static int int_Lv;

    public static BigInteger int_Base_Atk;

    public static BigInteger int_Total_Atk;
    public static BigInteger int_Hp;
    public static float int_Atk_Speed;
    public static float int_Critical_Damege;
    public static float int_Critical_Percent;
    public static float int_Speed;

    public static float int_Top_Scroll_Speed;
    public static float int_Btm_Scroll_Speed;

    public static bool Use_skill = false;

    public static void Set_Player_Stat()
    {
        //공격력 레벨당 10퍼 상승
        //체력 5퍼 상승


        int_Lv = BackEndDataManager.instance.Character_Data.int_character_Lv + (int)Skill_s.Get_Skill_Val(Skill_Type.add_level);

        float skill_atk = Use_skill ? Skill_s.Get_Skill_Val(Skill_Type.skill_atk) : 0;

        int_Base_Atk = 100 + (100 / 20) * (int_Lv - 1);
        BigInteger int_Upgrade = (int_Base_Atk * BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv * 5) / 100;
        int_Total_Atk = int_Base_Atk + int_Upgrade + (int)Skill_s.Get_Skill_Val(Skill_Type.add_atk) + (int_Base_Atk * (int)skill_atk) / 100;

        int_Hp = 2000 + (2000 / 20) * (int_Lv - 1);

        int_Atk_Speed = 100 + Skill_s.Get_Skill_Val(Skill_Type.add_atk_speed)
            + (Use_skill ? (int)Skill_s.Get_Skill_Val(Skill_Type.skill_atk_speed) : 0);

        int_Critical_Damege = 5 + Skill_s.Get_Skill_Val(Skill_Type.add_critical_damege);

        int_Critical_Percent = 1 + Skill_s.Get_Skill_Val(Skill_Type.add_critical_percent);

        int_Speed = 100 + Skill_s.Get_Skill_Val(Skill_Type.add_speed)
            + (Use_skill ? (int)Skill_s.Get_Skill_Val(Skill_Type.skill_speed) : 0);

        int_Top_Scroll_Speed = -int_Speed / 90.0f;
        int_Btm_Scroll_Speed = -int_Speed / 60.0f;

        Debug.Log("top " + int_Top_Scroll_Speed);
        Debug.Log("btm " + int_Btm_Scroll_Speed);

        UiManager.instance.Set_Character_Stat();
    }

    public static void Set_Player_Stat(Skill_Type skill_Type)
    {
        Debug.Log("이거냐?????");
        switch (skill_Type)
        {

            case Skill_Type.add_atk_speed:
                int_Atk_Speed = 100 + Skill_s.Get_Skill_Val(Skill_Type.add_atk_speed)
                    + (Use_skill ? (int)Skill_s.Get_Skill_Val(Skill_Type.skill_atk_speed) : 0);
                break;

            case Skill_Type.add_speed:
                int_Speed = 100 + Skill_s.Get_Skill_Val(Skill_Type.add_speed)
                    + (Use_skill ? (int)Skill_s.Get_Skill_Val(Skill_Type.skill_speed) : 0);

                int_Top_Scroll_Speed = -int_Speed / 90.0f;
                int_Btm_Scroll_Speed = -int_Speed / 60.0f;

                break;

            case Skill_Type.add_critical_damege:
                int_Critical_Damege = 5 + Skill_s.Get_Skill_Val(Skill_Type.add_critical_damege);

                break;

            case Skill_Type.add_critical_percent:
                int_Critical_Percent = 1 + Skill_s.Get_Skill_Val(Skill_Type.add_critical_percent);

                break;

            case Skill_Type.add_level:
                int_Lv = BackEndDataManager.instance.Character_Data.int_character_Lv + (int)Skill_s.Get_Skill_Val(Skill_Type.add_level);

                float skill_atk = Use_skill ? Skill_s.Get_Skill_Val(Skill_Type.skill_atk) : 0;


                int_Base_Atk = 100 + (100 / 20) * (int_Lv - 1);
                BigInteger int_Upgrade = (int_Base_Atk * BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv * 5) / 100;
                int_Total_Atk = int_Base_Atk + int_Upgrade + (int)Skill_s.Get_Skill_Val(Skill_Type.add_atk) + (int_Base_Atk * (int)skill_atk) / 100;

                int_Hp = 2000 + (2000 / 20) * ((BigInteger)int_Lv - 1);
                UiManager.instance.Set_Character_Lv();
                UiManager.instance.Set_Buy_Lv();
                break;

            case Skill_Type.add_atk:

                skill_atk = Use_skill ? Skill_s.Get_Skill_Val(Skill_Type.skill_atk) : 0;


                int_Base_Atk = 100 + (100 / 20) * (int_Lv - 1);
                int_Upgrade = (int_Base_Atk * BackEndDataManager.instance.Character_Data.Int_Upgrade_Lv * 5) / 100;
                int_Total_Atk = int_Base_Atk + int_Upgrade + (int)Skill_s.Get_Skill_Val(Skill_Type.add_atk) + (int_Base_Atk * (int)skill_atk) / 100;

                break;

            default:
                break;
        }

        UiManager.instance.Set_Character_Stat();

    }

    public static void Set_Skill_Stat()
    {
        Set_Player_Stat(Skill_Type.add_atk_speed);
        Set_Player_Stat(Skill_Type.add_atk);
        Set_Player_Stat(Skill_Type.skill_speed);
    }

    public static void Add_Lv(int lv)
    {

        BackEndDataManager.instance.Character_Data.int_character_Lv += lv;

        Set_Player_Stat(Skill_Type.add_level);
        UiManager.instance.Set_Character_Lv();
        UiManager.instance.Set_Buy_Lv();

        BackEndDataManager.instance.Save_Character_Data();

    }


}

public class Player : MonoBehaviour
{

    Animator anim_Player;

    public void Init()
    {
        anim_Player = GetComponent<Animator>();
        Start_Skill();
    }

    public void Start_Run()
    {
        Debug.Log("int_Btm_Scroll_Speed" + Player_stat.int_Speed);
        anim_Player.SetFloat("speed", Player_stat.int_Speed / 100);
        anim_Player.Play("run");
    }

    public void Start_Atk()
    {
        StartCoroutine("Co_Atk");
    }

    public void Stop_Atk()
    {
        StopCoroutine("Co_Atk");
    }

    IEnumerator Co_Atk()
    {
        while (true)
        {

            anim_Player.Play("atk");

            float length = anim_Player.runtimeAnimatorController.animationClips.First(x => x.name == "atk").length;

            yield return new WaitForSeconds(length);

            PlayManager.instance.sc_Monster.Hit(Player_stat.int_Total_Atk);

            yield return new WaitForSeconds(100 / Player_stat.int_Atk_Speed);

        }
    }


    public void Start_Skill()
    {

        if (is_skill)
            return;

        skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals((int)Skill_Type.skill_atk));

        if (skill_Info.int_lv >= 1)
        {
            StartCoroutine("Co_Start_Skill");

        }
    }

    bool is_skill = false;

    IEnumerator Co_Start_Skill()
    {

        is_skill = true;

        Skill skill = Skill_s.Get_Skill(Skill_Type.skill_atk);

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
       
        Skill skill = Skill_s.Get_Skill(Skill_Type.skill_atk);

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
