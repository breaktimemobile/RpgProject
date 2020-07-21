using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float hp = 0;
    public float total_Hp = 0;

    private void Awake()
    {

        slider_Hp = GetComponentInChildren<Slider>();
        anim_Monster = GetComponent<Animator>();

    }

    public void Set_Monster(Monster_Type _Type, float m_hp)
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

    public void Hit(int damege)
    {
        anim_Monster.Play("hit");

        int total_damege = 0;
        int Rd = Random.Range(0, 100);

        if (Player_stat.int_Critical_Percent >= Rd)
        {

            total_damege = damege + (damege * Player_stat.int_Critical / 100);

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

        slider_Hp.value = hp / total_Hp;

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

        BackEndDataManager.instance.Player_Data.int_exp += 1;
        BackEndDataManager.instance.Player_Data.int_coin += 100;

        switch (monster_Type)
        {
            case Monster_Type.Basic:
                BackEndDataManager.instance.Stage_Data.int_step += 1;
                break;
            case Monster_Type.Boss:
                BackEndDataManager.instance.Stage_Data.int_stage += 1;
                BackEndDataManager.instance.Stage_Data.int_step = 1;

                break;
            default:
                break;
        }

        UiManager.instance.Set_Txt_Stage();
        UiManager.instance.Set_Txt_Exp();
        UiManager.instance.Set_Txt_Coin();

        BackEndDataManager.instance.Save_Player_Data();
        BackEndDataManager.instance.Save_Stage_Data();

    }
}
