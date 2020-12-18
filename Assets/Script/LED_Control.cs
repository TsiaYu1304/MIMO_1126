using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_Control : MonoBehaviour
{

    public GameObject LEDlight;
    public GameObject LED_Sparkle;

    public float time = 3.0f;
    bool isSparkle = false;
    public bool canSparkle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSparkle) {

            if (time < 5.0f)
            {
                clockTime();
            }
            else {
                LEDlight.GetComponent<Animator>().SetTrigger("Sparkle");
                LED_Sparkle.GetComponent<Animator>().SetTrigger("Sparkle");
                time = 0;

            }
        }
    }

    void clockTime() {
        time = time + Time.deltaTime;     
    }
}
