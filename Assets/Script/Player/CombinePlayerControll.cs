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
    public Animator anim;

    [Header("物件參數")]
    public GameObject camera;
    public Transform ReplayPoint;
    public Transform AbovePoint;
    public Transform BottomPoint;
    public Transform mimiPoint;
    public Transform momoPoint;
    public GameObject Mimi;
    public GameObject Momo;
    GameObject Grabobject;
    public Transform GrabthingPoint;
    public Material MiMiisBottom;
    public Material MoMoisBottom;
    public AudioSource s_walk;
    public AudioSource s_fall;
    public AudioSource s_Sounds;
    [Header("材質")]
    public Material idle_mimi, idle_momo;
    public Material fall_mimi, fall_momo;
    public Material jump_mimi, jump_momo;
    public Material walk_mimi, walk_momo;
    public Material Laserdie_mimi, Laserdie_momo;
    public Material dust_material;

    bool canTurnoffLaser = false;
    GameObject GearTriggering;

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
    bool canMove = true;
    public bool Magnetic = true;
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
        rend = GetComponent<SpriteRenderer>();
    }

    public void CombineSet(int whobottom, Transform showPosition) {
        Onbottom = whobottom;
        transform.position = showPosition.position; //換位子囉
        gameObject.SetActive(true);
        
        if (whobottom == 1) //Mimi 在下面  Momo上位
        {
            rend.material = idle_mimi;
            playerControls.actions.FindActionMap("CombineMo").Disable();
            playerControls.SwitchCurrentActionMap("CombineMi");
            playerControls.actions.FindActionMap("CombineMi").Enable();

        }
        else if (whobottom == 0) //Momo 在下面  Mimi上位
        {
            rend.material = idle_momo;
            playerControls.actions.FindActionMap("CombineMi").Disable();
            playerControls.SwitchCurrentActionMap("CombineMo");
            playerControls.actions.FindActionMap("CombineMo").Enable();
        }
        s_Sounds.Play();
       
    }

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
        Switchanim();
        Jump();
    }

    void Switchanim() //偵測動畫切換 包含Material
    {
        if (anim.GetBool("Jump"))
        {
            if (rb.velocity.y <= 0)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
                if (Onbottom == 0)
                {
                    rend.material = fall_momo;
                }
                else {
                    rend.material = fall_mimi;
                }
            }
        }

        if (anim.GetBool("Fall"))
        {
            if (isOnGround)
            {
                anim.SetBool("Fall", false);
                if (Onbottom == 0)
                {
                    rend.material = idle_momo;
                }
                else
                {
                    rend.material = idle_mimi;
                }
                s_fall.Play();
            }
        }

        if (anim.GetFloat("Walk") > 0.1f && !anim.GetBool("Jump") && !anim.GetBool("Fall"))
        {

            if (Onbottom == 0)
            {
                rend.material = walk_momo;
            }
            else
            {
                rend.material = walk_mimi;
            }

            s_walk.Play();
        }
        if (anim.GetFloat("Walk") < 0.1f && !anim.GetBool("Fall") && !anim.GetBool("Jump"))
        {
            if (Onbottom == 0)
            {
                rend.material = idle_momo;
            }
            else
            {
                rend.material = idle_mimi;
            }
            s_walk.Pause();
        }


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
            anim.SetBool("Jump", true);
            s_walk.Pause();
            if (Onbottom == 0)
            {
                rend.material = jump_momo;
            }
            else
            {
                rend.material = jump_mimi;
            }

        }

        jumpPressed = false;
 
    }

    void GroundMovement()
    {
        anim.SetFloat("Walk", Mathf.Abs(xVelocity));
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


    public void OnSpeak(CallbackContext context)
    {
        if (context.performed)
        {
            s_Sounds.Play();
        }
    }

    public void OnBang_Discombine(CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            if (rb.gravityScale != -14)
            {
                if (Onbottom == 1) // MIMI在下
                {
                    camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                    Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                    Momo.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                    Momo.GetComponent<PlayerMovement>().jumpAwake();
                    Mimi.GetComponent<PlayerMovement>().bottomAwake();
                    rb.gravityScale = 7;
                    gameObject.SetActive(false);

                }
                else
                {
                    camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                    Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                    Mimi.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                    Mimi.GetComponent<PlayerMovement>().jumpAwake();
                    Momo.GetComponent<PlayerMovement>().bottomAwake();
                    rb.gravityScale = 7;
                    gameObject.SetActive(false);
                }
            }
            else {
                camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().bottomAwake();
                Momo.GetComponent<PlayerMovement>().bottomAwake();
                rb.gravityScale = 7;
                gameObject.SetActive(false);
            }
            
        }  
    }

    public void OnNormal_Discombine(CallbackContext context) {
        if (context.ReadValue<float>() == 1)
        {
            if (rb.gravityScale != -14)
            {
                if (Onbottom == 1) // MIMI在下
                {
                    Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                    Momo.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                    Momo.GetComponent<PlayerMovement>().AboveAwake();
                    Mimi.GetComponent<PlayerMovement>().bottomAwake();
                    rb.gravityScale = 7;
                    gameObject.SetActive(false);

                }
                else
                {
                    Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                    Mimi.GetComponent<PlayerMovement>().SetShowPoint(AbovePoint);
                    Mimi.GetComponent<PlayerMovement>().AboveAwake();
                    Momo.GetComponent<PlayerMovement>().bottomAwake();
                    rb.gravityScale = 7;
                    gameObject.SetActive(false);
                }
            }
            else {
                camera.GetComponent<Virtualcamera>().SetShakeTrigger();
                Momo.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().SetShowPoint(BottomPoint);
                Mimi.GetComponent<PlayerMovement>().bottomAwake();
                Momo.GetComponent<PlayerMovement>().bottomAwake();
                rb.gravityScale = 7;
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

    public void setReplayPoint(Transform Point)
    {
        ReplayPoint = Point;
    }

    public void LaserDie()
    {
        if (!anim.GetBool("LaserDie"))  anim.SetBool("LaserDie", true);
        s_walk.Pause();
        canMove = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (Onbottom == 0)
        {
            rend.material = Laserdie_momo;
        }
        else
        {
            rend.material = Laserdie_mimi;
        }
    }

    public void PressDie()
    {
        anim.SetBool("PressDie", true);
        s_walk.Pause();
        canMove = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void Replay()
    {
        anim.SetBool("LaserDie", false);
        canMove = true;
        anim.SetBool("Fall", true);
        transform.position = ReplayPoint.position;
        if (Onbottom == 0)
        {
            rend.material = fall_momo;
        }
        else {
            rend.material = fall_mimi;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grabthing") {
            touchGrabthing = true;
            Grabobject = collision.gameObject;
        }
        if (collision.tag == "LaserTrigger")
        {
            canTurnoffLaser = true;
            GearTriggering = collision.gameObject;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grabthing")
        {
            touchGrabthing = false;
        }
        if (collision.tag == "LaserTrigger")
        {
            canTurnoffLaser = false;
            GearTriggering = null;
        }
    }


    public void OnPushButton(CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("push");

            if (canTurnoffLaser)
            {
                GearTriggering.GetComponent<Button_LaserControll>().TriggerLaser();
            }

           
        }


    }
}
