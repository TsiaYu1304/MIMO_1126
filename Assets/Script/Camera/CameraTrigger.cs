using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    public GameObject cvcamera;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {
            cvcamera.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cvcamera.SetActive(false);
    }
}
