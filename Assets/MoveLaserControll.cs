using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaserControll : MonoBehaviour
{
    public Transform LeftPoint, RightPoint;
    bool moving = false;
    bool moveDir_L = false;

    public GameObject SensitiveLine;
    public GameObject LaserHead;
    public GameObject Laser1;
    public float movespeed;
    public bool auto = false;
    // Start is called before the first frame update
    void Start()
    {
        Laser1.GetComponent<LaserTut>().openLaser();
        LaserHead.GetComponent<KillerRayControll>().setAnimOpen();
        //Laser1.GetComponent<LaserTut>().startmove(LeftPoint, RightPoint);
        if (auto) {
            StarttoMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) { //如果現在正在移動的話
            if (moveDir_L) //往左
            {
                if ((LaserHead.transform.position.x - LeftPoint.position.x) <= 0.1f)
                { //與左點對齊
                    LaserHead.transform.position = LeftPoint.position;
                    if (auto) {
                        moveDir_L = false;
                        Laser1.GetComponent<LaserTut>().startmove(LeftPoint, RightPoint);
                    }
                    else
                    {
                        moving = false;
                    }
                    
                }
                else
                { //往左點移動 
                    LaserHead.transform.position = new Vector3(LaserHead.transform.position.x - movespeed * Time.deltaTime, LaserHead.transform.position.y, LaserHead.transform.position.z);
                }
            }
            else {  //往右
                if ((RightPoint.position.x -LaserHead.transform.position.x) <= 0.1f)
                { //與右點對齊

                    LaserHead.transform.position = RightPoint.position;
                    moveDir_L = true;
                }
                else
                { //往右點移動 
                    LaserHead.transform.position = new Vector3(LaserHead.transform.position.x + movespeed * Time.deltaTime, LaserHead.transform.position.y, LaserHead.transform.position.z);
                }
            }
        }
    }

    public void CloseMoveLaser() {
        SensitiveLine.SetActive(false);
        moving = false;
        Laser1.GetComponent<LaserTut>().closeLaser();
        LaserHead.GetComponent<KillerRayControll>().setAnimClose();
    }
    public void StarttoMove() {
        if (!moving) {
            moving = true;
            moveDir_L = false;
            Laser1.GetComponent<LaserTut>().startmove(LeftPoint,RightPoint);
            
        }
        
    }
}
