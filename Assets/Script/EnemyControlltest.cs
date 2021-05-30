using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyControlltest : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
    public GameObject Laser;
    float hitTime = 0;
    bool hitPlayer = false;

    GameObject Gearobject;
    Transform GearPos;
    public bool needTrigger = false;   //???
    bool canmove = true;
    bool isControled = false;
    GameObject killmodeConrol;
    [Header("移動參數")]
    public float speed = 2.0f;
    float f_y = 0;

   [Header("狀態")]
    bool leftDirection = false;
    public bool Have_GearMove = false;
    bool TriggerGear = false;

    [Header("環境檢測")]
    public LayerMask TriggerLayer;
    private GameObject UpGear ;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
   
    private void FixedUpdate()
    {
        if(canmove)Move();
        //isTouchingTriggerLayer();
        if (Have_GearMove && TriggerGear)
        {
            OntheGear();
        }
        if (hitPlayer)
        {

            if (hitTime > 0.5f && hitTime < 1f)
            {
                
                Laser.GetComponent<LaserTut>().closeLaser();
                hitTime = hitTime + Time.deltaTime;

            }
            else if (hitTime >= 1f) {
                hitTime = 0;
                hitPlayer = false;
                canmove = true;
            }
            else if (hitTime <= 0.5f)
            {
                hitTime = hitTime + Time.deltaTime;
            }

        }

    }

    public void setDirection(bool isLeft,GameObject Controller) {

       
        leftDirection = isLeft;
        isControled = true;
        killmodeConrol = Controller;
        changeDirection();
    }
    void OntheGear() {  // 在機關上面
        bool gearismoving;
        gearismoving = UpGear.GetComponent<UpGear>().ismoving();
        if (gearismoving)
        {
            canmove = false;
            print("不准動");
        }
        else {
            canmove = true;
        }


        //float f_xx = transform.position.x - Gearobject.transform.position.x;
        //if (Mathf.Abs(f_xx) < 0.1f)
        //{
        //    print("敵人踩在機關囉");
        //    canmove = false;
        //}
        //f_y = Gearobject.transform.position.y - GearPos.position.y;
        //transform.position = new Vector3(transform.position.x, transform.position.y + f_y, transform.position.z);
        //GearPos = Gearobject.transform;


    }

    void Move()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, f_y, 0);
    }

    void changeDirection() {
        if (leftDirection)  //準備變成右邊
        {
            leftDirection = false;
            speed = 2.0f;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            
        }
        else {  //準備變成左邊
            leftDirection = true;
            speed = -2.0f;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void Die() {
        Destroy(gameObject);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "EnemyTrigger")
        {
            if (canmove) changeDirection();
        }

        if (collision.tag == "EnemyDie") {
            anim.SetTrigger("Die");
            canmove = false;
            if (isControled) {
                killmodeConrol.GetComponent<killModeControl>().AddDieCount();
            
            }
        }

        //if (collision.tag == "UpGear") {
        //    TriggerGear = true;
        //    Gearobject = collision.gameObject;
        //    GearPos = Gearobject.transform;
        //    canmove = false;
        //}


        if (collision.tag == "Player" && !collision.isTrigger)
        {
            Laser.GetComponent<LaserTut>().SetForwardPoint(collision.transform);
            Laser.SetActive(true);
            Laser.GetComponent<LaserTut>().openLaser();
            collision.GetComponent<PlayerMovement>().LaserDie();
            hitPlayer = true;
            canmove = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UpGear")
        {
            print("敵人踩在機關囉");

            UpGear = collision.gameObject;
            TriggerGear = true;
            GearPos = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UpGear") {
            TriggerGear = false;
            canmove = true;
            f_y = 0;
        }
    }

   


}
