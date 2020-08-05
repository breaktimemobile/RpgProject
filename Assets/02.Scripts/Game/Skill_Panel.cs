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

    public void Set_Skill_Item(int num)
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
        skill = Skill_s.Get_Skill((Skill_Type)num);

        img_Skill_Upgrade.sprite = Resources.Load<Sprite>("Item/icon_" + ((Item_Type)skill.price_type).ToString());

        img_Skill.sprite = Resources.Load<Sprite>("Skill/S_skill_" + skill.stat_type);
        txt_Skill_Name.text = skill.name;
        
        obj_Lock.SetActive(false);
        

        Set_Sub_Txt();
        Set_Upgrade(Character_Lv.lv_1);
    }

    BigInteger total = 0;

    public void Set_Upgrade(Character_Lv up_lv)
    {
        UiManager.instance.skill_lv = up_lv;

        string m_up = UiManager.instance.GetGoldString((int)(skill.stat_add) * (int)up_lv);
        string f_up = string.Format("{0}{1}", (skill.stat_add * 100) * (int)up_lv, "%");

        txt_Skill_Upgrade.text = skill.type.Equals(0) ? f_up : m_up;

        Check_Btn();

        txt_Skill_val.text = UiManager.instance.GetGoldString((int)total);

    }

    public void Check_Btn()
    {

        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

        total = 0;

        int lv = skill_Info == null ? 0 : skill_Info.int_lv;

        txt_Skill_Lv.text = "Lv."+lv;

        int m_percent = (int)Math.Ceiling(skill.price_val * skill.price_percent);

        for (int i = lv; i < lv + (int)UiManager.instance.skill_lv; i++)
        {
            total += skill.price_val + m_percent * i;
        }

        btn_Skill_Upgrade.interactable = BackEndDataManager.instance.Get_Item((Item_Type)skill.price_type) >= total;
    }

    public void Set_Sub_Txt()
    {
        Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

        int lv = skill_Info == null ? 0 : skill_Info.int_lv;

        txt_Skill_Sub.gameObject.SetActive(lv != 0);

        txt_Skill_Sub.text = string.Format("{0} {1}{2}",
            BackEndDataManager.instance.skill_Explan_csv_data[(int)skill.stat_type]["explan"].ToString(),
            skill.f_total.ToString() , skill.type.Equals(0) ?  "%" : "");

        txt_Skill_Cool.gameObject.SetActive(skill_Info != null);

        txt_Skill_Cool.text = skill.cool_time == 0 ? "" :
            string.Format("지속:{0} 쿨타임:{1}", skill.skill_time, skill.cool_time);

    }

    public void Buy()
    {

        Debug.Log(total);

        if (BackEndDataManager.instance.Get_Item((Item_Type)skill.price_type) >= total)
        {

            Skill_info skill_Info = BackEndDataManager.instance.Skill_Data.skill_Info.Find(x => x.int_num.Equals(skill.num));

            if (skill_Info == null)
            {
                skill_Info = new Skill_info
                {
                    int_num = skill.num,
                    int_lv = (int)UiManager.instance.skill_lv
                };

                BackEndDataManager.instance.Skill_Data.skill_Info.Add(skill_Info);
            }
            else
            {
                skill_Info.int_lv += (int)UiManager.instance.skill_lv;
            }

            BackEndDataManager.instance.Minus_Item((Item_Type)skill.price_type, total);

            Skill_s.Set_Skill_Val(skill_Info.int_num, skill_Info.int_lv);

            Player_stat.Set_Player_Stat((Skill_Type)skill.stat_type);
            BackEndDataManager.instance.Save_Skill_Data();
            Set_Sub_Txt();

        }

    }
}
