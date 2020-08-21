using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roon : MonoBehaviour
{
    Image img_roon;
    Image img_plus;
    Image img_lock;

    Roon_Slot roon_Slot;

    Roon_Info info_;

    public void Set_Item_Slot(Roon_Slot Slot_)
    {
        roon_Slot = Slot_;

        img_roon = transform.Find("img_roon").GetComponent<Image>();
        img_plus = transform.Find("img_plus").GetComponent<Image>();
        img_lock = transform.Find("img_lock").GetComponent<Image>();

        Debug.Log("roon_Slot " + roon_Slot.int_roon.type);

        img_roon.gameObject.SetActive(roon_Slot.int_roon.type != -1);
        img_plus.gameObject.SetActive(!roon_Slot.isLock && roon_Slot.int_roon.type.Equals(-1));
        img_lock.gameObject.SetActive(roon_Slot.isLock);

        img_roon.sprite = Utill.Get_Roon_Sp(roon_Slot.int_roon.type);

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => Open_Roon_Popup());
        GetComponent<Button>().interactable = !roon_Slot.isLock;
    }

    public void Set_Item(Roon_Info slot_)
    {
        info_ = slot_;

        img_roon = transform.Find("img_roon").GetComponent<Image>();
        img_plus = transform.Find("img_plus").GetComponent<Image>();
        img_lock = transform.Find("img_lock").GetComponent<Image>();

        img_roon.gameObject.SetActive(true);
        img_plus.gameObject.SetActive(false);
        img_lock.gameObject.SetActive(false);

        img_roon.sprite = Utill.Get_Roon_Sp(info_.type);

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => Open_Roon_Mount());
    }

    public void Open_Roon_Mount()
    {
        Weapon_.roon_Info = info_;
        UiManager.instance.Open_Roon_Stat(true);
    }

    public void Open_Roon_Popup()
    {
        Weapon_.roon_Slot = roon_Slot;

        if (roon_Slot.int_roon.type == -1)
        {

            UiManager.instance.Open_My_Roon();

        }
        else
        {

            Weapon_.roon_Info = Weapon_.roon_Slot.int_roon;
            UiManager.instance.Open_Roon_Stat(false);

        }
    }
}
