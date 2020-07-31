using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon_Panel : MonoBehaviour
{
    Image img_Weapon;
    Text txt_Weapon_Grade;
    Text txt_Weapon_Lv;

    Dictionary<string, object> data;

    public void Set_Weapon_Item(Dictionary<string, object>  _data)
    {
        data = _data;

        img_Weapon = transform.Find("img_Weapon").GetComponent<Image>();
        txt_Weapon_Grade = transform.Find("txt_Weapon_Grade").GetComponent<Text>();
        txt_Weapon_Lv = transform.Find("txt_Weapon_Lv").GetComponent<Text>();

        txt_Weapon_Grade.text = data["grade"].ToString();

        Weapon_info weapon_Info = BackEndDataManager.instance.Weapon_Data.weapon_Info.Find(x => x.int_num.Equals((int)data["num"]));

        if (weapon_Info == null)
        {
            txt_Weapon_Lv.text = "Lv.0";

        }
        else
        {
            txt_Weapon_Lv.text = string.Format("Lv.{0}", weapon_Info.int_lv);
            
        }

    }

    public void Open_Weapon_Popup()
    {

    }
}
