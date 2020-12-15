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
    public GameObject LaserCenter;
    public GameObject miniLaserCenter;
    GameObject g_LaserCenter;
    GameObject g_LaserminiCenter;
    public bool parttyLaser = false;
    bool move = false;

    float f_x, f_y,f_totalY = 0;
    // Use this for initialization
    void Start()
    {
        forward.parent = null;
        lr = GetComponent<LineRenderer>();
        // anim = GetComponent<Animator>();
        f_x = forward.position.x - myPoint.position.x;
        f_y = forward.position.y - myPoint.position.y;

    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {

        if (parttyLaser) {
            if (g_LaserminiCenter != null) g_LaserminiCenter.transform.position = myPoint.position;
        }
        if (Test)
        {
            Debug.DrawRay(transform.position, new Vector3(0, f_y, 0));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, f_y, 0),10f,Player);
            
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                Debug.Log(hit.transform.name);
                
                Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                Debug.DrawRay(transform.position, HP, Color.blue,1f);
                //if (g_LaserCenter != null) g_LaserCenter.transform.position = hit.point;
                //lr.SetPosition(1, new Vector2(hit.point.x - myPoint.position.x, hit.point.y - myPoint.position.y+0.4f));
                hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                Test = false;
            }
            //else lr.SetPosition(1, transform.forward * 5000);
        }

        if (open) {
            
            f_totalY = f_totalY - speed * Time.deltaTime;
            speed = speed + 5;
            lr.SetPosition(1, new Vector2(f_x, f_totalY));
            if (f_totalY < f_y+0.8f) {
                lr.SetPosition(1, new Vector2(f_x, f_y + 0.8f));
                open = false;
                f_totalY = 0;
                speed = 5;
                if (LaserCenter != null) g_LaserCenter = Instantiate(LaserCenter, forward.position, Quaternion.identity);
            }
        }
    }

    public void SetInactive() {

        lr.SetPosition(1, new Vector2(0, 0));
        if (g_LaserCenter != null) { 
            Destroy(g_LaserCenter); 
        }
        if (g_LaserminiCenter != null) {
            Destroy(g_LaserminiCenter);
        }
        gameObject.SetActive(false);
    }

    public void closeLaser() {
        anim.SetTrigger("Close");
        open = false;
    }

    public void openLaser() {
        Debug.Log("開啟");
        anim.SetBool("Open", true);
        open = true;
        if (miniLaserCenter != null) g_LaserminiCenter = Instantiate(miniLaserCenter, transform.position, Quaternion.identity);
        anim.SetBool("Open", false);
    }

}
