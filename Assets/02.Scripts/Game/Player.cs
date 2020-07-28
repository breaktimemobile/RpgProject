using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_stat
{

    public static ulong int_Atk;
    public static ulong int_Hp;
    public static int int_Atk_Speed;
    public static int int_Critical_Damege;
    public static int int_Critical_Percent;
    public static int int_Speed;

    public static float int_Top_Scroll_Speed;
    public static float int_Btm_Scroll_Speed;

    public static void Set_Player_Stat()
    {
        //공격력 레벨당 10퍼 상승
        //체력 5퍼 상승

        int_Atk = 100 + (100 / 20) * ((ulong)BackEndDataManager.instance.Character_Data.int_character_Lv - 1);
        int_Hp = 2000 + (2000 / 20) * ((ulong)BackEndDataManager.instance.Character_Data.int_character_Lv - 1);
        int_Atk_Speed = 100;
        int_Critical_Damege = 5;
        int_Critical_Percent = 1;
        int_Speed = 100;
        int_Top_Scroll_Speed = -int_Speed / 90.0f;
        int_Btm_Scroll_Speed = -int_Speed / 60.0f;

        Debug.Log("top "+int_Top_Scroll_Speed);
        Debug.Log("btm "+int_Btm_Scroll_Speed);

        UiManager.instance.Set_Character_Stat();
    }

    public static void Add_Lv(int lv)
    {

        BackEndDataManager.instance.Character_Data.int_character_Lv += lv;

        Set_Player_Stat();
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
    }

    public void Start_Run()
    {
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

            PlayManager.instance.sc_Monster.Hit(Player_stat.int_Atk);
            
            yield return new WaitForSeconds( 100 / Player_stat.int_Atk_Speed );

        }
    }

    
}
