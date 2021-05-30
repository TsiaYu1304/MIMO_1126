using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieVFX : MonoBehaviour
{

    float time;
    bool starttoClock = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starttoClock) {
            if (time < 1.0f)
            {
                time = time + Time.deltaTime;

            }
            else {
                transform.parent.gameObject.GetComponent<PlayerMovement>().Replay();
                starttoClock = false;
                time = 0;
                gameObject.SetActive(false);
            }
        }
    }

    public void clocktime() {

        starttoClock = true;
    }
}
