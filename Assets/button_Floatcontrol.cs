using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Floatcontrol : MonoBehaviour
{
    public GameObject FloatFan;
    public int FloatType = 1;
    bool ToZero = true;
    bool ToTwo = false;

    SpriteRenderer rend;
    public Sprite type0, type1, type2;

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
            }
        }
        else {
            if (FloatType != 2)
            {
                FloatType = FloatType + 1;
                
            }
            else {
                ToZero = true;
            }
        }
        setSprite();
        FloatFan.GetComponent<FloatTrigger>().setFloatType(FloatType);
        
    }

    void setSprite() {
        switch (FloatType) {
            case 0:
                rend.sprite = type0;
                break;
            case 1:
                rend.sprite = type1;
                break;
            case 2:
                rend.sprite = type2;
                break;
            default:
                break;
        }    
    }


}
