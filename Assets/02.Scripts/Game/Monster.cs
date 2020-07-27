using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public enum Monster_Type
{
    Basic,
    Boss
}

public enum Monster_State
{
    None,
    Die
}

public class Monster : MonoBehaviour
{
    int stop_pos = 150;

    Slider slider_Hp;
    Animator anim_Monster;

    Monster_State monster_State = Monster_State.None;
    public Monster_Type monster_Type = Monster_Type.Basic;

    public BigInteger hp = 0;
    public BigInteger total_Hp = 0;

    private void Awake()
    {

        slider_Hp = GetComponentInChildren<Slider>();
        anim_Monster = GetComponent<Animator>();

    }

    public void Set_Monster(Monster_Type _Type, BigInteger m_hp)
    {
        monster_Type = _Type;

        transform.localScale = _Type == Monster_Type.Basic ? Vector3.one : Vector3.one * 1.3f;

        total_Hp = hp = m_hp;
        slider_Hp.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayManager.instance.Player_State.Equals(Player_State.Run))
        {
            this.transform.position += new Vector3(Player_stat.int_Btm_Scroll_Speed, 0, 0) * Time.deltaTime;

            if (this.transform.localPosition.x <= stop_pos && monster_State != Monster_State.Die)
            {
                PlayManager.instance.Change_State(Player_State.Fight);
            }
        }
    }

    public void Hit(ulong damege)
    {
        anim_Monster.Play("hit");

        ulong total_damege = 0;
        int Rd = UnityEngine.Random.Range(0, 100);

        if (Player_stat.int_Critical_Percent >= Rd)
        {

            total_damege = damege + (damege * (ulong)Player_stat.int_Critical / 100);

            Damege sc_damege = Instantiate(UiManager.instance.txt_Critical_Damege, UiManager.instance.obj_Stage.transform).GetComponent<Damege>();
            sc_damege.transform.position = this.transform.position;
            sc_damege.Set_Txt(total_damege);
        }
        else
        {
            total_damege = damege;

            Damege sc_damege = Instantiate(UiManager.instance.txt_Damege, UiManager.instance.obj_Stage.transform).GetComponent<Damege>();
            sc_damege.transform.position = this.transform.position;
            sc_damege.Set_Txt(total_damege);
        }

        hp -= total_damege;

        Debug.Log(hp + "  " + total_Hp);
        Debug.Log((float)Math.Exp(BigInteger.Log(hp) - BigInteger.Log(total_Hp)));

        //slider_Hp.maxValue = total_Hp;
        slider_Hp.value = (float)Math.Exp(BigInteger.Log(hp) - BigInteger.Log(total_Hp));

        if (hp <= 0)
        {
            StartCoroutine("Co_Die");
            PlayManager.instance.Change_State(Player_State.Run);
        }
    }

    IEnumerator Co_Die()
    {

        monster_State = Monster_State.Die;

        anim_Monster.Play("die");

        Add_Stage_Data();

        if (monster_Type.Equals(Monster_Type.Boss))
        {
            PlayManager.instance.Stop_Boss_Timer(false);
        }
        else
        {
            PlayManager.instance.Set_Monster();

        }


        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);

    }

    public void Add_Stage_Data()
    {

        switch (monster_Type)
        {
            case Monster_Type.Basic:

                BackEndDataManager.instance.Stage_Data.int_step += 1;
                BackEndDataManager.instance.Add_Exp(BackEndDataManager.instance.Monster_Exp(false));


                for (int i = 0; i < 2; i++)
                {
                    BackEndDataManager.instance.Monster_Reward(
                        (Item_Type)(int)BackEndDataManager.instance.monster_csv_data[0]["reward_" + i],
                        BigInteger.Parse(BackEndDataManager.instance.monster_csv_data[0]["reward_val_" + i].ToString()),
                        false);

                   }

                break;

            case Monster_Type.Boss:

                BackEndDataManager.instance.Stage_Data.int_stage += 1;
                BackEndDataManager.instance.Stage_Data.int_step = 1;
                BackEndDataManager.instance.Add_Exp(BackEndDataManager.instance.Monster_Exp(true));

                for (int i = 0; i < 2; i++)
                {
                    BackEndDataManager.instance.Monster_Reward(
                        (Item_Type)(int)BackEndDataManager.instance.monster_csv_data[0]["reward_" + i],
                        BigInteger.Parse(BackEndDataManager.instance.monster_csv_data[0]["reward_val_" + i].ToString()),
                        false);

                }

                break;

            default:
                break;
        }

        UiManager.instance.Set_Txt_Stage();
        UiManager.instance.Set_Txt_Coin();

        BackEndDataManager.instance.Save_Stage_Data();

    }
}
