using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar_panel : MonoBehaviour
{
    Text txt_day;
    Image img_item;
    Text  txt_item_val;
     Image img_check;

    public int int_day = 0;

    public void Set_Item(int i)
    {
        txt_day = transform.Find("txt_day").GetComponent<Text>();
        img_item = transform.Find("img_item").GetComponent<Image>();
        txt_item_val = transform.Find("txt_item_val").GetComponent<Text>();
        img_check = transform.Find("img_check").GetComponent<Image>();

        int_day = i;

        txt_day.text = i.ToString();

        Check();

    }

    public void Check()
    {
            
        img_check.gameObject.SetActive(int_day < BackEndDataManager.instance.Player_Data.int_calendar);

    }
}
