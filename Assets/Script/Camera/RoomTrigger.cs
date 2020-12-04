using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject Room;
    public GameObject cvcamera;
    int player = 0;
    // Start is called before the first frame update
    private void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 2) {
            cvcamera.SetActive(true);
            Room.GetComponent<Camera_ver2>().OpenCamera();

            player = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            player = player + 1;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            player = player - 1;

        }
    }

}
