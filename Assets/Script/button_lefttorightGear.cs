using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_lefttorightGear : MonoBehaviour
{
    public GameObject ControllGear;
    public AudioSource sound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            ControllGear.GetComponent<LefttorightGear>().setMove();
            sound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            ControllGear.GetComponent<LefttorightGear>().setMove();
        }
    }
}
