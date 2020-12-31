using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PlayerMovement : MonoBehaviour
{
    [Header("物件變數")]
    public GameObject AnotherPlayer;
    private Rigidbody2D rb;
    public PlayerInput playerControls;
    public GameObject Combine2Player;
    public Animator anim;
    public SpriteRenderer rend;
    public Transform ReplayPoint;
    public AudioSource s_walk;
    public AudioSource s_fall;
    public AudioSource s_Sounds;
    public AudioSource s_die;
    public Material  dust_material, Fall_material;
    public Material idle_material, walk_material,jump_material;
    [Header("移動參數")]
    public Transform groundCheckPoint;
    float xVelocity;
    private Vector2 v_movement;
    public float speed = 5.0f;

    [Header("跳躍參數")]
    public float jumpforce = 6.3f;
    public float jumptime ;
    float jumpTimeCounter;

    [Header("狀態")]
    public int Onbottom;  // 我是下面的話是幾號
    bool isOnGround;  //在地板上
    public bool isJump = false;  //正在跳躍
    bool jumpPressed;  //按下jump鈕
    bool jumpHold;
    bool canCombine = false;  //trigger彼此 可以合體
    bool canMove = true;

    [Header("環境檢測")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        xVelocity = 0;
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, 0.1f, groundLayer);
        Switchanim();
        Jump();
        if(canMove)GroundMovement();
    }

    public void jumpAwake() {
        gameObject.SetActive(true);
        rb.velocity = Vector2.up * 10;
    }

    public void bottomAwake() {
        gameObject.SetActive(true);
    }

    public void AboveAwake() {
        gameObject.SetActive(true);
        rb.AddForce(transform.forward * 50);
        
    }
    public void setWalkmaterial() {
        rend.material = walk_material;
    }

    public void setReplayPoint(Transform Point) {
        ReplayPoint = Point;
    }
    public void LaserDie() {

        s_walk.Pause();
        if (!anim.GetBool("LaserDie")) anim.SetBool("LaserDie", true);
        s_die.Play();
        canMove = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        rend.material = dust_material;
    }

    public void PressDie()
    {
        s_walk.Pause(); s_die.Play();
        anim.SetBool("PressDie", true);
        canMove = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void Replay() {
        anim.SetBool("LaserDie", false);
        anim.SetBool("PressDie", false);
        canMove = true;
        anim.SetBool("Fall", true);
        transform.position = ReplayPoint.position;
        rend.material = Fall_material;
    }

    void Switchanim() {
        if (anim.GetBool("Jump"))
        {
            if (rb.velocity.y <= 0) {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
                rend.material = Fall_material;
            }
        }

        if (anim.GetBool("Fall")) {
            if (isOnGround) {
                anim.SetBool("Fall", false);
                rend.material = idle_material;
                s_fall.Pause();
            }
        }

        if (anim.GetFloat("Walk") > 0.1f && !anim.GetBool("Jump") && !anim.GetBool("Fall")) {

            s_walk.Play();
            rend.material = walk_material;
        }
        if (anim.GetFloat("Walk") < 0.1f && !anim.GetBool("Fall") && !anim.GetBool("Jump"))
        {
            rend.material = idle_material;
            s_walk.Pause();
        }


    }    


    void Jump()
    {
        if (isJump && jumpHold) {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else {
                isJump = false;
            }
        }

        if (jumpPressed && isOnGround) //起跳
        {
            rb.velocity = Vector2.up * jumpforce;
            isJump = true;
            anim.SetBool("Jump", true);
            s_walk.Pause();
            rend.material = jump_material;
            jumpTimeCounter = jumptime;

        }


        jumpPressed = false;
    }

    /* odd
     void Jump()
    {

        if (jumpPressed && isOnGround)
        {
            isJump = true;
            rb.velocity = Vector2.up * jumpforce;

        }
        jumpPressed = false;
    }
     
     */

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
            transform.localScale = new Vector2(1,1);
        }
        else if (xVelocity > 0)
        {
            transform.localScale = new Vector2(-1,1);
        }
    }

    public void SetShowPoint(Transform showPosition)  // Set解體位置
    {
        transform.position = showPosition.position;
    }


    public void OnMove(CallbackContext context)
    {

        v_movement = context.ReadValue<Vector2>();
        xVelocity = v_movement.x;
    }
    public void OnJump(CallbackContext context)
    {

        
        if (context.ReadValue<float>() == 1) {
            if (isOnGround && !isJump) {
                jumpPressed = true;
                jumpHold = true;
            }
        }

        if (context.ReadValue<float>() == 0) {
            isJump = false;
            jumpHold = false;
            jumpPressed = false;
        }
        //Debug.Log(context.ReadValue<float>());
    }

    public void OnCombine(CallbackContext context)
    {
        if (context.performed && canCombine)
        {
            Transform combinePosition = AnotherPlayer.transform;
            Combine2Player.GetComponent<CombinePlayerControll>().CombineSet(Onbottom, combinePosition);
            AnotherPlayer.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void OnSpeak(CallbackContext context) {
        if (context.performed) {
            s_Sounds.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") canCombine = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") canCombine = false;
    }

    
}
