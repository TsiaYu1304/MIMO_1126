using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGate : MonoBehaviour
{
    public Transform openpoint;
    public Transform downPoint;
    public GameObject UpGate;
    bool openGate = false;
    bool closeGate = false;
    bool upGateOK = false;
    bool downGateOK = false;
    Vector3 myTransform;
    Vector3 UpGateTrans;
    public bool cando = false;
    // Start is called before the first frame update
    
    public void Opengate() {
        openGate = true;    
    }

    public void Closegate() {
        closeGate = true;
        upGateOK = false; downGateOK = false;
        Debug.Log(upGateOK);
    }

    private void Start()
    {
        transform.parent = null;
        openpoint.parent = null;
        
        if (cando)
        {
            UpGate.transform.parent = null;
            myTransform = transform.position;
            UpGateTrans = UpGate.transform.position;
            downPoint.parent = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (cando)
        {
            if (closeGate)
            {
                if (!upGateOK)
                {
                    Debug.Log("我沒進來");
                    UpGate.transform.position = UpGate.transform.position + new Vector3(0, -2 * Time.deltaTime, 0);
                    if (UpGate.transform.position.y - UpGateTrans.y <= 0.05f)
                    {
                        UpGate.transform.position = UpGateTrans;
                        upGateOK = true;
                        Debug.Log("不小心進來了");
                    }
                }
                if (!downGateOK)
                {
                    transform.position = transform.position + new Vector3(0, 2 * Time.deltaTime, 0);
                    if (myTransform.y - transform.position.y <= 0.05f)
                    {
                        transform.position = myTransform;
                        downGateOK = true;
                    }
                }
                if (upGateOK && downGateOK) {
                    closeGate = false; upGateOK = false; downGateOK = false; }
            }

            if (openGate)
            {
                if (!upGateOK)
                {
                    UpGate.transform.position = Vector3.MoveTowards(UpGate.transform.position, openpoint.position, 2.0f * Time.deltaTime);
                    if (openpoint.position.y - UpGate.transform.position.y <= 0.05f)
                    {
                        UpGate.transform.position = openpoint.position;
                        upGateOK = true;
                    }
                }
                if (!downGateOK)
                {
                    transform.position = Vector3.MoveTowards(transform.position, downPoint.position, 2.0f * Time.deltaTime);
                    if (transform.position.y - downPoint.position.y <= 0.05f)
                    {
                        transform.position = downPoint.position;
                        downGateOK = true;
                    }
                }
                if (upGateOK && downGateOK) { openGate = false; upGateOK = false; downGateOK = false; }
            }
        }
    }


     //if (openGate) {
     //       transform.position = Vector3.MoveTowards(transform.position, openpoint.position, 2.0f*Time.deltaTime);
     //       if (openpoint.position.y - transform.position.y <= 0.05f) {
     //           transform.position = openpoint.position;
     //           openGate = false;
     //       }
     //   }

}
