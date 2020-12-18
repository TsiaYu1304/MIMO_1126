using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTut : MonoBehaviour
{
    [Header("控制物件")]
    public Animator anim;
    public Transform myPoint;
    public Transform forward;
    public GameObject EndVFX;
    public GameObject StartVFX;
    GameObject g_EndVFX;
    GameObject g_StartVFX;
    private LineRenderer lr;

    [Header("狀態變數")]
    public bool Detectcontrolled = false;
    bool shootRay = false;
    public LayerMask Player;
    public bool open = false;
    public bool parttyLaser = false;
    public bool isStraight = true;

    float f_x, f_y,f_totalY = 0;
    // Use this for initialization
    void Start()
    {
        if (parttyLaser) forward.parent = null;
        lr = GetComponent<LineRenderer>();
        // anim = GetComponent<Animator>();
        f_x = forward.position.x - myPoint.position.x;
        f_y = forward.position.y - myPoint.position.y;

    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {

        if (parttyLaser) { //party laser天花板下降
            if (g_StartVFX != null) g_StartVFX.transform.position = myPoint.position;
        }

        if (shootRay && isStraight) //要設定raycast狙擊player
        {
           
            Debug.DrawRay(transform.position, new Vector3(0, f_y, 0),Color.red);
           
            RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(0, -f_y, 0), f_y,Player);
            
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                Debug.Log(hit.transform.name);
                
                Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                Debug.DrawRay(transform.position, HP, Color.blue,1f);
                hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                
            }
        }

        if (shootRay && !isStraight ) //要設定raycast狙擊player
        {

            Debug.DrawRay(transform.position, new Vector3(f_x, 0, 0), Color.blue);
            RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(f_x, 0, 0), f_x);
            
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                Debug.Log(hit.transform.name);

                Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();

            }
            
        }


        if (open) {
            if (!Detectcontrolled) shootRay = true;
            if (StartVFX != null) g_StartVFX = Instantiate(StartVFX, myPoint.position, Quaternion.identity);
            lr.SetPosition(0, myPoint.position);
            lr.SetPosition(1, forward.position);
            open = false;
            anim.SetBool("Open", false);
            if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
        }
    }
    public void Hitcollision()
    {
        Destroy(g_EndVFX);
        if (isStraight)
        {
            forward.position = forward.position + new Vector3(0, 2.2f, 0);
            lr.SetPosition(1, forward.position);
            f_y = 0;
        }
        else {
            Debug.Log("進來衡的");
            forward.position = forward.position + new Vector3(-3.8f, 0, 0);
            lr.SetPosition(1, forward.position);
        }
        if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
    }

    public void ExitCollision() {
        Destroy(g_EndVFX);
        if (isStraight)
        {
            forward.position = forward.position + new Vector3(0, -2.2f, 0);
            lr.SetPosition(1, forward.position);
            f_y = forward.position.y - myPoint.position.y;
        }
        else {
            Debug.Log("出去衡的");
            forward.position = forward.position + new Vector3(3.8f, 0, 0);
            lr.SetPosition(1, forward.position);
        }
        if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
    }

    public void SetInactive() {

        lr.SetPosition(1, new Vector2(0, 0));
        if (g_EndVFX != null) { 
            Destroy(g_EndVFX); 
        }
        if (g_StartVFX != null) {
            Destroy(g_StartVFX);
        }
        gameObject.SetActive(false);

        
    }

    public void ForwardPointedit() {
        forward.position = new Vector3(myPoint.position.x, forward.position.y, forward.position.z);
    }

    public void closeLaser() {
        anim.SetTrigger("Close");
        open = false;
        if (shootRay) shootRay = false;
    }

    public void openLaser() {
        anim.SetBool("Open", true);
        open = true;
       
    }

    public void SetLaserPoint(Vector3 targetPoint) {
        //f_x = targetPoint.x - myPoint.position.x ;

        //if (f_x > 0)
        //    forward.position = new Vector3(forward.position.x + f_x , forward.position.y, forward.position.z);
        //else {
        //    forward.position = new Vector3(forward.position.x - f_x, forward.position.y, forward.position.z);
        //}
        forward.position = new Vector3(targetPoint.x, forward.position.y, forward.position.z);

        f_x = forward.position.x - myPoint.position.x;
    }

}
