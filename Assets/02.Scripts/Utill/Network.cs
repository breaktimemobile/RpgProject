using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network
{
    string url = "www.naver.com";

    DateTime dateTime;

    public DateTime Get_WebCheck()
    {
        return dateTime;
    }

   IEnumerator WebCheck()
    {
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {

            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");
                dateTime = DateTime.Parse(date).ToUniversalTime();
                Debug.Log(dateTime.ToString());
            }
        }
    }

}
