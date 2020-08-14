using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Numerics;

public class Damege : MonoBehaviour
{
  
    public void Set_Txt(BigInteger damege)
    {
        GetComponent<Text>().text = UiManager.instance.GetGoldString(damege);

        transform.DOLocalMoveY(transform.localPosition.y + 10, 5.0f);
        GetComponent<Text>().DOFade(0, 1.0f).OnComplete(() =>{
            Destroy(gameObject);
        });

    }
}
