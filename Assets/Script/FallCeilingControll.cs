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
    bool Fallen = false;  //下墜過了嗎
    int PlayerCount = 0;
    bool canFallDown = false;
    bool canFallback = false;
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public GameObject RedGate, RedGate2;
    public GameObject LaserComtrol;
    public GameObject[] Lasergear;
    public GameObject PressTrigger;
    public float downSpeed ;
    public bool partymode = true;
    // Start is called before the first frame update
    void Start()
    {
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Fallen)
        {
            if (PlayerCount == fallPlayercount)
            {
                StartToFall();
            }
        }

        if (canFallDown) {
            FallDownCeiling();
        }
        if (canFallback) {
            FallbackCeiling();
        }

    }

    void FallDownCeiling() {

        
        transform.localScale = transform.localScale + new Vector3(0, downSpeed * Time.deltaTime, 0);
        if (partymode) {
            Lasergear[0].transform.position = Lasergear[0].transform.position + new Vector3(0, -0.34f * Time.deltaTime, 0);
            Lasergear[1].transform.position = Lasergear[1].transform.position + new Vector3(0, -0.34f * Time.deltaTime, 0);
        }
        
        if (!partymode) {

            //if (transform.localScale.y > 10) {
            //    StopCameraNoise();
            //    canFallDown = false;
            //    canFallback = true;
            //}
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

    void StartToFall()
    {
        if (partymode)
        {
            ClosetheRedGate();
            OpenLaser();
        }
        else {
            RedGate.GetComponent<RedGate>().ClosetheGate();
        }
        
        CameraNoise();
        canFallDown = true;
       
    }

    public void ResetGear()

    {
        PlayerCount = 0;
        StopCameraNoise();
        canFallDown = false;
        canFallback = true;
        RedGate.GetComponent<RedGate>().backtheGate();
        if (partymode)
        {
            RedGate2.GetComponent<RedGate>().backtheGate();
            LaserComtrol.GetComponent<Button_LaserControll>().Resetbutton();
        }
        
        fallPlayercount = 1;
    }

    void OpenLaser()
        {
            LaserComtrol.GetComponent<Button_LaserControll>().StartParty();
        }
    void ClosetheRedGate()
    {
        RedGate.GetComponent<RedGate>().ClosetheGate();
        RedGate2.GetComponent<RedGate>().ClosetheGate();
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
        StopCameraNoise();
        canFallDown = false;
        canFallback = true;
        RedGate.GetComponent<RedGate>().backtheGate();
        if (partymode) {
            
            RedGate2.GetComponent<RedGate>().backtheGate();
        }

        Fallen = true;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerCount = PlayerCount + 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerCount = PlayerCount - 1;
        }
    }
}
