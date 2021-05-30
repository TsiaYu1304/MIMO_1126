using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaLogGUIControl : MonoBehaviour
{
    public Animator anim;
    public AudioSource openSFX;


    // Start is called before the first frame update
    void Start()
    {
    }



    public void opendialogGUI() {
        anim.SetBool("open", true);
        openSFX.Play();

    }
    public void closedialogGUI() {
        anim.SetBool("open", false);
        anim.SetBool("close", true);

    }

    public void setInactive()
    {
        
        gameObject.SetActive(false);
        anim.SetBool("close", false);

    }
}
