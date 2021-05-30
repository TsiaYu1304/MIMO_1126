using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windsoundtrigger : MonoBehaviour
{
    public GameObject windcontrol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            windcontrol.GetComponent<WindControl>().setAudioPlay();
           
        }
    }
}
