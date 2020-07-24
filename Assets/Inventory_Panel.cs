using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Panel : MonoBehaviour
{

    public Image img_Inventory;
    public Text txt_Inventory_Val;

    Item_Type Item_Type = Item_Type.coin;
    Sprite sprite = null;

    public void Set_Inventory_Item(Item_Type _Type,BigInteger _val)
    {
        img_Inventory = transform.Find("img_Inventory").GetComponent<Image>();
        txt_Inventory_Val = GetComponentInChildren<Text>();

        Item_Type = _Type;
        txt_Inventory_Val.text = UiManager.instance.GetGoldString(_val);
        img_Inventory.sprite = Resources.Load<Sprite>("Item/icon_" + Item_Type.ToString());


    }
}
