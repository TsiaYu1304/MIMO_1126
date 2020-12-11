using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_LaserControll : MonoBehaviour
{
    [Header("物件控制")]
    public GameObject Ceiling;
    public bool Getparty = false; //是派對模式的雷射開關嗎

    public GameObject LaserFire;
    public GameObject LaserFire2;
    public GameObject myLight;

    bool open = false; // 發射雷射
    bool TurnOn = false; //現在是發射的狀態

    bool PlayerTriggerme = false; // player 觸碰到我

    public bool canPushed = false;  //可以正常開關

    float time = 2.1f;  

    public float partytime; //party的總共時間

    [Header("元件控制")]
    private SpriteRenderer rend;
    private Animator anim;

    [Header("Render Sprite控制")]
    public Sprite Laser_Turnon;
    public Sprite Laser_Turnoff;
    public Material Laser_Turnon_material;
    public Material Laser_Turnoff_material;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (Getparty) TurnOn = false;

        if (canPushed)
        {
            TurnOn = true;
            SetcanPush();
            open = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Getparty && TurnOn) { //擁有party模式 且開燈狀態
            if (time > partytime)
            {
                if (open)
                {
                    LaserFire.SetActive(true);
                    LaserFire.GetComponent<LaserTut>().openLaser();
                    LaserFire2.SetActive(true);
                    LaserFire2.GetComponent<LaserTut>().openLaser();
                    open = false;
                }
                else
                {
                    LaserFire.GetComponent<LaserTut>().closeLaser();
                    LaserFire2.GetComponent<LaserTut>().closeLaser();
                    open = true;
                }
                time = 0;
            }
            else {
                time = time + Time.deltaTime;
            }
        }
    }

    public void SetcanPush() { //玩家可以push_button
        //anim.SetBool("canpush",true);
        canPushed = true;
        //rend.sprite = Laser_Turnon;
        myLight.SetActive(true);
        
    }

    public void SetcanPushMaterial() {
        //rend.material = Laser_Turnon_material;
        canPushed = false;
        

    }

    public void SetcannotPush() {
        //anim.SetBool("canpush", false);
        canPushed = false;
        //rend.sprite = Laser_Turnoff;
        myLight.SetActive(false);
    }

    public void StartParty() { //開始派對模式
        TurnOn = true;
    }

    public void TriggerLaser()
    {
        if (!Getparty && canPushed)
        {

            if (TurnOn) TurnoffLaser(); //燈如果開著
            else TurnOnLaser();
        }
        else {
            TurnoffLaser();
        }
    }

    public void TurnoffLaser()
    {
        if (!Getparty)
        {
            if (PlayerTriggerme)
            {
                LaserFire.GetComponent<LaserTut>().closeLaser();
                TurnOn = false;
                rend.sprite = Laser_Turnoff;
            }
        }
        else {
            TurnOn = false;
            rend.sprite = Laser_Turnoff;
            LaserFire.GetComponent<LaserTut>().closeLaser();
            LaserFire2.GetComponent<LaserTut>().closeLaser();
            
            Ceiling.GetComponent<FallCeilingControll>().StopFall();

        }
    }

    public void TurnOnLaser()
    {
        if (!Getparty)
        {
            if (PlayerTriggerme)
            {
                Debug.Log("TurnOnLaser");
                LaserFire.SetActive(true);
                LaserFire.GetComponent<LaserTut>().openLaser();
                TurnOn = true;
                rend.sprite = Laser_Turnon;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerTriggerme = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerTriggerme = false;
        }
    }

}
