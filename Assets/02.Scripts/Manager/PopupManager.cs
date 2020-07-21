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
        if (objects.Count >= 1)
        {
            GameObject obj = objects.Pop();
            obj.gameObject.SetActive(false);
            Debug.Log(obj.name);
        }

    }

    public static void Open_Popup(GameObject obj)
    {
        objects.Push(obj);
        obj.gameObject.SetActive(true);

    }
}
