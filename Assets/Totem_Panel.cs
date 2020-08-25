using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totem_Panel : MonoBehaviour
{
    Image img_totem;
    Text txt_totem_Lv;
    Text txt_totem_name;
    Text txt_totem_sub;
    Text txt_totem_val;
    Button btn_totem_Upgrade;
    Text txt_totem_add_reward;
    Text txt_totem_price_val;
    Text img_totem_Upgrade;
    Button btn_totem_Buy;
    Text txt_totem_buy_val;
    Text img_totem_buy;

    Dictionary<string, object> data = null;


    public void Find_obj(Dictionary<string, object> data_)
    {
        data = data_;


        img_totem = transform.Find("img_totem").GetComponent<Image>();
       txt_totem_Lv = transform.Find("txt_totem_Lv").GetComponent<Text>();
       txt_totem_name = transform.Find("txt_totem_name").GetComponent<Text>();
       txt_totem_sub = transform.Find("txt_totem_sub").GetComponent<Text>();
       txt_totem_val = transform.Find("txt_totem_val").GetComponent<Text>();
       btn_totem_Upgrade = transform.Find("btn_totem_Upgrade").GetComponent<Button>();
       txt_totem_add_reward = btn_totem_Upgrade.transform.Find("txt_totem_add_reward").GetComponent<Text>();
       txt_totem_price_val = btn_totem_Upgrade.transform.Find("txt_totem_price_val").GetComponent<Text>();
       img_totem_Upgrade = btn_totem_Upgrade.transform.Find("img_totem_Upgrade").GetComponent<Text>();
       btn_totem_Buy = transform.Find("btn_totem_Buy").GetComponent<Button>();
       txt_totem_buy_val = btn_totem_Buy.transform.Find("txt_totem_buy_val").GetComponent<Text>();
       img_totem_buy = btn_totem_Buy.transform.Find("img_totem_buy").GetComponent<Text>();

        Set_Item();
    }

    public void Set_Item()
    {
        txt_totem_name.text = data["name"].ToString();

    }

}
