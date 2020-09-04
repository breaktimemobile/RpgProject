using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Job_Panel : MonoBehaviour
{
    Image img_Job;
    Text txt_job_name;
    Text txt_job_Lv;
    Slider Slider_time;
    Text txt_job_reward;
    Text txt_job_time;
    Button btn_job;
    Text txt_job_add_reward;
    Text txt_job_price_val;
    Image img_job_Upgrade;

    Dictionary<string, object> data = null;

    public void Find_obj(Dictionary<string, object> data_)
    {
        data = data_;

        img_Job = transform.Find("img_Job").GetComponent<Image>();
        txt_job_name = transform.Find("txt_job_name").GetComponent<Text>();
        txt_job_Lv = transform.Find("txt_job_Lv").GetComponent<Text>();
        Slider_time = transform.Find("Slider_time").GetComponent<Slider>();
        txt_job_reward = transform.Find("txt_job_reward").GetComponent<Text>();
        txt_job_time = transform.Find("txt_job_time").GetComponent<Text>();
        btn_job = transform.Find("btn_job").GetComponent<Button>();
        txt_job_add_reward = btn_job.transform.Find("txt_job_add_reward").GetComponent<Text>();
        txt_job_price_val = btn_job.transform.Find("txt_job_price_val").GetComponent<Text>();
        img_job_Upgrade = btn_job.transform.Find("img_job_Upgrade").GetComponent<Image>();

        btn_job.onClick.AddListener(() => Job_Upgrade());

        Set_Item();
        Set_Btn();
    }

    public void Set_Item()
    {
        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

        int num = (int)data["num"];

        img_Job.sprite = Utill.Get_Job_Sp(num);
        txt_job_name.text = data["name"].ToString();
        txt_job_Lv.text = string.Format("{0}.{1}", "Lv", job_ == null ? 0 : job_.int_lv);
        txt_job_reward.text = UiManager.instance.GetGoldString(Job_.Get_Reward(num));
        txt_job_time.text = Job_.Get_Time(num);
        img_job_Upgrade.sprite = Utill.Get_Item_Sp((Item_Type)data["price_type"]);
        Set_Item_Upgrade(Job_.Job_Lv);

        Slider_time.maxValue = (int)data["job_time"];
    }

    public void Set_Item_Upgrade(Character_Lv _Lv)
    {
        txt_job_add_reward.text = string.Format("+{0} ({1})", UiManager.instance.GetGoldString(Job_.Get_Add_Reward((int)data["num"])), (int)_Lv);
        txt_job_price_val.text = UiManager.instance.GetGoldString(Job_.Get_Price((int)data["num"]));
    }

    public void Set_Btn()
    {
        if(data != null)
        btn_job.interactable = BackEndDataManager.instance.Get_Item((Item_Type)data["reward_0"]) >= Job_.Get_Price((int)data["num"]);
    }

    private void OnEnable()
    {
        Set_Btn();
        Check_Slider();
    }

    public void Check_Slider()
    {
        StopCoroutine("Co_Slider");

        StartCoroutine("Co_Slider");

    }

    IEnumerator Co_Slider()
    {
        yield return false;

        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

        if (job_ != null)
        {

            int job_time = (int)data["job_time"];

            DateTime GiftTime = DateTime.Parse(job_.str_time);

            while (true)
            {
                TimeSpan LateTime = GiftTime - BackEndDataManager.instance.WebCheck();

                int diffHour = LateTime.Hours; //30
                int diffMiniute = LateTime.Minutes; //30
                int diffSecond = LateTime.Seconds; //0

                txt_job_time.text = string.Format("{0:00}:{1:00}:{2:00}", diffHour, diffMiniute, diffSecond);

                Slider_time.value = job_time - ((float)LateTime.TotalSeconds - 1);

                yield return new WaitForSeconds(0.01f);

                if (LateTime.TotalSeconds < 1)
                {
                    GiftTime = DateTime.Parse(job_.str_time);
                }
            }

        }
    }

    public void Job_Upgrade()
    {
        if (BackEndDataManager.instance.Get_Item((Item_Type)data["reward_0"]) >= Job_.Get_Price((int)data["num"]))
        {

            BackEndDataManager.instance.Set_Item((Item_Type)data["reward_0"], Job_.Get_Price((int)data["num"]),Calculate_Type.mius);

            Job_info info_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

            if (info_ == null)
            {
                Job_info job_ = new Job_info()
                {
                    int_lv = (int)Job_.Job_Lv,
                    int_num = (int)data["num"],
                    str_time = BackEndDataManager.instance.WebCheck().AddSeconds((int)data["job_time"] + 1).ToString()
                };

                BackEndDataManager.instance.Job_Data.job_info.Add(job_);
            }
            else
            {
                info_.int_lv += (int)Job_.Job_Lv;
            }

            UiManager.instance.Check_Progress_Reward(Progress_Reward_Type.job_upgrade, (int)Job_.Job_Lv);
            Game_info_.Set_Game_Info(Game_Info_Type.job_upgrade, (int)Job_.Job_Lv);
            Quest_.Check_Daily_Quest(Daily_Quest_Type.job_upgrade, (int)Job_.Job_Lv);

            BackEndDataManager.instance.Save_Job_Data();

            Set_Item();
            Check_Slider();
        }
     
  
    }
}
