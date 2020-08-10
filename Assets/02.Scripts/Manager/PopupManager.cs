using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PopupManager
{

    public PopupManager()
    {

    }

    public static Stack<GameObject> objects = new Stack<GameObject>();

    public static void Close_Popup()
    {
        Debug.Log(objects.Count);

        if (objects.Count >= 1)
        {
            GameObject obj = objects.Pop();

            obj.gameObject.SetActive(false);
            Debug.Log("close " + obj.name);

        }

    }

    public static void Open_Popup(GameObject obj)
    {
        Debug.Log(objects.Count);

        objects.Push(obj);
        obj.gameObject.SetActive(true);

    }


    public static void All_Close_Popup()
    {
        int cnt = objects.Count;
        for (int i = 0; i < cnt; i++)
        {
            GameObject obj = objects.Pop();

            obj.gameObject.SetActive(false);


        }

    }
}
