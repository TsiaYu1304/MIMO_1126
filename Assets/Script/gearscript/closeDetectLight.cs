using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDetectLight : MonoBehaviour
{
    [Header("控制物件")]
    public Sprite Light_Turnoff;
    public Material Light_Turnoff_material;
    private SpriteRenderer rend;
    public GameObject DetectPlayer_object;

    

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
    }


}
