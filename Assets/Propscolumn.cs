using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propscolumn : MonoBehaviour
{
    int count = -1;
    public Animator anim;
    public GameObject[] Rose;
    public GameObject FinishUI;
    public AudioSource grtRose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    void showRose() {
    Rose[count].GetComponent<Animator>().SetTrigger("Get");
        grtRose.Play();
        if (count == 3)
        {
            FinishUI.SetActive(true);
            FinishUI.GetComponent<FirstFinish_UI>().finish();
            
        }
    }

    public void setIntoGame() {
        anim.SetBool("In", true);
        count = count + 1;
    }

    public void setOuttheGame(){
        anim.SetBool("In", false);
        anim.SetTrigger("Out");
    }
}
