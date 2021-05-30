using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class FallCeilingControll : MonoBehaviour
{

    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f;
    int dieplayer = 0;
    int fallPlayercount = 2;
    bool startFall = false;  //下墜過了嗎
    public GameObject LaserFire;
    public GameObject LaserFire2;

    int PlayerCount = 0;
    bool canFallDown = false;
    bool canFallback = false;
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public GameObject LaserComtrol;
    public GameObject[] Lasergear;
    public GameObject PressTrigger;
    public float downSpeed ;
    public bool partymode = true;

    [Header("開關雷射")]
    bool open = true; //打開雷射??
    float time = 2.1f;
    public float partytime; //party的總共時間

    // Start is called before the first frame update
    void Start()
    {
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }
    public void Playerassemble() {
        startFall = true;
    }

    public void PlayerLeave() {
        startFall = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canFallDown && !canFallback)
        {
            if (startFall) //人數到齊
            {
                CameraNoise();
                canFallDown = true;

            }
        }

        else if(canFallDown && !canFallback) {
           
            FallDownCeiling();
            if (!startFall) { //下降了可是人不齊
                StopCameraNoise();
                StopFall();

            }
        }

        else if (canFallback && !canFallDown) {
            FallbackCeiling();
        }

        if (partymode) OpenLaser();

    }

    void FallDownCeiling() {

        
        transform.localScale = transform.localScale + new Vector3(0, downSpeed * Time.deltaTime, 0);

        if (partymode) { //雷射下降
            Lasergear[0].transform.position = Lasergear[0].transform.position + new Vector3(0, -0.2f * Time.deltaTime, 0);
            Lasergear[1].transform.position = Lasergear[1].transform.position + new Vector3(0, -0.2f * Time.deltaTime, 0);
            if (transform.localScale.y > 1.92f)
            {
                PressTrigger.GetComponent<CeilingdieTrigger>().DetectpressPlayer();
            }
        }
        
        if (!partymode) {

            if (transform.localScale.y > 7.14f) {
                PressTrigger.GetComponent<CeilingdieTrigger>().DetectpressPlayer();
            }


        }
    }

    void FallbackCeiling() {
        
        transform.localScale = transform.localScale + new Vector3(0, -(downSpeed+2) * Time.deltaTime, 0);
        if (partymode)
        {
            Lasergear[0].transform.position = Lasergear[0].transform.position + new Vector3(0, 3.5f* Time.deltaTime, 0);
            Lasergear[1].transform.position = Lasergear[1].transform.position + new Vector3(0, 3.5f * Time.deltaTime, 0);
        }
            if (transform.localScale.y < 0) {
            transform.localScale = new Vector3(transform.localScale.x,0.1f, 0);
            canFallback = false;
        }
    }

    public void ResetGear()

    {
        PlayerCount = 0;
        StopCameraNoise();
        canFallDown = false;
        canFallback = true;
        if (partymode)
        {
            LaserComtrol.GetComponent<Button_LaserControll>().Resetbutton();
        }
        
        fallPlayercount = 1;
    }

    void OpenLaser() {
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
        else
        {
            time = time + Time.deltaTime;
        }
    }

    void CameraNoise() {
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = ShakeFrequency;
        }
    }

    void StopCameraNoise() {
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            virtualCameraNoise.m_AmplitudeGain = 0;
        }
    }

    public void StopFall() {
        canFallDown = false;
        canFallback = true;
       
    }

    private void OnTriggerEnter2D(Collider2D collision) //偵測到player
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerCount = PlayerCount + 1; //trigger增加一名玩家
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerCount = PlayerCount - 1; //trigge減少一名玩家
        }
    }
}
