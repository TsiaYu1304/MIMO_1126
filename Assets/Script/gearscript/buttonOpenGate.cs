using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOpenGate : MonoBehaviour
{

    [Header("控制物件")]
    public GameObject workGear;
    public bool b_controllGear;
    [Header("狀態變數")]
    bool isOpening = false;
    bool isDown = false;
    public bool isStraight = false;
    
    [Header("移動變數")]
    public Transform OpenPoint;
    public Transform startPoint;
    public float stepSpeed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening) { OpentheGate(); }
        else if (isDown) { DowntheGate(); }
    }

    public void changetoOpen() {
        isOpening = true;
    }
    public void changetoDown()
    {
        isOpening = false;
        isDown = true;
    }


    void OpentheGate() {
        if (isStraight)
        {
            float Y_diff;
            Y_diff = transform.position.y - OpenPoint.position.y;
            if (Y_diff > 0 )
            {
                isOpening = false;
                transform.position = new Vector3( transform.position.x, OpenPoint.position.y, transform.position.z);
                if (b_controllGear) workGear.GetComponent<UpGear>().SetGateisOpen();

            }
            else
            {
               transform.position = transform.position + new Vector3( 0, stepSpeed * Time.deltaTime, 0);
                
            }
        }
        else {
            float X_diff;
            X_diff = transform.position.x - OpenPoint.position.x;
            if (X_diff < 0)
            {
                isOpening = false;
                transform.position = new Vector3(OpenPoint.position.x, transform.position.y, transform.position.z);
                if (b_controllGear) workGear.GetComponent<UpGear>().SetGateisOpen();

            }
            else
            {
                transform.position = transform.position - new Vector3(stepSpeed * Time.deltaTime, 0, 0);
            }
        }

        
    }

    void DowntheGate()
    {
        if (isStraight)
        {
            float Y_diff;
            Y_diff =transform.position.y - startPoint.position.y;
            if (Y_diff < 0 )
            {
                isDown = false;
                transform.position = new Vector3(transform.position.x, startPoint.position.y, transform.position.z);
            }
            else
            {

                transform.position = transform.position - new Vector3(0, stepSpeed * Time.deltaTime, 0);
                if (b_controllGear) workGear.GetComponent<UpGear>().SetGateisnotOpen();
            }
        }
        else {
            float X_diff;
            X_diff = transform.position.x - startPoint.position.x;
            if (X_diff > 0 )
            {
                isDown = false;
                transform.position = new Vector3(startPoint.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = transform.position + new Vector3(stepSpeed * Time.deltaTime, 0, 0);
                if (b_controllGear) workGear.GetComponent<UpGear>().SetGateisnotOpen();
            }
        }
    }
}
