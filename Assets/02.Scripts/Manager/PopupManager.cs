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
        Debug.Log("open "+obj.name);

    }
}
