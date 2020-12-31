using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFinish_UI : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Rose;
    public AudioSource s_finish;
    bool canShow = false;
    float time = 1;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShow) {
            if (time > 0.2f)
            {
                Rose[count].SetActive(true);
                count = count + 1;
                if (count == 5) {
                    canShow = false;
                }
                time = 0;
            }
            else {
                time = time + Time.deltaTime;
            }
        }
    }

    public void StarttoShowRose() {
        canShow = true;
    }

    public void finish() {
        anim.SetTrigger("Finish");
        s_finish.Play();
    }
}
