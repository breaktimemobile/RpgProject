using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet_Panel : MonoBehaviour
{
    Image img_pet;
    Text txt_pet_lv;

    Pet_info pet_Info;

    public void Set_Panel(int num)
    {

        pet_Info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(num));

        img_pet = transform.Find("img_pet").GetComponent<Image>();
        txt_pet_lv = transform.Find("txt_pet_lv").GetComponent<Text>();

        img_pet.sprite = Utill.Get_Pet_Sp(num);

        Set_Txt();

        GetComponent<Button>().onClick.AddListener(() => UiManager.instance.Open_Pet_Panel(num));

    }

    public void Set_Txt()
    {
        txt_pet_lv.gameObject.SetActive(pet_Info != null);
        txt_pet_lv.text = string.Format("{0}.{1}", "lv.", pet_Info != null ? pet_Info.int_lv.ToString() : "0");
    }
}
