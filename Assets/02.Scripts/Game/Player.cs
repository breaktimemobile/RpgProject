using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_stat
{

    public int int_Atk;
    public int int_Hp;
    public int int_Atk_Speed;
    public int int_Critical;
    public int int_Critical_Percent;
    public int int_Speed;

}

public class Player : MonoBehaviour
{

    Player_stat player_Stat = new Player_stat();

    Animator anim_Player;

    private void Awake()
    {
        anim_Player = GetComponent<Animator>();
        Set_Player_Stat();
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

            PlayManager.instance.sc_Monster.Hit(player_Stat.int_Atk);

            yield return new WaitForSeconds(1.0f);

        }
    }

    public void Set_Player_Stat()
    {
        //공격력 레벨당 10퍼 상승
        //체력 5퍼 상승

        player_Stat.int_Atk = 100 + (100 * (BackEndDataManager.instance.Character_Data.int_character_Lv / 10)); 
        player_Stat.int_Hp = 2000 + (2000 * (BackEndDataManager.instance.Character_Data.int_character_Lv / 20));
        player_Stat.int_Atk_Speed = 100;
        player_Stat.int_Critical = 5;
        player_Stat.int_Critical_Percent = 1;
        player_Stat.int_Speed = 100;

    }
}
