using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    Image img_totem_Upgrade;
    Button btn_totem_Buy;
    Text txt_totem_buy_val;
    Image img_totem_buy;

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
       img_totem_Upgrade = btn_totem_Upgrade.transform.Find("img_totem_Upgrade").GetComponent<Image>();
       btn_totem_Buy = transform.Find("btn_totem_Buy").GetComponent<Button>();
       txt_totem_buy_val = btn_totem_Buy.transform.Find("txt_totem_buy_val").GetComponent<Text>();
       img_totem_buy = btn_totem_Buy.transform.Find("img_totem_buy").GetComponent<Image>();

        btn_totem_Upgrade.onClick.AddListener(() => Totem_Upgrade());
        btn_totem_Buy.onClick.AddListener(() => Totem_Buy());

        txt_totem_buy_val.text = "500";
        img_totem_buy.sprite = Utill.Get_Item_Sp((int)Item_Type.dia);

        txt_totem_name.text = data["name"].ToString();
        img_totem.sprite = Utill.Get_Totem_Sp((int)data["num"]);
        img_totem_Upgrade.sprite = Utill.Get_Item_Sp((Item_Type)data["price_type"]);

        Set_Item();


    }

    public void Set_Item()
    {
        Totem_info info_ = BackEndDataManager.instance.Totem_Data.totem_info.Find(x => x.int_num.Equals((int)data["num"]));

        int ability_type = (int)data["ability_type"];
        int _type = Ability_.Get_Ability_Type(ability_type);
        float val = (float)data["base_ability"] * (_type.Equals(0) ? 100 : 1);
        float add = Totem_.Get_Add_Reward((int)data["num"]);
        string sign = Ability_.Ability_Type_Sign(ability_type);

        txt_totem_Lv.text = string.Format("{0}.{1}","Lv", info_ == null ? 0 : info_.int_lv);
        
        txt_totem_sub.text = Ability_.Get_Ability_Nmae(ability_type);

        txt_totem_val.text = string.Format("{0}{1}", Totem_.Get_Reward((int)data["num"]), sign);

        txt_totem_add_reward.text = string.Format("+{0} ({1})",
          string.Format("{0}{1}", add, sign)  , (int)Totem_.totem_Lv);

        txt_totem_price_val.text = UiManager.instance.GetGoldString(Totem_.Get_Price((int)data["num"]));

        Check_Btn();

    }

    public void Check_Btn()
    {
        Totem_info info_ = BackEndDataManager.instance.Totem_Data.totem_info.Find(x => x.int_num.Equals((int)data["num"]));

        btn_totem_Upgrade.gameObject.SetActive(info_ != null);
        btn_totem_Buy.gameObject.SetActive(info_ == null);

        float percnet = (float)data["price_percent"] * 100;

        BigInteger total = Totem_.Get_Price((int)data["num"]);
        
        btn_totem_Upgrade.interactable = BackEndDataManager.instance.Get_Item((Item_Type)data["price_type"]) >= total;
        
        btn_totem_Buy.interactable = BackEndDataManager.instance.Get_Item(Item_Type.dia) >= 500;

    }

    public void Totem_Upgrade()
    {
        if (BackEndDataManager.instance.Get_Item((Item_Type)data["price_type"]) >= Totem_.Get_Price((int)data["num"]))
        {
            UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.totem_upgrade, (int)Totem_.totem_Lv);

            BackEndDataManager.instance.Set_Item((Item_Type)data["price_type"], 
                Totem_.Get_Price((int)data["num"]), Calculate_Type.mius);

            Totem_info info_ = BackEndDataManager.instance.Totem_Data.totem_info.Find(x => x.int_num.Equals((int)data["num"]));

            info_.int_lv += (int)Totem_.totem_Lv;

            BackEndDataManager.instance.Save_Totem_Data();

            Check_Btn();
            Set_Item();
        }
    }

    public void Totem_Buy()
    {
        if (BackEndDataManager.instance.Get_Item(Item_Type.dia) >= 500)
        {
            BackEndDataManager.instance.Set_Item(Item_Type.dia, 500, Calculate_Type.mius);

            Totem_info totem_Info = new Totem_info
            {
                int_num = (int)data["num"],
                int_lv = 1
            };

            BackEndDataManager.instance.Totem_Data.totem_info.Add(totem_Info);
            BackEndDataManager.instance.Save_Totem_Data();

           Check_Btn();
           Set_Item();

        }
    }
}
