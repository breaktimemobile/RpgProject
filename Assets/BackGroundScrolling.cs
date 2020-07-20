using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    [SerializeField] Transform[] m_bg = null;
    [SerializeField] float m_speed = 0f;

    float m_leftPosX = 0f;
    float m_rightPosX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float t_length = m_bg[0].GetComponent<RectTransform>().sizeDelta.x;
        m_leftPosX = -t_length;
        m_rightPosX = t_length * m_bg.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayManager.instance.Player_State.Equals(Player_State.Run))
        {

            for (int i = 0; i < m_bg.Length; i++)
            {
                m_bg[i].position += new Vector3(m_speed, 0, 0) * Time.deltaTime;

                if (m_bg[i].localPosition.x < m_leftPosX)
                {
                    Vector3 t_selfPos = m_bg[i].localPosition;
                    t_selfPos.Set(t_selfPos.x + m_rightPosX, t_selfPos.y, t_selfPos.z);
                    m_bg[i].localPosition = t_selfPos;

                }
            }
        }
    }
}
