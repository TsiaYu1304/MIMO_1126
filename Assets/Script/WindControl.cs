using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    public Animator anim;
    public int FloatType = 1;
    // Start is called before the first frame update
    public bool audioPlay = false;
    public AudioSource wind1;
    public AudioSource wind2;

    public void setAudioPlay() {
        audioPlay = true;
        wind1.Play();
    }

    public void SetFloatType(int type) {
        if (FloatType == 1)
        {
            if (type == 2)
            {
                anim.SetBool("Two", true);
                if (audioPlay)
                {
                    wind1.Stop();
                    wind2.Play();
                }
                transform.position = new Vector3(transform.position.x, -1.37f, 0);
            }
            if (type == 0)
            {
                if (audioPlay)
                {
                    wind1.Stop();
                }
                anim.SetBool("Zero", true);
            }
        }
        else if (FloatType == 2)
        {
            if (type == 1)
            {
                anim.SetBool("Two", false);
                if (audioPlay)
                {
                    wind2.Stop();
                    wind1.Play();
                }
                transform.position = new Vector3(transform.position.x, -2.74f, 0);
            }
        }
        else if (FloatType == 0) {
            if (type == 1)
            {
                anim.SetBool("Zero", false);
                if (audioPlay) wind1.Play();
                transform.position = new Vector3(transform.position.x, -2.74f, 0);
            }
        }


        FloatType = type;
    }
}
