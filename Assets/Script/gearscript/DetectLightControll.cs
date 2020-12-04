using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLightControll : MonoBehaviour
{

    [Header("物件參數")]
    public GameObject KillerRay;
    public GameObject DetectLight;
    bool KillPlayer = true;

    ContactPoint2D[] contacts = new ContactPoint2D[2];
    // Start is called before the first frame update


    public void StopDetect() {

        KillPlayer = false;
        DetectLight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && KillPlayer && !collision.isTrigger) {

            if (KillPlayer) {
                collision.GetContacts(contacts);
                Debug.Log(contacts[0].point);
                //KillerRay.GetComponent<KillerRayControll>().KillPlayer(contacts[0].point);
                KillerRay.GetComponent<KillerRayControll>().KillPlayer(collision.transform.position);
                KillPlayer = false;
            }

            
        }


    }

}
