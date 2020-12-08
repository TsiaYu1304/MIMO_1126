using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGate : MonoBehaviour
{
    public Transform openpoint;
    bool openGate = false;
    // Start is called before the first frame update
    
    public void Opengate() {
        openGate = true;    
    }

    private void Start()
    {
        transform.parent = null;
        openpoint.parent = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (openGate) {
            transform.position = Vector3.MoveTowards(transform.position, openpoint.position, 2.0f*Time.deltaTime);
            if (openpoint.position.y - transform.position.y <= 0.05f) {
                transform.position = openpoint.position;
                openGate = false;
            }
        }
    }
}
