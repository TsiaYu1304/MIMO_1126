using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class PlayerControl : MonoBehaviour
{


    [Header("物件變數")]

    private Rigidbody2D rb;
    GameObject GearTriggering;

    [Header("狀態")]
    bool canTurnoffLight = false;
    bool canTurnoffLaser = false;

    [Header("漂浮變數")]
    bool floatup = true;   //往上還是往下
    bool FloatTrigger = false;
    float f_floatupPoint, f_floatDoenPoint;
    public float FloatSpeed = 1f;
    public float Floatforce = 10f;

    [Header("環境檢測")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (FloatTrigger) Float();
    }

    public void setFloat(float upY,float downY)
    {
        FloatTrigger = true;
        f_floatupPoint = upY;
        f_floatDoenPoint = downY;
        rb.gravityScale = 0.02f;
        rb.gravityScale = 0.02f;
        floatup = true;
    }

    public void Float() {

        if (floatup)
        {
            if (transform.position.y < f_floatDoenPoint)
                rb.velocity = Vector2.up * Floatforce;
            //rb.AddForce(Vector2.up * Floatforce);
            if (transform.position.y > f_floatupPoint)
            {
                floatup = false;
                rb.gravityScale = 0.022f;
            }
        }
        else
        {
            if (transform.position.y < f_floatDoenPoint) rb.velocity = Vector2.up * FloatSpeed;
        }

        //if (floatup)
        //{
        //    if (transform.position.y > f_floatuppoint)
        //    {
        //        floatup = false;
        //        rb.velocity = new vector2(0, 0);
        //        rb.gravityscale = 0.08f;

        //    }


        //}
        //else
        //{
        //    if (transform.position.y < f_floatdoenpoint)
        //    {
        //        floatup = true;
        //        rb.velocity = new vector2(0, 0);
        //        rb.gravityscale = -0.08f;

        //    }

        //}
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Button_DetectLight") {
            canTurnoffLight = true;
            GearTriggering = collision.gameObject;
        }

        if (collision.tag == "LaserTrigger") {
            canTurnoffLaser = true;
            GearTriggering = collision.gameObject;
        }

        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Button_DetectLight")
        {
            canTurnoffLight = false;
            GearTriggering = null;
        }
    }

    

    private void OnGrab() {
        //Debug.Log("Grab");
    }

    public void OnPushButton(CallbackContext context) {
        if (context.performed) {
            if (canTurnoffLight)
            {
                GearTriggering.GetComponent<closeDetectLight>().TurnOffLight();
            }

            if (canTurnoffLaser)
            {
                GearTriggering.GetComponent<Button_LaserControll>().TriggerLaser();
            }
        }


    }

    public void setstopFloat()
    {
        rb.gravityScale = 1;
        FloatTrigger = false;
    }
}
