using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGear : MonoBehaviour
{
    [Header("子物件控制")]
    public Transform Up_Point;
    public Transform Down_Point;
    public GameObject Trigger;
    public AudioSource sounds;
    //Rigidbody2D rb;

    [Header("磁吸變量")]

    public bool isBlue = true;  //紅的還是藍的
    public float speed = 1.0f;
    bool canRepel = false;
    bool canAttract = false;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        Up_Point.parent = null;
        Down_Point.parent = null;
        Trigger.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttract) {
            AttractMove();
        }
        if (canRepel) {
            RepelMove();
        }
    }

    public void setAttract() {

        canAttract = true;
    }

    public void setRepel() {
        canRepel = true; ;
    }

    public void AttractMove()
    {
        
        if (transform.position.y > Down_Point.position.y)
        {   //吸引還沒過下面的點
            if (!sounds.isPlaying) sounds.Play();
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime,0);
            //rb.velocity = new Vector2(0, -speed);
            speed = speed + 0.5f;
        }
        else if (transform.position.y < Down_Point.position.y) {
            //rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(transform.position.x, Down_Point.position.y);
            speed = 1.0f;
            canAttract = false;
        }
        else if(transform.position.y == Down_Point.position.y) canAttract = false;

        Debug.Log(gameObject.name+"吸引");
    }

    public void RepelMove()
    {
        if (transform.position.y < Up_Point.position.y)
        {   //排斥還沒上面的點
            //rb.velocity = new Vector2(0, speed);
            if (!sounds.isPlaying) sounds.Play(); if (!sounds.isPlaying) sounds.Play();
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            speed = speed + 0.5f;
        }
        else if (transform.position.y > Up_Point.position.y)
        {
            //rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(transform.position.x, Up_Point.position.y);
            speed = 1.0f;
            canRepel = false;
        }
        else if (transform.position.y == Up_Point.position.y) canRepel = false;
        Debug.Log(gameObject.name + "排斥");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer") {
            canAttract = false;
            canRepel = false;
        }
    }
}
