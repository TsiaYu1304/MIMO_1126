using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGate : MonoBehaviour
{

    public Transform DownPoint;
    public Transform backPoint;
    bool closegate = false;
    bool backGate = false;
    public float speed;
    public BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        DownPoint.parent = null;
        backPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (closegate) closemove();
        if (backGate) backmove();
    }

    public void ClosetheGate() {
        closegate = true;
    }

    public void backtheGate() {
        backGate = true;
        coll.enabled = false;
    }

    void closemove() {
        transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
        if(transform.position.y < DownPoint.position.y)
        {
            transform.position = DownPoint.position;
            closegate = false;
            coll.enabled = true;
        }
    }
    void backmove() {
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y > backPoint.position.y)
        {
            transform.position = backPoint.position;
            backGate = false;
            coll.enabled = false;

        }
    }
}
