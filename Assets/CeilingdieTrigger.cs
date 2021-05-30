using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingdieTrigger : MonoBehaviour
{
    bool detecPlayer = false;
    int Playerdiecount = 0;
    int PlayerCount = 0;
    public GameObject Ceiling;
    public bool startFall = false; //告訴我開始沒
    
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (detecPlayer)
        {
            if (Playerdiecount == 2)
            {
                Playerdiecount = 0;
                Ceiling.GetComponent<FallCeilingControll>().ResetGear();
                detecPlayer = false;
                Ceiling.GetComponent<FallCeilingControll>().PlayerLeave();
                startFall = false;

            }
        }

        

        
    }

    public void DetectpressPlayer() {
        detecPlayer = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            if (detecPlayer) {
                collision.GetComponent<PlayerMovement>().PressDie();
                Playerdiecount = Playerdiecount + 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            if (!detecPlayer) {
                PlayerCount = PlayerCount + 1;
                if (PlayerCount == 2) {
                    Ceiling.GetComponent<FallCeilingControll>().Playerassemble();
                    startFall = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerCount = PlayerCount - 1;
            if (startFall && (PlayerCount != 2))
            {
                Ceiling.GetComponent<FallCeilingControll>().PlayerLeave();
                startFall = false;
            }
        }
    }
}
