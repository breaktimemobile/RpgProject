using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    
    public void Set_item(int num)
    {
        GetComponent<Image>().sprite = Utill.Get_Pet_Sp(num);
    }

    public void Set_Move()
    {
        transform.DOLocalMoveY(transform.localPosition.y + 20, Random.Range(1.0f,2.0f))
                     .SetEase(Ease.Linear)
                     .SetLoops(-1,LoopType.Yoyo);
    }
}
