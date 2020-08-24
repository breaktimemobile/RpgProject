using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Job_Panel : MonoBehaviour
{
    Image img_Job;
    Text txt_job_name;
    Slider Slider_time;
    Text txt_job_val;
    Text txt_job_time;
    Button btn_job;
    Text txt_job_Upgrade;
    Text txt_job_Upgrade_val;
    Image img_job_Upgrade;

    Dictionary<string, object> data;

    public void Find_obj(Dictionary<string, object> data_)
    {
        data = data_;

        img_Job = transform.Find("img_Job").GetComponent<Image>();
        txt_job_name = transform.Find("txt_job_name").GetComponent<Text>();
        Slider_time = transform.Find("Slider_time").GetComponent<Slider>();
        txt_job_val = transform.Find("txt_job_val").GetComponent<Text>();
        txt_job_time = transform.Find("txt_job_time").GetComponent<Text>();
        btn_job = transform.Find("btn_job").GetComponent<Button>();
        txt_job_Upgrade = btn_job.transform.Find("txt_job_Upgrade").GetComponent<Text>();
        txt_job_Upgrade_val = btn_job.transform.Find("txt_job_Upgrade_val").GetComponent<Text>();
        img_job_Upgrade = btn_job.transform.Find("img_job_Upgrade").GetComponent<Image>();

        Set_Item();
    }

    public void Set_Item()
    {
        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

        img_Job.sprite = Utill.Get_Job_Sp((int)data["num"]);
        txt_job_name.text = data["name"].ToString();

        Slider_time.value = 0;

        BigInteger big = BigInteger.Parse(data["reward_val_0"].ToString(), System.Globalization.NumberStyles.Float);

        txt_job_val.text = "0";

        if (job_ != null)
        {
            int re = (int)((float)data["reward_add"] * 100);
            BigInteger total = big + (big * re / 100) * (job_.int_lv -1);
            txt_job_val.text = UiManager.instance.GetGoldString(total);

        }

        int d_time = (int)data["job_time"];
        txt_job_time.text = string.Format("{0:00}:{1:00}:{2:00}"
            , d_time / 3600, (d_time % 3600) / 60, (d_time % 3600) % 60);

        img_job_Upgrade.sprite = Utill.Get_Item_Sp((Item_Type)data["price_type"]);
        Set_Item_Upgrade(Character_Lv.lv_1);

    }

    public void Set_Item_Upgrade(Character_Lv _Lv)
    {
        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

        BigInteger reward = BigInteger.Parse(data["reward_val_0"].ToString(), System.Globalization.NumberStyles.Float);
        BigInteger price = BigInteger.Parse(data["price_val"].ToString(), System.Globalization.NumberStyles.Float);

        int re = (int)((float)data["reward_add"] * 100);
        int re_2 = (int)((float)data["price_percent"] * 100);

        BigInteger total = job_ == null ? reward : (Calculate.Price(reward, re, 0, (int)_Lv) * re) / 100;
        BigInteger total_2 = Calculate.Price(price, re_2, 0, (int)_Lv);

        txt_job_Upgrade.text = string.Format("+{0} ({1})", UiManager.instance.GetGoldString(total), (int)_Lv);
        txt_job_Upgrade_val.text = UiManager.instance.GetGoldString(total_2);

    }

    public void Job_Upgrade()
    {

    }
}
