using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Floatcontrol : MonoBehaviour
{
    public GameObject FloatFan;
    public GameObject wind;
    public int FloatType = 1;
    public bool ToZero = true;
    bool ToTwo = false;
    public AudioSource playerpush;

    SpriteRenderer rend;
    public Sprite type0, type1, type2;
    public Material m_type0, m_type1, m_type2;

    public

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushFloatButton() {
        if (ToZero)
        {
            if (FloatType != 0)
            {
                FloatType = FloatType - 1;
                
            }
            else
            {
                ToZero = false;
                FloatType = FloatType + 1;
            }
        }
        else {
            if (FloatType != 2)
            {
                FloatType = FloatType + 1;
                
            }
            else {
                ToZero = true;
                FloatType = FloatType - 1;
            }
        }
        setSprite();
        
        FloatFan.GetComponent<FloatTrigger>().setFloatType(FloatType);
        wind.GetComponent<WindControl>().SetFloatType(FloatType);
        
    }

    public void ResetFlow() {

        FloatType = 1;
        setSprite();

        FloatFan.GetComponent<FloatTrigger>().setFloatType(FloatType);
        wind.GetComponent<WindControl>().SetFloatType(FloatType);
    }

    void setSprite() {
        switch (FloatType) {
            case 0:
                rend.sprite = type0;
                rend.material = m_type0;
                break;
            case 1:
                rend.sprite = type1;
                rend.material = m_type1;
                break;
            case 2:
                rend.sprite = type2;
                rend.material = m_type2;
                break;
            default:
                break;
        }
        playerpush.Play();
    }


    

}
