using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTut : MonoBehaviour
{
    public Animator anim;
    public bool Test = false;
    public Transform myPoint;
    public Transform forward;
    private LineRenderer lr;
    public LayerMask Player;
    public float speed;
    bool open = false;

    float f_x, f_y,f_totalY = 0;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        // anim = GetComponent<Animator>();
        f_x = forward.position.x - myPoint.position.x;
        f_y = forward.position.y - myPoint.position.y;

    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        if (Test)
        {
            Debug.DrawRay(transform.position, new Vector3(0, -3, 0));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -3, 0),10f,Player);
            
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                Debug.Log(hit.transform.name);
                
                Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                Debug.DrawRay(transform.position, HP, Color.blue,1f);

                lr.SetPosition(1, new Vector2(hit.point.x - myPoint.position.x, hit.point.y - myPoint.position.y+0.7f));
                Test = false;
            }
            //else lr.SetPosition(1, transform.forward * 5000);
        }

        if (open) {
            Debug.Log("開設");
            f_totalY = f_totalY - speed * Time.deltaTime;
            speed = speed + 5;
            lr.SetPosition(1, new Vector2(f_x, f_totalY));
            if (f_totalY < f_y) {
                lr.SetPosition(1, new Vector2(f_x, f_y));
                open = false;
                f_totalY = 0;
                speed = 5;
            }
        }
    }

    public void SetInactive() {
        lr.SetPosition(1, new Vector2(0, 0));
        gameObject.SetActive(false);
    }

    public void closeLaser() {
        anim.SetTrigger("Close");
        open = false;
    }

    public void openLaser() {
        
        anim.SetTrigger("Open");
        open = true;
    }

}
