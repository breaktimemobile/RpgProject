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

    public void Set_Inventory_Item(Item_Type _Type,BigInteger _val)
    {
        Item_Type = _Type;
        GetComponentInChildren<Text>().text = UiManager.instance.GetGoldString(_val);

        //img_Inventory.sprite = Resources.Load("Item/icon_" + Item_Type.ToString()) as Sprite;


    }
}
