using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon_Panel : MonoBehaviour
{
    Image img_Weapon;
    Text txt_Weapon_Grade;
    Text txt_Weapon_Lv;
    Text txt_Weapon_val;

    Dictionary<string, object> data;

    Weapon_Content weapon_Content = Weapon_Content.Accessory;

    public int item_num = 0;

    public void Set_Panel(int num , Weapon_Content weapon_Content)
    {
        item_num = num;

        data = BackEndDataManager.instance.sword_csv_data[num];

        img_Weapon = transform.Find("img_Weapon").GetComponent<Image>();
        txt_Weapon_Grade = transform.Find("txt_Weapon_Grade").GetComponent<Text>();
        txt_Weapon_Lv = transform.Find("txt_Weapon_Lv").GetComponent<Text>();
        txt_Weapon_val = transform.Find("txt_Weapon_val").GetComponent<Text>();

        this.weapon_Content = weapon_Content;

        switch (weapon_Content)
        {
            case Weapon_Content.Sword:
                img_Weapon.sprite = Utill.Get_Sword_Sp((int)data["num"]);

                break;
            case Weapon_Content.Shield:
                img_Weapon.sprite = Utill.Get_Shield_Sp((int)data["num"]);

                break;
            case Weapon_Content.Accessory:
                img_Weapon.sprite = Utill.Get_Accessory_Sp((int)data["num"]);

                break;
            case Weapon_Content.Costume:
                break;
            default:
                break;
        }

        txt_Weapon_Grade.text = data["grade"].ToString();


        GetComponent<Button>().onClick.AddListener(() => Open_Weapon_Popup());
        Set_Weapon_Lv();
        Set_Weapon_Val();
    }

    public void Set_Weapon_Lv()
    {

        Weapon_info weapon_Info = BackEndDataManager.instance.Weapon_Data.weapon_Info.Find(x => x.int_num.Equals((int)data["num"]) && x.enum_weapon.Equals(Weapon_.Weapon_Content));

        if (weapon_Info == null)
        {
            txt_Weapon_Lv.text = "Lv.0";

        }
        else
        {
            txt_Weapon_Lv.text = string.Format("Lv.{0}", weapon_Info.int_lv);

        }
    }

    public void Set_Weapon_Val()
    {
        Weapon_info weapon_Info = BackEndDataManager.instance.Weapon_Data.weapon_Info.Find(x => x.int_num.Equals((int)data["num"]) && x.enum_weapon.Equals(Weapon_.Weapon_Content));

        if (weapon_Info == null)
        {
            txt_Weapon_val.text = "0";
        }
        else
        {
            txt_Weapon_val.text = weapon_Info.int_val.ToString();
        }
    }

    public void Open_Weapon_Popup()
    {
        Weapon_.Select_Weapon = (int)data["num"];
        Weapon_.Weapon_Content = weapon_Content;

        UiManager.instance.Open_WeaponPopup();

    }
}
