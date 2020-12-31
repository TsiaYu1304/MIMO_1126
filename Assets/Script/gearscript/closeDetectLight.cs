using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDetectLight : MonoBehaviour
{
    [Header("控制物件")]
    public Sprite Light_Turnoff, Light_Turnon;
    public Material Light_Turnoff_material, Light_Turnon_material;
    private SpriteRenderer rend;
    public GameObject DetectPlayer_object;
    public GameObject Ceilling;
    public AudioSource closeSound;
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
   

    public void TurnOffLight() {
        DetectPlayer_object.GetComponent<DetectLightControll>().StopDetect();
        rend.sprite = Light_Turnoff;
        rend.material = Light_Turnoff_material;
        if (Ceilling != null) Ceilling.GetComponent<FallCeilingControll>().StopFall();
        closeSound.Play();
    }

    public void TurnOnLight()
    {
        DetectPlayer_object.GetComponent<DetectLightControll>().OpenDetect();
        rend.sprite = Light_Turnon;
        rend.material = Light_Turnon_material;
    }




}
