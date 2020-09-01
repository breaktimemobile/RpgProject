using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Post_Panel : MonoBehaviour
{
    Text txt_post_name;
    Button btn_post_Buy;
    Text txt_post_time;

    List<Inventory_Panel> inventory_Panels = new List<Inventory_Panel>();

    Post_info post_Info;

    public void Set_Post(Post_info _Info)
    {
        txt_post_name = transform.Find("txt_post_name").GetComponent<Text>();
        btn_post_Buy = transform.Find("btn_post_Buy").GetComponent<Button>();
        txt_post_time = btn_post_Buy.transform.Find("txt_post_time").GetComponent<Text>();

        inventory_Panels = transform.Find("pos_item").GetComponentsInChildren<Inventory_Panel>(true).ToList();

        post_Info = _Info;

        txt_post_name.text = post_Info.str_name;

        btn_post_Buy.onClick.RemoveAllListeners();
        btn_post_Buy.onClick.AddListener(() => Get_Post());

        foreach (var item in inventory_Panels)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < post_Info.item_Info.Count; i++)
        {
            BigInteger big = BigInteger.Parse(post_Info.item_Info[i].str_val);
            inventory_Panels[i].Set_Panel((Item_Type)post_Info.item_Info[i].type, big);
            inventory_Panels[i].gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("Co_Time");
    }

    IEnumerator Co_Time()
    {
        DateTime GiftTime = DateTime.Parse(post_Info.date);

        while (true)
        {

            TimeSpan LateTime = GiftTime - DateTime.Now;

            int diffday = LateTime.Days;
            int diffHour = LateTime.Hours; //30
            int diffMiniute = LateTime.Minutes; //30
            int diffSecond = LateTime.Seconds; //0

       
            txt_post_time.text = string.Format("{0:00}:{1:00}:{2:00}", diffday * 24 + diffHour, diffMiniute, diffSecond);

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void Get_Post()
    {
        foreach (var item in post_Info.item_Info)
        {
            BigInteger big = BigInteger.Parse(item.str_val);
            BackEndDataManager.instance.Set_Item((Item_Type)item.type, big,Calculate_Type.plus);
            BackEndDataManager.instance.Post_Data.post_Info.Remove(post_Info);
            BackEndDataManager.instance.Save_Post_Data();
        }

        Destroy(gameObject);
    }
}
