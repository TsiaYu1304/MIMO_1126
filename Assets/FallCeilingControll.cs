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

    bool Fallen = false;  //下墜過了嗎
    int PlayerCount = 0;
    bool canFallDown = false;
    bool canFallback = false;
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public GameObject RedGate, RedGate2;
    public GameObject LaserComtrol;
    public float downSpeed ;
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
            if (PlayerCount == 2)
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
    }

    void FallbackCeiling() {
        transform.localScale = transform.localScale + new Vector3(0, -(downSpeed+2) * Time.deltaTime, 0);
        if (transform.localScale.y < 0) {
            transform.localScale = new Vector3(0,0, 0);
            canFallback = false;
        }
    }

    void StartToFall()
    {
        ClosetheRedGate();
        CameraNoise();
        canFallDown = true;
        OpenLaser();
    }

    void OpenLaser() {
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
        RedGate2.GetComponent<RedGate>().backtheGate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerCount = PlayerCount + 1;
        }
    }
}
