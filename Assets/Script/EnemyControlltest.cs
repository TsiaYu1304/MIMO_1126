using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyControlltest : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D coll;
    GameObject Gearobject;
    Transform GearPos;

    [Header("移動參數")]
    public float speed = 2.0f;
    float f_y = 0;

   [Header("狀態")]
    bool leftDirection = false;
    public bool Have_GearMove = false;
    bool TriggerGear = false;

    [Header("環境檢測")]
    public LayerMask TriggerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //coll = gameObject.GetComponent<BoxCollider2D>();

        // Update is called once per frame
    }
   
    private void FixedUpdate()
    {
        Move();
        //isTouchingTriggerLayer();
        if (Have_GearMove && TriggerGear)
        {
            OntheGear();
        }
        
    }

    void OntheGear() {

        f_y = Gearobject.transform.position.y - GearPos.position.y;
        //transform.position = new Vector3(transform.position.x, transform.position.y + f_y, transform.position.z);
        GearPos = Gearobject.transform;


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

    private void isTouchingTriggerLayer() {
        if (coll.IsTouchingLayers(TriggerLayer)) {
            changeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "EnemyTrigger")
        {
            
            changeDirection();
        }
        

        if (collision.tag == "UpGear") {
            TriggerGear = true;
            Gearobject = collision.gameObject;
            GearPos = Gearobject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "UpGear")
        {
            TriggerGear = false ;
            f_y = 0;
        }
    }

}
