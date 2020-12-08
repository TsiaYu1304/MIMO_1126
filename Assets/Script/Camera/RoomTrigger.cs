using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject Room;
    public GameObject cvcamera;
    public GameObject lastCamera;
    int camerakind;
    int player = 0;
    // Start is called before the first frame update
    private void Start()
    {
        transform.parent = null;
        camerakind = Room.GetComponent<Camera_ver2>().Camerakind;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 2) {
            cvcamera.SetActive(true);
            if (camerakind != 1) Room.GetComponent<Camera_ver2>().OpenCamera();
            else { lastCamera.SetActive(false); }
            player = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            player = player + 1;

        }

        if (collision.CompareTag("CombinePlayer") && !collision.isTrigger) {
            player = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //player = player - 1;

        }
    }

}
