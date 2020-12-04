using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTrigger : MonoBehaviour
{
    public Transform upPoint;
    public Transform downPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            collision.GetComponent<PlayerControl>().setFloat(upPoint.position.y, downPoint.position.y);        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            collision.GetComponent<PlayerControl>().setstopFloat();
        }
    }
}
