using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Camera : MonoBehaviour
{

    int playerscount = 0;

    public GameObject Cam;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (playerscount == 2) {
            playerscount = -100;
            Cam.GetComponent<Camera_ver2>().starttomove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerscount = playerscount + 1;
        }
    }
}
