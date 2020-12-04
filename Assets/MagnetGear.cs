using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGear : MonoBehaviour
{
    [Header("子物件控制")]
    public Transform Up_Point;
    public Transform Down_Point;
    public GameObject Trigger;
    Rigidbody2D rb;

    [Header("磁吸變量")]

    public bool isBlue = true;  //紅的還是藍的
    public float speed = 3.0f; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Up_Point.parent = null;
        Down_Point.parent = null;
        Trigger.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Move_Up() { 
        
    }

    public void AttractMove()
    {
        if (transform.position.y > Down_Point.position.y)
        {   //吸引還沒過下面的點
            rb.velocity = new Vector2(0, -speed);
            speed = speed + 1.0f;
        }
        else if (transform.position.y < Down_Point.position.y) {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(transform.position.x, Down_Point.position.y);
            speed = 3.0f;
        }
    }

    public void RepelMove()
    {
        if (transform.position.y < Up_Point.position.y)
        {   //排斥還沒上面的點
            rb.velocity = new Vector2(0, speed);
            speed = speed + 1.0f;
        }
        else if (transform.position.y > Up_Point.position.y)
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(transform.position.x, Up_Point.position.y);
            speed = 3.0f;
        }

    }
}
