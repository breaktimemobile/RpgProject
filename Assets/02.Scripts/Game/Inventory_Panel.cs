using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Panel : MonoBehaviour
{

    public Image img_Inventory;
    public Text txt_Inventory_Val;

    Item_Type item_Type = Item_Type.coin;
    Sprite sprite = null;

    public Item_Type Item_Type { get => item_Type; set => item_Type = value; }

    public void Set_Panel(Item_Type _Type,BigInteger _val)
    {
        img_Inventory = transform.Find("img_Inventory").GetComponent<Image>();
        txt_Inventory_Val = GetComponentInChildren<Text>();

        Item_Type = _Type;
        txt_Inventory_Val.text = UiManager.instance.GetGoldString(_val);
        img_Inventory.sprite = Utill.Get_Item_Sp(Item_Type);


    }

    public void Set_Inventory_Val( BigInteger _val)
    {
        txt_Inventory_Val.text = UiManager.instance.GetGoldString(_val);
    }
}
