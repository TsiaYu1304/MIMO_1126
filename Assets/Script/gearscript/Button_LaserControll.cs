using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_LaserControll : MonoBehaviour
{
    [Header("物件控制")]
     public GameObject LaserFire;
    bool TurnOn = true;
    bool PlayerTriggerme = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerLaser() {

        if (TurnOn) TurnoffLaser(); //燈如果開著
        else TurnOnLaser();
    }

    public void TurnoffLaser() {
        if(PlayerTriggerme) LaserFire.GetComponent<LaserTut>().DisableLLaser();
    }

    public void TurnOnLaser() {
        if (PlayerTriggerme) LaserFire.GetComponent<LaserTut>().EnableLaser();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerTriggerme = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerTriggerme = false;
        }
    }

}
