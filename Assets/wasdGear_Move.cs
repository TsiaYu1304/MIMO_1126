using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdGear_Move : MonoBehaviour
{
    int status = 2;
    public Transform CenterPoint, RightPoint,DownPoint;
    bool move = false;
    public float speed;
    bool RLmove = false;
    bool incenter = true;

    // Start is called before the first frame update
    void Start()
    {
        CenterPoint.parent = null;
        RightPoint.parent = null;
        DownPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) //移動囉
        {
            if (RLmove)
            { //控制左右
                if (incenter)//2號位出發
                {
                    transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
                    if (transform.position.x - RightPoint.position.x > 0)
                    {
                        transform.position = RightPoint.position;
                        incenter = false;
                        move = false;
                        status = 3;
                    }
                }
                else
                {
                    transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
                    if (transform.position.x - CenterPoint.position.x < 0)
                    {
                        transform.position = CenterPoint.position;
                        incenter = true;
                        move = false;
                        status = 2;
                    }
                }
            }
            else
            { //控制上下
                if (incenter)//2號位出發
                {
                    transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
                    if (transform.position.y - DownPoint.position.y < 0)
                    {
                        transform.position = DownPoint.position;
                        incenter = false;
                        move = false;
                        status = 1;
                    }
                }
                else
                {
                    transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
                    if (transform.position.y - CenterPoint.position.y > 0)
                    {
                        transform.position = CenterPoint.position;
                        incenter = true;
                        move = false;
                        status = 2;
                    }
                }
            }
        }

    }

    public int PositionStatus()
    {
        return status;

    }

    public void moveDirection(bool RL) {
        RLmove = RL;
        move = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            print("Laser trigger");
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
