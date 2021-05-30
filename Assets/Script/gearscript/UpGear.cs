using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGear : MonoBehaviour
{
   [Header("控制物件")]
    public GameObject AITrigger_Beneath_L, AITrigger_Beneath_R;
    public GameObject AITrigger_Self_L, AITrigger_Self_R;
    public GameObject AITrigger_Above_L,AITrigger_Above_R;
    public GameObject flowGear;

    [Header("移動變數")]
    public float stepSpeed = 5.0f;

    [Header("狀態變數")]
    bool isUp = false;
    bool isDown = false;
    bool GateisOpen = false;
    bool OnTop = false;
    

    [Header("1右 2中 3左")]
    public int i_kind = 1;
    public bool haveGate = false;
    public bool isRow = false;

    [Header("移動位置")]
    public Transform startPosirion;
    public Transform upPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosirion.parent = null;
        upPosition.parent = null;
        //startPosirion = transform;
        if (!isRow)
        {
            if (i_kind == 1)
            {
                AITrigger_Self_L.SetActive(false);
            }
            else if (i_kind == 2)
            {
                AITrigger_Self_L.SetActive(false);
                AITrigger_Self_R.SetActive(false);
            }
            else if (i_kind == 3)
            {
                //AITrigger_Self_R.SetActive(false);
            }
        }
    }

    // Update is called once per frame

    public bool ismoving() {
        if (isUp || isDown)
        {
            return true;
        }
        else return false;
    }

    private void FixedUpdate()
    {
        if (isUp) { UpMove(); }  //上升狀態持續上升
        else if (isDown) { DownMove(); }  //下降的話持續下降

        if (haveGate)
        {
            if (GateisOpen && OnTop) { setTopTrigger(); }  //注意這裡 喔喔喔!!!
        }
        else { if (OnTop && !isRow) setTopTrigger(); }

    }

    public void changeUp() {  //改成上升狀態

        isUp = true;
        isDown = false ;
        setisUpTrigger();
    }

    public void changeDown(){  //改成下降狀態

        isDown = true;
        isUp = false;
        OnTop = false;
        setisDownTrigger();
    }

    void UpMove()
    {

        if (isRow) {
            float f_Xpositiondiff;
            f_Xpositiondiff = transform.position.x- upPosition.position.x;
            if (f_Xpositiondiff > 0)
            { //到頂了
                isUp = false;
                transform.position = new Vector3(upPosition.position.x, transform.position.y,  transform.position.z);
                OnTop = true; //到左邊了
                flowGear.GetComponent<FloatTrigger>().ExitGear();
            }
            else if (!OnTop)
            {
                transform.position = transform.position + new Vector3(stepSpeed * Time.deltaTime, 0,  0);
            }
        }
        else
        {
            float f_Ypositiondiff;
            f_Ypositiondiff = transform.position.y - upPosition.position.y;
            if (f_Ypositiondiff > 0)
            { //到頂了
                isUp = false;
                transform.position = new Vector3(transform.position.x, upPosition.position.y, transform.position.z);
                OnTop = true;

            }
            else if (!OnTop)
            {
                transform.position = transform.position + new Vector3(0, stepSpeed * Time.deltaTime, 0);
            }
        }


    }

    void DownMove() {

        if (isRow) {
            float f_Xpositiondiff;
            f_Xpositiondiff = transform.position.x-startPosirion.position.x  ;
            if (f_Xpositiondiff < 0)
            {
                isDown = false;
                transform.position = new Vector3(startPosirion.position.x, transform.position.y, transform.position.z);
                //setBottomTrigger();
                flowGear.GetComponent<FloatTrigger>().HitGear();
            }
            else
            {
                transform.position = transform.position - new Vector3(stepSpeed * Time.deltaTime, 0,  0);

            }
        }
        else {
            float f_Ypositiondiff;
            f_Ypositiondiff = transform.position.y - startPosirion.position.y;
            if (f_Ypositiondiff < 0)
            {
                isDown = false;
                transform.position = new Vector3(transform.position.x, startPosirion.position.y, transform.position.z);
                setBottomTrigger();
            }
            else if (f_Ypositiondiff > 0)
            {
                transform.position = transform.position - new Vector3(0, stepSpeed * Time.deltaTime, 0);

            }
        }
        
    }

    void setTopTrigger() {
        if (i_kind == 1)
        {
            AITrigger_Self_L.SetActive(false);
            AITrigger_Above_R.SetActive(false);
        }
        else if (i_kind == 2 || i_kind == 0)
        {
            AITrigger_Self_L.SetActive(false);
            AITrigger_Self_R.SetActive(false);
            AITrigger_Above_R.SetActive(false);
            AITrigger_Above_L.SetActive(false);
        }

        else if (i_kind == 3) {
            AITrigger_Self_R.SetActive(false);
            AITrigger_Above_L.SetActive(false);
        }
    }

    void setBottomTrigger() {
        if (i_kind == 1)
        {
            AITrigger_Self_L.SetActive(false);
            AITrigger_Beneath_R.SetActive(false);
        }
        else if (i_kind == 2)
        {
            AITrigger_Self_L.SetActive(false);
            AITrigger_Self_R.SetActive(false);
            AITrigger_Beneath_L.SetActive(false);
            AITrigger_Beneath_R.SetActive(false);
        }
        else if (i_kind == 3)
        {
            AITrigger_Self_L.SetActive(false);
            AITrigger_Beneath_R.SetActive(false);
        }
        else if (i_kind == 0)
        {
            AITrigger_Self_R.SetActive(true);
            AITrigger_Self_L.SetActive(true);
        }
    }

    void setisUpTrigger() {
        AITrigger_Self_L.SetActive(true);
        AITrigger_Self_R.SetActive(true);
        if (i_kind == 1)
        {
            AITrigger_Beneath_R.SetActive(true);
        }
        else if (i_kind == 3)
        {
            AITrigger_Above_L.SetActive(true);
            AITrigger_Beneath_R.SetActive(true);
        }
        else if (i_kind == 2 || i_kind == 0)
        {
            AITrigger_Beneath_L.SetActive(true);
            AITrigger_Beneath_R.SetActive(true);
        }
    }

    void setisDownTrigger() {
        AITrigger_Self_L.SetActive(true);
        AITrigger_Self_R.SetActive(true);
        if (i_kind == 1)
        {
            AITrigger_Above_R.SetActive(true);
        }
        else if (i_kind == 2 || i_kind == 0)
        {
            AITrigger_Above_R.SetActive(true);
            AITrigger_Above_L.SetActive(true);
        }
        else if (i_kind == 3)
        {
            AITrigger_Above_L.SetActive(true);
            AITrigger_Beneath_R.SetActive(true);
        }
    }

    public void SetGateisOpen() {
        GateisOpen = true;
    }

    public void SetGateisnotOpen()
    {
        GateisOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            collision.GetComponent<LaserTut>().Hitcollision();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            collision.GetComponent<LaserTut>().ExitCollision();
        }
        
    }





}
