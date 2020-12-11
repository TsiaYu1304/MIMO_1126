using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_killEnemy : MonoBehaviour
{
    public GameObject killLaser;
    bool cantrigger = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void canPush() {
        cantrigger = true;
    }

    public void cannotPush()



    {
        cantrigger = false;
    }

    void OpenLaser() {
        killLaser.SetActive(true);
        killLaser.GetComponent<LaserTut>().openLaser();
    }

    void CloseLaser() {
        killLaser.GetComponent<LaserTut>().closeLaser();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            if(cantrigger) OpenLaser();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            if (cantrigger) CloseLaser();
        }
    }
}
