using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content_Panel : MonoBehaviour
{
    private Button btn_content;

    private Text txt_Content_Name;

    private Image img_Reward_0;
    private Image img_Reward_1;
    private Image img_Reward_2;

    public void Set_Panel(Dictionary<string, object> data)
    {
        btn_content = GetComponent<Button>();

        txt_Content_Name  = transform.Find("txt_Content_Name").GetComponent<Text>();
        img_Reward_0 =  transform.Find("img_Reward_0").GetComponent<Image>();
        img_Reward_1 =  transform.Find("img_Reward_1").GetComponent<Image>();
        img_Reward_2 =  transform.Find("img_Reward_2").GetComponent<Image>();

        txt_Content_Name.text = data["name"].ToString();
        img_Reward_0.sprite = Utill.Get_Item_Sp((Item_Type)(int)data["reward_0"]);
        img_Reward_1.sprite = Utill.Get_Item_Sp((Item_Type)(int)data["reward_1"]);

        btn_content.onClick.AddListener(() => UiManager.instance.Change_Content_Popup((Popup_Type)(int)data["num"]));
    }
}
