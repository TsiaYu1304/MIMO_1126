using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LefttorightGear : MonoBehaviour
{
    public float speed = 1.0f;
    bool Toleft = true;
    bool canMove = false;
    public Transform LeftPoint, RightPoint;

    private void Start()
    {
        LeftPoint.parent = null;
        RightPoint.parent = null;
    }

    public void setMove()
    {
        canMove = !canMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Toleft) MovetoLeft();
            else { MovetoRight(); }
        }
    }

    void MovetoLeft()
    {
        transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < LeftPoint.position.x)
        {
            Toleft = false;
        }
    }

    void MovetoRight()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > RightPoint.position.x)
        {
            Toleft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser") {
            collision.GetComponent<LaserCollision>().setHit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            collision.GetComponent<LaserCollision>().setExit();
        }
    }
}
