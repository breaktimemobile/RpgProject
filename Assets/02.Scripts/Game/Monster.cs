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
    Boss,
    underground_Boss,
    upgrade_Boss,
    hell_Boss,
    goblin

}

public enum Monster_State
{
    None,
    Die
}

public class Monster : MonoBehaviour
{
    int stop_pos = 0;

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

                this.transform.localPosition = new Vector3(stop_pos,transform.localPosition.y,transform.localPosition.z);

            }
        }
    }

    public void Hit(BigInteger damege)
    {
        anim_Monster.Play("hit");

        BigInteger total_damege = 0;
        int Rd = UnityEngine.Random.Range(0, 100);

        Transform pos = UiManager.instance.obj_Stage.transform;

        switch (PlayManager.instance.Stage_State)
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

        if (Player_stat.int_Critical_Percent >= Rd)
        {

            total_damege = damege + (damege * (BigInteger)Player_stat.int_Critical_Damege  / 100);

            Damege sc_damege = Instantiate(UiManager.instance.txt_Critical_Damege, pos).GetComponent<Damege>();
            sc_damege.transform.position = this.transform.position;
            sc_damege.Set_Txt(total_damege);
        }
        else
        {
            total_damege = damege;

            Damege sc_damege = Instantiate(UiManager.instance.txt_Damege, pos).GetComponent<Damege>();
            sc_damege.transform.position = this.transform.position;
            sc_damege.Set_Txt(total_damege);
        }

        hp -= total_damege;

        //slider_Hp.maxValue = total_Hp;
        slider_Hp.value = (float)Math.Exp(BigInteger.Log(hp) - BigInteger.Log(total_Hp));

        if (hp <= 0)
        {
            StartCoroutine("Co_Die");
        }
    }

    IEnumerator Co_Die()
    {
        switch (PlayManager.instance.Stage_State)
        {
            case Stage_State.stage:
                PlayManager.instance.Change_State(Player_State.Run);
                Add_Stage_Data();
                UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.monster,1);
                break;
            case Stage_State.underground:
                PlayManager.instance.Change_State(Player_State.Run);

                if (monster_Type.Equals(Monster_Type.underground_Boss))
                    Underground_.underground_Info.int_Max_Boss += 1;
                else
                    Underground_.underground_Info.int_Max_Monster += 1;

                UiManager.instance.Set_Underground_Info();
                Underground_.Get_Underground_Random_Item();

                break;
            case Stage_State.upgrade:

                PlayManager.instance.Change_State(Player_State.Reward);
                UiManager.instance.Set_Upgrade_Reward(true);
                PlayManager.instance.End_Upgrade();
                break;
            case Stage_State.hell:

                PlayManager.instance.Change_State(Player_State.Run);

                Hell_.int_Max_Monster += 1;

                UiManager.instance.Set_Hell_Info();

                break;
            default:
                break;
        }

        monster_State = Monster_State.Die;

        anim_Monster.Play("die");

        switch (monster_Type)
        {
            case Monster_Type.Basic:

                PlayManager.instance.Set_Monster();
                Game_info_.Set_Game_Info(Game_Info_Type.monster,1);
                Quest_.Check_Daily_Quest(Daily_Quest_Type.monster,1);
                break;
            case Monster_Type.Boss:

                PlayManager.instance.Stop_Boss_Timer(false);
                Game_info_.Set_Game_Info(Game_Info_Type.boss, 1);
                break;
            case Monster_Type.underground_Boss:
                PlayManager.instance.Set_Monster();

                break;
            case Monster_Type.upgrade_Boss:

                break;
            case Monster_Type.hell_Boss:
                PlayManager.instance.Set_Monster();

                break;
            case Monster_Type.goblin:

                Item item = Item_s.Get_Random_Goblin_Item();

                BackEndDataManager.instance.Set_Item((Item_Type)item.item_num,item.val,Calculate_Type.plus);

                PlayManager.instance.Set_Monster();
                Game_info_.Set_Game_Info(Game_Info_Type.gold_goblin, 1);

                break;
            default:
                break;
        }


        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);

    }

    public void Add_Stage_Data()
    {

        switch (monster_Type)
        {
            case Monster_Type.Basic:

                UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.stage_clear,1);

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
