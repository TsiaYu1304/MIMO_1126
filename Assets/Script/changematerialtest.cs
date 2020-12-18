using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changematerialtest : MonoBehaviour
{
    public Material m_blue, m_yellow;
    public Sprite blue, yellow;
    bool isblue = false;
    float time = 0 ;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 2)
        {
            if (isblue)
            {
                rend.sprite = blue;
                rend.material = m_blue;
            }
            else
            {
                rend.sprite = yellow;
                rend.material = m_yellow;
            }
            time = 0;
            isblue = !isblue;
        }
        else {
            time = time + Time.deltaTime;
        }
    }
}
