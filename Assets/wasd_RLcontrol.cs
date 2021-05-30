using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd_RLcontrol : MonoBehaviour
{

    public bool RLcontrol = false;
    public GameObject controlGear;
    public Sprite Left_sprite;
    public Sprite Right_sprite;
    public SpriteRenderer srend;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void SwitchButton() {

        int pos = controlGear.GetComponent<wasdGear_Move>().PositionStatus();
        if (RLcontrol)
        {
            if (pos == 2)
            {
                controlGear.GetComponent<wasdGear_Move>().moveDirection(RLcontrol);
                srend.sprite = Right_sprite;
                
                
            }
            else if (pos == 3) {

                controlGear.GetComponent<wasdGear_Move>().moveDirection(RLcontrol);
                srend.sprite = Left_sprite;
            }
        }
        else {
            if (pos == 2 )
            {
                controlGear.GetComponent<wasdGear_Move>().moveDirection(RLcontrol);
                srend.sprite = Right_sprite;
            }
            else if (pos == 1)
            {

                controlGear.GetComponent<wasdGear_Move>().moveDirection(RLcontrol);
                srend.sprite = Left_sprite;
            }
        }

    }

    
}
