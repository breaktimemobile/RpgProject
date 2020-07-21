using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Damege : MonoBehaviour
{
  
    public void Set_Txt(int damege)
    {
        GetComponent<Text>().text = damege.ToString();

        transform.DOLocalMoveY(10, 1.0f);
        GetComponent<Text>().DOFade(0, 1.0f).OnComplete(() =>{
            Destroy(gameObject);
        });

    }
}
