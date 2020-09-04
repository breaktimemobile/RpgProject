using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Panel : MonoBehaviour
{
    private Image img_Skill;
    private Text txt_Skill_Lv;
    private Text txt_Skill_Name;
    private Text txt_Skill_Sub;
    private Text txt_Skill_Cool;
    private Button btn_Skill_Upgrade;
    private Text txt_Skill_Upgrade;
    private Text txt_Skill_val;
    private Image img_Skill_Upgrade;

    private GameObject obj_Lock;

    Skill skill;

    public void Set_Panel(int num)
    {

        img_Skill = transform.Find("img_Skill").GetComponent<Image>();
        txt_Skill_Lv = transform.Find("txt_Skill_Lv").GetComponent<Text>();
        txt_Skill_Name = transform.Find("txt_Skill_Name").GetComponent<Text>();
        txt_Skill_Sub = transform.Find("txt_Skill_Sub").GetComponent<Text>();
        txt_Skill_Cool = transform.Find("txt_Skill_Cool").GetComponent<Text>();
        btn_Skill_Upgrade = transform.Find("btn_Skill_Upgrade").GetComponent<Button>();
        txt_Skill_Upgrade = btn_Skill_Upgrade.transform.Find("txt_Skill_Upgrade").GetComponent<Text>();
        txt_Skill_val = btn_Skill_Upgrade.transform.Find("txt_Skill_val").GetComponent<Text>();
        img_Skill_Upgrade = btn_Skill_Upgrade.transform.Find("img_Skill_Upgrade").GetComponent<Image>();

        obj_Lock = transform.Find("obj_Lock").gameObject;

        btn_Skill_Upgrade.onClick.AddListener(() => Buy());
        skill = Skill_s.Get_Skill((Ability_Type)num);

        img_Skill_Upgrade.sprite = Utill.Get_Item_Sp((Item_Type)skill.price_type);

        img_Skill.sprite = Utill.Get_Skill_Sp(skill.ability_type);
        txt_Skill_Name.text = skill.name;
        
        obj_Lock.SetActive(false);
        

        Set_Sub_Txt();
        Set_Upgrade(Character_Lv.lv_1);
    }

    BigInteger total = 0;

    public void Set_Upgrade(Character_Lv up_lv)
    {
        Skill_s.skill_lv = up_lv;

        string m_up = UiManager.instance.GetGoldString((int)(skill.ability_add) * (int)up_lv);
        string f_up = string.Format("{0}{1}", (skill.ability_add * 100) * (int)up_lv, "%");

        txt_Skill_Upgrade.text = Ability_.Get_Ability_Type(skill.ability_type).Equals(0) ? f_up : m_up;

        Check_Btn();

        txt_Skill_val.text = UiManager.instance.GetGoldString((int)total);

    }

    public void Check_Btn()
    {

        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

        total = 0;

        int lv = skill_Info == null ? 0 : skill_Info.int_lv;

        txt_Skill_Lv.text = "Lv."+lv;


        total = Calculate.Percent(skill.price_val, skill.price_percent, lv, (int)Skill_s.skill_lv);

        btn_Skill_Upgrade.interactable = BackEndDataManager.instance.Get_Item((Item_Type)skill.price_type) >= total;
    }

    public void Set_Sub_Txt()
    {
        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

        int lv = skill_Info == null ? 0 : skill_Info.int_lv;

        int per = Ability_.Get_Ability_Type(skill.ability_type).Equals(0) ? 100 : 1;

        txt_Skill_Sub.text = string.Format("{0} {1}{2}",
            Ability_.Get_Ability_Nmae(skill.ability_type),
           lv.Equals(0) ? skill.base_ability * per : skill.f_total , Ability_.Ability_Type_Sign(skill.ability_type));

        txt_Skill_Cool.text = skill.cool_time == 0 ? "" :
            string.Format("지속:{0} 쿨타임:{1}", skill.skill_time, skill.cool_time);

    }

    public void Buy()
    {

        Debug.Log(total);

        if (BackEndDataManager.instance.Get_Item((Item_Type)skill.price_type) >= total)
        {
            UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.skill_upgrade, (int)Skill_s.skill_lv);
            Game_info_.Set_Game_Info(Game_Info_Type.skill_upgrade, (int)Skill_s.skill_lv);
            Quest_.Check_Daily_Quest(Daily_Quest_Type.skill_upgrade, (int)Skill_s.skill_lv);

            Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

            if (skill_Info == null)
            {
                skill_Info = new Skill_info
                {
                    int_num = skill.num,
                    int_lv = (int)Skill_s.skill_lv
                };

                BackEndDataManager.instance.Skill_Data.skill_Info.Add(skill_Info);
            }
            else
            {
                skill_Info.int_lv += (int)Skill_s.skill_lv;
            }

            BackEndDataManager.instance.Set_Item((Item_Type)skill.price_type, total,Calculate_Type.mius);

            Skill_s.Set_Skill_Val(skill_Info.int_num, skill_Info.int_lv);

            Player_stat.Set_Player_Stat((Ability_Type)skill.ability_type);
            BackEndDataManager.instance.Save_Skill_Data();
            Set_Sub_Txt();

            UiManager.instance.Check_Skill();

            switch (skill.num)
            {
                case 0:
                    PlayManager.instance.Start_Skill_0();
                    break;
                case 1:
                    PlayManager.instance.Start_Skill_1();

                    break;
                case 2:
                    PlayManager.instance.Start_Skill_2();

                    break;
                default:
                    break;
            }

        }

    }
}
