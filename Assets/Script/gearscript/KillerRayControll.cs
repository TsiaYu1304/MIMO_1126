using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KillerRayControll : MonoBehaviour
{

    [Header("Laser參數")]
    public GameObject Laser;
    public Transform rotatpoint;
    bool isShoot = false;
    float time = 0;
    public bool open = false;
    float f_x ;
    float f_y;
    public Transform LeftPoint, RightPoint;
    public bool moveDir_L = false;
    public bool moving = false;
    public float movespeed;
    public bool row = false;
    public Animator anim;


// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (open) setAnimOpen();
    }

    private void Update()
    {
        if (isShoot) {
            if (time < 0.5f)
            {
                time = time + Time.deltaTime;
            }
            else if (time > 0.5f && time < 1.2f)
            {
                
                Laser.GetComponent<LaserTut>().closeLaser();
                time = time + Time.deltaTime;

            }
            else if(time > 1.2f){
                time = 0;
                isShoot = false;
                rotatpoint.rotation = Quaternion.Euler(0, 0, 0);
                Laser.GetComponent<LaserTut>().ForwardPointedit();
            }
        }

        if (moving) {
            if (row)
            {
                RowSinglePointmoving();
            }
            else {
                SinglePointmoving();
            }
            
        }
    }

    public void startmove_SinglePoint(Transform singlepoint, bool Left)
    { //左邊往右邊再回左邊的雷射
        if (Left)
        {
            LeftPoint = singlepoint;
            RightPoint = null;
        }
        else
        {
            LeftPoint = null;
            RightPoint = singlepoint;
        }
        moveDir_L = Left;
        moving = true;
    }

    public void RowSinglePointmoving()  //第二關會移動的雷射
    {
        if (moveDir_L) //往左
        {
            if (Mathf.Abs(transform.position.y - LeftPoint.position.y) <= 0.1f)
            { //與左點對齊
                transform.position = new Vector3(transform.position.x, LeftPoint.position.y, transform.position.z);
                moving = false;
            }
            else
            { //往左點移動 
                transform.position = new Vector3(transform.position.x, transform.position.y - movespeed * Time.deltaTime, transform.position.z);
            }

        }
        else
        {  //往右
            if (Mathf.Abs(RightPoint.position.y - transform.position.y) <= 0.1f)
            { //與右點對齊

                transform.position = new Vector3(transform.position.x, RightPoint.position.y, transform.position.z);
                moving = false;
            }
            else
            { //往右點移動 
                print("給我移動喔");
                transform.position = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime, transform.position.z);
            }
        }

    }

    public void SinglePointmoving()  //第二關會移動的雷射
    {
        if (moveDir_L) //往左
        {
            if (Mathf.Abs(transform.position.x - LeftPoint.position.x) <= 0.1f)
            { //與左點對齊
                transform.position = new Vector3(LeftPoint.position.x, transform.position.y, transform.position.z);
                moving = false;
            }
            else
            { //往左點移動 
                transform.position = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y, transform.position.z);
            }

        }
        else
        {  //往右
            if (Mathf.Abs(RightPoint.position.x - transform.position.x) <= 0.1f)
            { //與右點對齊

                transform.position = new Vector3(RightPoint.position.x, transform.position.y, transform.position.z);
                moving = false;
            }
            else
            { //往右點移動 
                transform.position = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }

       
    }


    public void setAnimOpen() {
        anim.SetBool("Open", true);
    }
    public void setAnimClose()
    {
        anim.SetBool("Open", false);
    }

    public void KillPlayer(Vector3 PlayerPosition) {

       
        Vector2 shootDir = PlayerPosition - transform.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg + 90f ;
        //float radiant = Mathf.Abs(shootDir.y) / Mathf.Abs(shootDir.x);
        //float degree = 180 / Mathf.PI * radiant;

        rotatpoint.rotation = Quaternion.Euler(0, 0 ,angle);
        EnableLaser(PlayerPosition);

        isShoot = true;
    }


    void EnableLaser(Vector3 PlayerPosition) {
       // f_x = PlayerPosition.x - firePoint.position.x;
        //f_y = -2.862f - firePoint.position.y;
        
       
        Laser.SetActive(true);
        Laser.GetComponent<LaserTut>().SetLaserPoint(PlayerPosition);
        Laser.GetComponent<LaserTut>().openLaser();
    }

}
