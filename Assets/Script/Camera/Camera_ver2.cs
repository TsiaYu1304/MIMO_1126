using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ver2 : MonoBehaviour
{
    float movetime = 0;
    bool clocktime = false;
    public GameObject cvcamera;
    bool canmove = false;
    public GameObject Gateobject;
    public Transform movePoint;
   
    

    public GameObject playerCombine;

    [Header("0往左 1往下 2往右")]
    public int Camerakind = 0;
    public GameObject lastCamera;

    private void Start()
    {
        Gateobject.transform.parent = null;
        movePoint.parent = null;
    }


    public void OpenCamera() {
        
        lastCamera.SetActive(false);
        clocktime = true;
        playerCombine.GetComponent<CombinePlayerControll>().camera = cvcamera;
    }

    private void Update()
    {
       
        if (clocktime) {
            StartClock();
        }
        if (canmove) {
            float diff = transform.position.x - movePoint.position.x;
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 5.0f*Time.deltaTime);
            if (diff < 0.05f) {
                transform.position = movePoint.position;
                canmove = false; 
            }
        }

    }

    public void starttomove(){
        canmove = true;
    }


    void StartClock() {
        if (movetime <= 2.0f) movetime = movetime + Time.deltaTime;
        else {
            clocktime = false;
            Gateobject.GetComponent<CameraGate>().Opengate();
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        //cvcamera.SetActive(false);
    }
}
