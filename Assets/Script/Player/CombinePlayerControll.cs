using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CombinePlayerControll : MonoBehaviour
{
    [SerializeField]

    private PlayerActionControls m_playersControls;

    [Header("Component參數")]
    private Rigidbody2D rb;
    private Collider2D coll;
    public SpriteRenderer rend;
    public PlayerInput playerControls;

    [Header("物件參數")]
    public GameObject camera;
    public Sprite Momounder;
    public Sprite Mimiunder;
    public Transform AbovePoint;
    public Transform BottomPoint;
    public Transform mimiPoint;
    public Transform momoPoint;
    public GameObject Mimi;
    public GameObject Momo;
    GameObject Grabobject;
    public Transform GrabthingPoint;

    [Header("移動參數")]
    public float speed = 5.0f;
    public Transform groundCheckPoint;
    private Vector2 v_movement;
    float xVelocity;

    [Header("跳躍參數")]
    public float jumpforce = 9.0f;
    public float jumptime;
    float jumpTimeCounter;

    [Header("狀態變數")]
    public bool Magnetic = false;
    public int Onbottom = 1;  //0是MIMI；1是MOMO
    bool isOnGround;
    public bool isJump = false;
    bool jumpPressed;
    bool jumpHold;

    bool pushGrab = false;
    bool touchGrabthing = false;
    bool Grabsomething = false;

    [Header("環境檢測")]
    public LayerMask groundLayer;

   

    private void Awake()
    {
        m_playersControls = new PlayerActionControls();
    }

  

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rend = GetComponent<SpriteRenderer>();
    }

    public void CombineSet(int whobottom, Transform showPosition) {
        Onbottom = whobottom;
        transform.position = showPosition.position; //換位子囉
        gameObject.SetActive(true);
        
        if (whobottom == 1) //Mimi 在下面  Momo上位
        {
             rend.sprite = Mimiunder;
            playerControls.actions.FindActionMap("CombineMo").Disable();
            playerControls.SwitchCurrentActionMap("CombineMi");
            playerControls.actions.FindActionMap("CombineMi").Enable();
        }
        else if (whobottom == 0) //Momo 在下面  Mimi上位
        {
            rend.sprite = Momounder;
            playerControls.actions.FindActionMap("CombineMi").Disable();
            playerControls.SwitchCurrentActionMap("CombineMo");
            playerControls.actions.FindActionMap("CombineMo").Enable();
        }

       
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (pushGrab && touchGrabthing && (Grabobject != null))
        {
            Grabsomething = true;
        }

        if (Grabsomething) grab();
    }

    private void FixedUpdate() {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, 0.1f, groundLayer);
        GroundMovement();
        Jump();
    }

    void grab() {
        if (!pushGrab) { //放開按鈕了
            Grabsomething = false;
            
        }

        Grabobject.transform.position = GrabthingPoint.position;
    }

    void Jump()
    {
        if (isJump && jumpHold)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }

        if (jumpPressed && isOnGround) //起跳
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            isJump = true;
            jumpTimeCounter = jumptime;

        }

        jumpPressed = false;
 
    }

    void GroundMovement()
    {
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        FlipDirection();
    }


    void FlipDirection()
    {
        if (xVelocity < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (xVelocity > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void OnMove(CallbackContext context)
    {

        v_movement = context.ReadValue<Vector2>();
        xVelocity = v_movement.x;
    }

    public void OnJump(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            if (isOnGround && !isJump)
            {
                jumpPressed = true;
                jumpHold = true;
            }
        }

        if (context.ReadValue<float>() == 0)
        {
            isJump = false;
            jumpHold = false;
            jumpPressed = false;
        }
    }


    /*
        public void OnDiscombine(CallbackContext context)
    {
        if (context.performed)
        {
            Mimi.GetComponent<PlayerMovement>().SetShowPoint(mimiPoint);
            Momo.GetComponent<PlayerMovement>().SetShowPoint(momoPoint);
            Mimi.SetActive(true);
            Momo.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
     */

    public void OnBang_Discombine(CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            if (Onbottom == 1) // MIMI在下
            {
                camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Momo.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                Momo.GetComponent<PlayerMovement>().jumpAwake();
                Mimi.GetComponent<PlayerMovement>().bottomAwake();
                gameObject.SetActive(false);

            }
            else
            {
                camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                Mimi.GetComponent<PlayerMovement>().jumpAwake();
                Momo.GetComponent<PlayerMovement>().bottomAwake();
                gameObject.SetActive(false);
            }
            
        }  
    }

    public void OnNormal_Discombine(CallbackContext context) {
        if (context.ReadValue<float>() == 1)
        {
            if (Onbottom == 1) // MIMI在下
            {
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Momo.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                Momo.GetComponent<PlayerMovement>().AboveAwake();
                Mimi.GetComponent<PlayerMovement>().bottomAwake();
                gameObject.SetActive(false);

            }
            else
            {
                Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                Mimi.GetComponent<PlayerMovement>().AboveAwake();
                Momo.GetComponent<PlayerMovement>().bottomAwake();
                gameObject.SetActive(false);
            }
        }
    }


    public void OnGrab(CallbackContext context) {
        if (context.performed) { pushGrab = true; }
        else if (context.canceled) { pushGrab = false; }
        //print("push");
        //Debug.Log(pushGrab);

    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grabthing") {
            touchGrabthing = true;
            Grabobject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grabthing")
        {
            touchGrabthing = false;
        }
    }
}
