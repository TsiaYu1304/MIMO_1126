using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    public Animator anim;
    int FloatType = 1;
    // Start is called before the first frame update
   
    public void SetFloatType(int type) {
        Debug.Log(type);
        if (FloatType == 1)
        {
            if (type == 2)
            {
                anim.SetBool("Two", true);
                transform.position = new Vector3(transform.position.x, -1.37f, 0);
            }
            if (type == 0)
            {
                anim.SetBool("Zero", true);
            }
        }
        else if (FloatType == 2)
        {
            if (type == 1)
            {
                anim.SetBool("Two", false);
                transform.position = new Vector3(transform.position.x, -2.74f, 0);
            }
        }
        else if (FloatType == 0) {
            if (type == 1)
            {
                anim.SetBool("Zero", false);
                transform.position = new Vector3(transform.position.x, -2.74f, 0);
            }
        }


        FloatType = type;
    }
}
