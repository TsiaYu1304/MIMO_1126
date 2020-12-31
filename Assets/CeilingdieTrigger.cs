using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingdieTrigger : MonoBehaviour
{
    bool detecPlayer = false;
    int Playerdiecount = 0;
    public GameObject Ceiling;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerdiecount == 2) {
            Playerdiecount = 0;
            Ceiling.GetComponent<FallCeilingControll>().ResetGear();
            detecPlayer = false;
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
}
