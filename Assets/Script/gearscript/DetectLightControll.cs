using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLightControll : MonoBehaviour
{

    [Header("物件參數")]
    public GameObject KillerRay;
    public GameObject DetectLight;
    public bool canRotate = false;
    bool RotatetoLeft = true;
    bool KillPlayer = true;
    float Rotateangle = 0;
    public float AddAngle = 5;

    ContactPoint2D[] contacts = new ContactPoint2D[2];
    // Start is called before the first frame update
    private void Start()
    {
        KillerRay.GetComponent<KillerRayControll>().setAnimOpen();
    }
    private void Update()
    {
        if (canRotate) Rotation();
    }

    void Rotation() {
        if (RotatetoLeft)
        {
            Rotateangle = Rotateangle - AddAngle * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, Rotateangle);
            if (Rotateangle < -30) RotatetoLeft = false;
        }
        else {
            Rotateangle = Rotateangle + AddAngle * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, Rotateangle);
            if (Rotateangle > 30) RotatetoLeft = true;
        }
    }

    public void StopDetect() {

        KillPlayer = false;
        DetectLight.SetActive(false);
        KillerRay.GetComponent<KillerRayControll>().setAnimClose();
    }
    public void OpenDetect() {
        KillPlayer = true;
        DetectLight.SetActive(true);
        KillerRay.GetComponent<KillerRayControll>().setAnimOpen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && KillPlayer && !collision.isTrigger) {

            if (KillPlayer) {
                KillerRay.GetComponent<KillerRayControll>().KillPlayer(collision.transform.position);
                collision.GetComponent<PlayerMovement>().LaserDie();
               
            }

            
        }


    }

}

