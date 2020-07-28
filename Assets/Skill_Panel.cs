using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Panel : MonoBehaviour
{
    public Image img_Skill;
    public Text txt_Skill_Name;
    public Text txt_Skill_Sub;
    public Text txt_Skill_Cool;
    public Button btn_Skill_Upgrade;
    public Text txt_Skill_Upgrade;
    public Text txt_Skill_val;
    public Image img_Skill_Upgrade;

    public GameObject obj_Lock;

    Dictionary<string, object> data;

    skill_info skill_Info;

    public void Set_Skill_Item(Dictionary<string, object> _data)
    {
        data = _data;

        img_Skill = transform.Find("img_Skill").GetComponent<Image>();
        txt_Skill_Name = transform.Find("txt_Skill_Name").GetComponent<Text>();
        txt_Skill_Sub = transform.Find("txt_Skill_Sub").GetComponent<Text>();
        txt_Skill_Cool = transform.Find("txt_Skill_Cool").GetComponent<Text>();
        btn_Skill_Upgrade = transform.Find("btn_Skill_Upgrade").GetComponent<Button>();
        txt_Skill_Upgrade = btn_Skill_Upgrade.transform.Find("txt_Skill_Upgrade").GetComponent<Text>();
        txt_Skill_val = btn_Skill_Upgrade.transform.Find("txt_Skill_val").GetComponent<Text>();
        img_Skill_Upgrade = btn_Skill_Upgrade.transform.Find("img_Skill_Upgrade").GetComponent<Image>();

        obj_Lock = transform.Find("obj_Lock").gameObject;

        img_Skill.sprite = Resources.Load<Sprite>("Skill/S_skill_" + data["stat_type"].ToString());
        txt_Skill_Name.text = _data["name"].ToString();
        txt_Skill_Sub.text = BackEndDataManager.instance.skill_Explan_csv_data[(int)data["stat_type"]]["explan"].ToString();

        obj_Lock.SetActive(skill_Info == null);
        txt_Skill_Cool.gameObject.SetActive(skill_Info != null);

        Set_Upgrade(1);
    }

    public void Set_Upgrade(int up_lv)
    {


        int type = (int)data["type"];

        int n_base_stat = 0;
        float f_base_stat = 0;

        int.TryParse(data["base_stat"].ToString(), out n_base_stat);
        float.TryParse(data["base_stat"].ToString(), out f_base_stat);
 
        int price_val = (int)data["price_val"];

        string Integer = UiManager.instance.GetGoldString((int)n_base_stat * up_lv);
        string percent = string.Format("{0}{1}", (f_base_stat * 100) * up_lv , "%");

        txt_Skill_Upgrade.text = type.Equals(0)? percent : Integer;

        txt_Skill_val.text = UiManager.instance.GetGoldString(price_val * up_lv);
    }
}
