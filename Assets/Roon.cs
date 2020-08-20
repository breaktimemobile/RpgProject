using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roon : MonoBehaviour
{
    Image img_roon;
    Image img_plus;
    Image img_lock;


    public void Set_Item(Roon_Slot roon_Slot)
    {
        img_roon = transform.Find("img_roon").GetComponent<Image>();
        img_plus = transform.Find("img_plus").GetComponent<Image>();
        img_lock = transform.Find("img_lock").GetComponent<Image>();

        img_roon.gameObject.SetActive(roon_Slot.int_roon != -1);
        img_plus.gameObject.SetActive(!roon_Slot.isLock && roon_Slot.int_roon.Equals(-1));
        img_lock.gameObject.SetActive(roon_Slot.isLock);

        GetComponent<Button>().onClick.AddListener(() => Open_Roon_Popup(roon_Slot.int_slot));
        GetComponent<Button>().interactable = !roon_Slot.isLock;
    }

    public void Open_Roon_Popup(int num)
    {

    }
}
