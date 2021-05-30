using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_LaserControll : MonoBehaviour
{
    [Header("物件控制")]
    public GameObject Ceiling;
    public bool Getparty = false; //是派對模式的雷射開關嗎
    public GameObject killlRay;
    public GameObject LaserFire;
    public GameObject LaserFire2;
    public GameObject myLight;

    bool open = false; // 發射雷射
    bool TurnOn = false; //現在是發射的狀態

    bool PlayerTriggerme = false; // player 觸碰到我

    public bool canPushed = false;  //可以正常開關

    float time = 2.1f;

    public GameObject fivelasercontroll;
    public float partytime; //party的總共時間
    public bool HaveTrigger = false;
    public GameObject movelaserControll;
    public GameObject Trigger;
    public GameObject EnemyTurnTrigger;
    [Header("元件控制")]
    private SpriteRenderer rend;
    private Animator anim;

    [Header("Render Sprite控制")]
    public Sprite Laser_Turnon;
    public Sprite Laser_Turnoff;
    public Material Laser_Turnon_material;
    public Material Laser_Turnoff_material;
    public Material defaultMaterial;
    public AudioSource sounds;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (Getparty) TurnOn = false;

        if (!Getparty && canPushed)
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

    public void Resetbutton() {
        TurnOn = false;
        open = false;
        LaserFire.GetComponent<LaserTut>().closeLaser();
        LaserFire2.GetComponent<LaserTut>().closeLaser();
        time = 0;
        myLight.SetActive(false);
    }

    public void SetcanPush() { //玩家可以push_button
        
        canPushed = true;

        if (fivelasercontroll != null)
        {
            fivelasercontroll.SetActive(true);

        }
        else {
            if (TurnOn)
            {
                rend.sprite = Laser_Turnon;
                rend.material = Laser_Turnon_material;
                LaserFire.SetActive(true);
                LaserFire.GetComponent<LaserTut>().openLaser();
            }
            else
            {
                rend.sprite = Laser_Turnoff;
                rend.material = Laser_Turnoff_material;
            }
            myLight.SetActive(true);
            if (killlRay != null)
            {
                killlRay.GetComponent<KillerRayControll>().setAnimOpen();
            }
        }
        
        
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
        if (fivelasercontroll != null)
        {

            fivelasercontroll.GetComponent<laserfive_Controll>().closeLaser();
        }
        else {

            killlRay.GetComponent<KillerRayControll>().setAnimClose();
            LaserFire.GetComponent<LaserTut>().closeLaser();
        }
        TurnOn = false;
        rend.sprite = Laser_Turnoff;
        rend.material = defaultMaterial;
        if (HaveTrigger)
        {
            Trigger.SetActive(false);
            EnemyTurnTrigger.SetActive(false);
        }
    }

    public void StartParty() { //開始派對模式
        TurnOn = true;
        rend.sprite = Laser_Turnon;
        rend.material = Laser_Turnon_material;
        myLight.SetActive(true);
        
    }

    public void TriggerLaser()   //玩家按按鈕會呼叫這個函式
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
                if (movelaserControll != null)
                {
                    movelaserControll.GetComponent<MoveLaserControll>().CloseMoveLaser();
                }
                else {
                    LaserFire.GetComponent<LaserTut>().closeLaser();
                }
                
                TurnOn = false;
                rend.sprite = Laser_Turnoff;
                rend.material = Laser_Turnoff_material;
                if (HaveTrigger) {
                    Trigger.SetActive(false);
                    EnemyTurnTrigger.SetActive(false);
                }
            }
        }
        else {
            TurnOn = false;
            rend.sprite = Laser_Turnoff; 
            rend.material = Laser_Turnoff_material;
            LaserFire.GetComponent<LaserTut>().closeLaser();
            LaserFire2.GetComponent<LaserTut>().closeLaser();
            Getparty = false;
            Ceiling.GetComponent<FallCeilingControll>().StopFall();

        }
        sounds.Play();
    }

    public void TurnOnLaser()
    {
        if (!Getparty)
        {
            if (PlayerTriggerme)
            {
                LaserFire.SetActive(true);
                LaserFire.GetComponent<LaserTut>().openLaser();
                TurnOn = true;
                rend.sprite = Laser_Turnon;
                rend.material = Laser_Turnon_material;
                sounds.Play();
                if (HaveTrigger)
                {
                    Trigger.SetActive(true);
                    EnemyTurnTrigger.SetActive(true);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerTriggerme = true;
        }
        if(collision.tag == "CombinePlayer") PlayerTriggerme = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerTriggerme = false;
        }
        if (collision.tag == "CombinePlayer") PlayerTriggerme = false;
    }

}
