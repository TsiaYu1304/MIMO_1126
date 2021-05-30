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
    public Transform ReplayPoint;
    public GameObject Mimi, Momo;
    

    public GameObject playerCombine;

    [Header("0往左 1往下 2往右")]
    public int Camerakind = 0;
    public GameObject lastCamera;

    private void Start()
    {
        //Gateobject.transform.parent = null;
        movePoint.parent = null;
        ReplayPoint.parent = null;
    }


    public void OpenCamera() {
        
        lastCamera.SetActive(false);
        clocktime = true;
        playerCombine.GetComponent<CombinePlayerControll>().camera = cvcamera;
        Mimi.GetComponent<PlayerMovement>().setReplayPoint(ReplayPoint);
        Momo.GetComponent<PlayerMovement>().setReplayPoint(ReplayPoint);
    }

    private void Update()
    {
        

        if (clocktime) {
            StartClock();
        }
        if (canmove) {
           // float diff = transform.position.x - movePoint.position.x;
            if (Camerakind == 0)
            {
                float diff = transform.position.x - movePoint.position.x;
                transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 4.5f * Time.deltaTime);
                if (diff < 0.05f)
                {
                    transform.position = movePoint.position;
                    
                    canmove = false;
                    Gateobject.GetComponent<CameraGate>().Closegate();
                    
                }
            }
            else if (Camerakind == 1)
            {
                float diff = transform.position.y - movePoint.position.y;
                transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 13.5f * Time.deltaTime);
                if (diff < 0.05f)
                {
                    transform.position = movePoint.position;

                    canmove = false;
                    Gateobject.GetComponent<CameraGate>().Closegate();
                }
            }
            else if (Camerakind == 2)
            {
                float diff = movePoint.position.x - transform.position.x;
                transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 4.5f * Time.deltaTime);
                if (diff < 0.05f)
                {
                    transform.position = movePoint.position;

                    canmove = false;
                    Gateobject.GetComponent<CameraGate>().Closegate();
                }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //cvcamera.SetActive(false);
    }
}
