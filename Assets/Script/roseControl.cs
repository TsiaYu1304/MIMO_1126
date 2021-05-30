using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseControl : MonoBehaviour
{
    public float floatSpeed = 2;
    bool isUp = true;
    Vector3 myPoint;
    public GameObject UIRose;
    public GameObject light;
    public GameObject Propscolumn;
    public Animator anim;
    public AudioSource gotitem;
    public GameObject myEffect;


    float time;
    bool startclock;
    // Start is called before the first frame update
    void Start()
    {
        myPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isUp) {
        //    transform.position = transform.position + new Vector3(0, floatSpeed * Time.deltaTime, 0);
        //    if (transform.position.y >= (myPoint.y + 0.07f)) isUp = false;
        //}
        //else
        //{
        //    transform.position = transform.position + new Vector3(0, -floatSpeed * Time.deltaTime, 0);
        //    if (transform.position.y <= (myPoint.y - 0.07f)) isUp = true;
        //}

        if (startclock) {
            if (time < 1.8f)
            {
                time = time + Time.deltaTime;
            }
            else {
                startclock = false;
                time = 0;
                myEffect.SetActive(false);
            }
        }
    }

    public void showcolumn() {
        Propscolumn.GetComponent<Propscolumn>().setIntoGame();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            anim.SetTrigger("Got");
            light.GetComponent<Animator>().SetTrigger("Got");
            gotitem.Play();
            myEffect.SetActive(true);
        }
    }
}
