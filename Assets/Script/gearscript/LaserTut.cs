using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTut : MonoBehaviour
{
    [Header("控制物件")]
    public GameObject Fallceiling;
    public Animator anim;
    public Transform myPoint;
    public Transform forward;
    public Transform GenPoint;
    public GameObject EndVFX;
    public GameObject StartVFX;
    GameObject g_EndVFX;
    GameObject g_StartVFX;
    private LineRenderer lr;

    float time;
    bool startclock=false;

    [Header("狀態變數")]
    public bool Detectcontrolled = false;
    bool shootRay = false;
    public LayerMask Player;
    public LayerMask Ground;
    public bool open = false;
    public bool parttyLaser = false;
    public bool BigLaser = false; //第二關最後大機關雷射
    public bool isFiveLaser = false; //第二關5個雷射的雷射派對
    public bool isStraight = true;
    public bool movewithGear = false; //端點需要移動的
    public bool collideobject = false; //會先撞到其他collider

    bool moving = false; //是否正在動
    bool moveDir_L = false;
    Transform LeftPoint, RightPoint,openmovepoint;
    public float movespeed;


    float f_x, f_y,f_totalY = 0;
    // Use this for initialization
    void Start()
    {
       if(GenPoint != null) GenPoint.parent = null;
        if (parttyLaser) forward.parent = null;
        lr = GetComponent<LineRenderer>();
        // anim = GetComponent<Animator>();
        f_x = forward.position.x - myPoint.position.x;
        f_y = forward.position.y - myPoint.position.y;
        openmovepoint = myPoint;

    }

    // Update is called once per frame

    public void startmove(Transform Left,Transform Right) { //左邊往右邊再回左邊的雷射
        LeftPoint = Left;
        RightPoint = Right;
        moving = true;
        moveDir_L = false;
        print("succesCall");
    }


    public void movingFX()  //第二關會移動的雷射
    {  
        if (moveDir_L) //往左
        {
            if ((myPoint.position.x - LeftPoint.position.x) <= 0.1f)
            { //與左點對齊
                myPoint.position = new Vector3(LeftPoint.position.x, myPoint.position.y, myPoint.position.z);
                moving = false;
               
            }
            else
            { //往左點移動 
                myPoint.position = new Vector3(myPoint.position.x - movespeed * Time.deltaTime, myPoint.position.y, myPoint.position.z);
            }
        }
        else
        {  //往右
            if ((RightPoint.position.x - myPoint.position.x) <= 0.1f)
            { //與右點對齊

                myPoint.position = new Vector3(RightPoint.position.x, myPoint.position.y, myPoint.position.z);
                moveDir_L = true;
            }
            else
            { //往右點移動 
                myPoint.position = new Vector3(myPoint.position.x + movespeed * Time.deltaTime, myPoint.position.y, myPoint.position.z);
            }
        }

        lr.SetPosition(0, myPoint.position);
        if (g_StartVFX != null) {
            g_StartVFX.transform.position = myPoint.position;
            g_EndVFX.transform.position = new Vector3(myPoint.position.x, g_EndVFX.transform.position.y, g_EndVFX.transform.position.z);
        }
    }

    public void startmove_SinglePoint(Transform singlepoint,bool Left)
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

    public void SinglePointmoving()  //第二關會移動的雷射
    {
        if (moveDir_L) //往左
        {
            if (Mathf.Abs(myPoint.position.x - LeftPoint.position.x) <= 0.1f)
            { //與左點對齊
                myPoint.position = new Vector3(LeftPoint.position.x, myPoint.position.y, myPoint.position.z);
                moving = false;
            }
            else
            { //往左點移動 
                myPoint.position = new Vector3(myPoint.position.x - movespeed * Time.deltaTime, myPoint.position.y, myPoint.position.z);
            }

        }
        else
        {  //往右
            if (Mathf.Abs(RightPoint.position.x - myPoint.position.x) <= 0.1f)
            { //與右點對齊

                myPoint.position = new Vector3(RightPoint.position.x, myPoint.position.y, myPoint.position.z);
                moving = false;
            }
            else
            { //往右點移動 
                myPoint.position = new Vector3(myPoint.position.x + movespeed * Time.deltaTime, myPoint.position.y, myPoint.position.z);
            }
        }

        lr.SetPosition(0, myPoint.position);
        if (g_StartVFX != null)
        {
            g_StartVFX.transform.position = myPoint.position;
            g_EndVFX.transform.position = new Vector3(myPoint.position.x, g_EndVFX.transform.position.y, g_EndVFX.transform.position.z);
        }
    }

    public void RowSinglePointmoving()  //第二關會移動的雷射
    {
        if (moveDir_L) //往左
        {
            if (Mathf.Abs(myPoint.position.y - LeftPoint.position.y) <= 0.1f)
            { //與左點對齊
                myPoint.position = new Vector3(myPoint.position.x, LeftPoint.position.y,  myPoint.position.z);
                moving = false;
            }
            else
            { //往左點移動 
                myPoint.position = new Vector3(myPoint.position.x, myPoint.position.y - movespeed * Time.deltaTime, myPoint.position.z);
            }

        }
        else
        {  //往右
            if (Mathf.Abs(RightPoint.position.y - myPoint.position.y) <= 0.1f)
            { //與右點對齊

                myPoint.position = new Vector3(myPoint.position.x, RightPoint.position.y,  myPoint.position.z);
                moving = false;
            }
            else
            { //往右點移動 
                print("給我移動喔");
                myPoint.position = new Vector3(myPoint.position.x , myPoint.position.y + movespeed * Time.deltaTime, myPoint.position.z);
            }
        }

        lr.SetPosition(0, myPoint.position);
        if (g_StartVFX != null)
        {
            g_StartVFX.transform.position = myPoint.position;
            g_EndVFX.transform.position = new Vector3(myPoint.position.x, g_EndVFX.transform.position.y, g_EndVFX.transform.position.z);
        }
    }

    void movewithGearchangeY()  //端點障礙物會垂直移動
    {
        
        float dist_Y = forward.position.y - myPoint.position.y;
        RaycastHit2D hitGear = Physics2D.Raycast(myPoint.position, new Vector3(0, -dist_Y, 0), dist_Y, Ground);
        if (hitGear.collider != null && hitGear.collider.tag == "Ground")
        {
            if (g_EndVFX != null)
            {
                g_EndVFX.transform.position = new Vector3(g_EndVFX.transform.position.x, hitGear.point.y, 0);
                
                
                lr.SetPosition(1, new Vector3(myPoint.position.x, hitGear.point.y, 0));
                f_y = hitGear.point.y - myPoint.position.y;
            }
        }
        else {
            if (g_EndVFX != null)
            {
                g_EndVFX.transform.position = new Vector3(g_EndVFX.transform.position.x, g_EndVFX.transform.position.y- 2.0f * Time.deltaTime,0);
                lr.SetPosition(1, new Vector3(myPoint.position.x, g_EndVFX.transform.position.y, 0));
                f_y = g_EndVFX.transform.position.y - myPoint.position.y;
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(0, -f_y, 0), f_y, Player);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            print("shootlayer");
            Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
            Debug.DrawRay(transform.position, HP, Color.blue, 1f);
            hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
            startclock = true;
            shootRay = false;

        }
        else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
        {
            Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
            Debug.DrawRay(transform.position, HP, Color.blue, 1f);
            hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
        }


    }

    void Change_withTagGround_x() //端點障礙物左右移動
    {
        
        float dist_X = forward.position.x - myPoint.position.x;
        RaycastHit2D hitGear = Physics2D.Raycast(myPoint.position, new Vector3(dist_X, 0, 0), dist_X, Ground);

        if (hitGear.collider != null && hitGear.collider.tag == "Ground")
        {
            if (g_EndVFX != null)
            {
                g_EndVFX.transform.position = new Vector3(hitGear.point.x, g_EndVFX.transform.position.y, 0);
                lr.SetPosition(1, new Vector3(hitGear.point.x, myPoint.position.y, 0));
                f_x = hitGear.point.x - myPoint.position.x;
            }
        }
        else
        {
            if (g_EndVFX != null)
            {
                g_EndVFX.transform.position = new Vector3(g_EndVFX.transform.position.x + 2.0f * Time.deltaTime, g_EndVFX.transform.position.y, 0);
                lr.SetPosition(1, new Vector3(g_EndVFX.transform.position.x, myPoint.position.y, 0));
                f_x = g_EndVFX.transform.position.x - myPoint.position.x;
            }
        }

    }

    void movewithGearchangeX() {
        float dist_X = forward.position.x - myPoint.position.x;
        RaycastHit2D hitGear = Physics2D.Raycast(myPoint.position, new Vector3(dist_X,0, 0), dist_X, Ground);

        if (hitGear.collider != null && hitGear.collider.tag == "Ground")
        {
            if (g_EndVFX != null)
            {
                print(name);
                g_EndVFX.transform.position = new Vector3(hitGear.point.x, hitGear.point.y, 0);
                lr.SetPosition(1, new Vector3(hitGear.point.x, myPoint.position.y, 0));
                f_x = hitGear.point.x - myPoint.position.x;
            }
        }
        else
        {
            if (g_EndVFX != null)
            {
                g_EndVFX.transform.position = new Vector3(g_EndVFX.transform.position.x + 2.0f * Time.deltaTime, g_EndVFX.transform.position.y , 0);
                lr.SetPosition(1, new Vector3(g_EndVFX.transform.position.x,myPoint.position.y, 0));
                f_x = g_EndVFX.transform.position.x - myPoint.position.x;
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(f_x, 0, 0), f_x);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            print("有嗎");

            Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
            hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
            startclock = true;
            shootRay = false;
        }
        else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
        {

            Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
            hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
        }
    }

    

    private void FixedUpdate()
    {
        if (startclock) {  //防止重複死亡
            if (time < 0.5f)
            {
                time = time + Time.deltaTime;
            }
            else {
                time = 0;
                startclock = false;
                shootRay = true;
            }
        }

        if (parttyLaser) { //party laser天花板下降
            if (g_StartVFX != null) g_StartVFX.transform.position = myPoint.position;
        }

        if (shootRay && isStraight) //要設定raycast狙擊player
        {
           
            

            if (movewithGear)
            {  //會撞到障礙物的
                if (moving)
                {    //會移動的
                    if (BigLaser) //最後一關的
                    {
                        SinglePointmoving();
                    }
                    else
                    {
                        movingFX();
                    }              
                }
                movewithGearchangeY();
            }
            
            else
            {  //垂直的普通雷射
                float dist = Vector3.Distance(myPoint.position, forward.position);
                Debug.DrawRay(transform.position, new Vector3(f_x, f_y, 0), Color.yellow);
                RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(f_x, f_y, 0), dist, Player);

                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    print(name+"killp");
                    Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                    Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                    
                    hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                    startclock = true;
                    shootRay = false;
                    if (parttyLaser)
                    {
                        Fallceiling.GetComponent<FallCeilingControll>().ResetGear();

                    }

                }
                else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
                {
                    Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                    Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                    hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
                    if (parttyLaser)
                    {
                        Fallceiling.GetComponent<FallCeilingControll>().ResetGear();

                    }

                }
            }
            
        }

        if (shootRay && !isStraight ) //要設定raycast狙擊player
        {
            //水平的普通雷射

            if (movewithGear)
            {
                if (moving)
                {    //會移動的
                    if (BigLaser) //最後一關的
                    {
                        print("衡的bigLaser");
                        RowSinglePointmoving();
                    }
                    
                }
                movewithGearchangeX();

                //RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(f_x, 0, 0), f_x);


                //if (hit.collider != null && hit.collider.tag == "Player")
                //{

                //    Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                //    Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                //    hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                //    startclock = true;
                //    shootRay = false;
                //}
                //else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
                //{

                //    Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                //    Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                //    hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
                //}
            }
            else {
                if (collideobject) { //line上有沒有其他碰撞體
                    RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(4, 0, 0), 4);
                    
                    if (hit.collider != null && hit.collider.tag == "Player")
                    {
                        print("撞laser");

                        Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                        Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                        hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                        startclock = true;
                        shootRay = false;
                        if (parttyLaser)
                        {
                            Fallceiling.GetComponent<FallCeilingControll>().ResetGear();
                        }
                    }
                    else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
                    {

                        Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                        Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                        hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
                        if (parttyLaser)
                        {
                            Fallceiling.GetComponent<FallCeilingControll>().ResetGear();
                        }
                    }
                }
                else {
                    RaycastHit2D hit = Physics2D.Raycast(myPoint.position, new Vector3(f_x, 0, 0), f_x);

                    if (hit.collider != null && hit.collider.tag == "Player")
                    {


                        Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                        Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                        hit.collider.gameObject.GetComponent<PlayerMovement>().LaserDie();
                        startclock = true;
                        shootRay = false;
                        if (parttyLaser)
                        {
                            Fallceiling.GetComponent<FallCeilingControll>().ResetGear();
                        }
                    }
                    else if (hit.collider != null && hit.collider.tag == "CombinePlayer")
                    {

                        Vector3 HP = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0);
                        Debug.DrawRay(transform.position, HP, Color.blue, 1f);
                        hit.collider.gameObject.GetComponent<CombinePlayerControll>().LaserDie();
                        if (parttyLaser)
                        {
                            Fallceiling.GetComponent<FallCeilingControll>().ResetGear();
                        }
                    }
                }


                
            }
            

        }


        if (open)
        {  //一次性開啟
            if (!Detectcontrolled) shootRay = true;
            if (StartVFX != null) g_StartVFX = Instantiate(StartVFX, myPoint.position, Quaternion.identity);
            lr.SetPosition(0, myPoint.position);
            lr.SetPosition(1, forward.position);
            //if (parttyLaser) print(forward.position);
            open = false;
            anim.SetBool("Open", false);
            if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
        }

        /* if (open) {
            if (Vector3.Distance(openmovepoint.position, forward.position) <= 0.1f) //移動得夠了
            {
                if (!Detectcontrolled) shootRay = true;
                open = false;
                lr.SetPosition(1, forward.position);
                anim.SetBool("Open", false);
                if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
            }
            else {

                openmovepoint.position = openmovepoint.position + (forward.position - openmovepoint.position)*Time.deltaTime*2.0f ;
                lr.SetPosition(1, openmovepoint.position);
            }
        }*/

    }
    public void Hitcollision() //撞到障礙物
    {
        Destroy(g_EndVFX);
        if (isStraight)
        {
            if (GenPoint != null)
            {
                lr.SetPosition(1, GenPoint.position);
            }
            else
            {
                forward.position = forward.position + new Vector3(0, 2.2f, 0);
                lr.SetPosition(1, forward.position);
            }


            f_y = 0;
        }
        else
        {

            forward.position = forward.position + new Vector3(-3.8f, 0, 0);
            lr.SetPosition(1, forward.position);
        }
        if (EndVFX != null)
        {
            if (GenPoint != null)
            {
                g_EndVFX = Instantiate(EndVFX, GenPoint.position, Quaternion.identity);
            }
            else
            {
                g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
            }
        }
    }

    public void ExitCollision() //障礙物離開
    { 
        Destroy(g_EndVFX);
        if (isStraight)
        {
            if (GenPoint == null)
            {
                forward.position = forward.position + new Vector3(0, -2.2f, 0);
            }

            lr.SetPosition(1, forward.position);


            f_y = forward.position.y - myPoint.position.y;
        }
        else {
            forward.position = forward.position + new Vector3(3.8f, 0, 0);
            lr.SetPosition(1, forward.position);
        }
        if (EndVFX != null) g_EndVFX = Instantiate(EndVFX, forward.position, Quaternion.identity);
    }

    public void SetInactive() {

        lr.SetPosition(0, new Vector2(0, 0));
        lr.SetPosition(1, new Vector2(0, 0));
        
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
        if (g_EndVFX != null)
        {
            print("消滅端點");
            Destroy(g_EndVFX);
        }
    }

    public void openLaser() {
        anim.SetBool("Open", true);
        open = true;


        //if (StartVFX != null) g_StartVFX = Instantiate(StartVFX, myPoint.position, Quaternion.identity);
        //lr.SetPosition(0, myPoint.position);

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

    public void SetForwardPoint(Transform Point) {

        forward.position = Point.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") {
            if (movewithGear) {
                if (!isStraight)
                {
                    Change_withTagGround_x();  //撞到那個綠機關就叫
                }
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (movewithGear)
            {
                if (!isStraight)
                {
                    Change_withTagGround_x();  //撞到那個綠機關就叫
                }
            }

        }
    }



}
