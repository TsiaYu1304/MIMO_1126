using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTrigger : MonoBehaviour
{
    public Transform upPoint_1;
    public Transform upPoint_2;
    public Transform downPoint_1;
    public Transform downPoint_2;

    public GameObject Mimi;
    public GameObject Momo;

    bool mimiin = false;
    bool momoin = false;

    [Header("漂浮變數")]
    public int FloatType = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFloatType(int type) {
        FloatType = type;
        if (mimiin) {
            if (FloatType == 1)
            {
                Mimi.GetComponent<PlayerControl>().setFloat(upPoint_1.position.y, downPoint_1.position.y);
            }
            else if (FloatType == 2)
            {
                Mimi.GetComponent<PlayerControl>().setFloat(upPoint_2.position.y, downPoint_2.position.y);
            }
            else if (FloatType == 0)
            {
                Mimi.GetComponent<PlayerControl>().setstopFloat();
            }
        }

        if (momoin)
        {
            if (FloatType == 1)
            {
                Momo.GetComponent<PlayerControl>().setFloat(upPoint_1.position.y, downPoint_1.position.y);
            }
            else if (FloatType == 2)
            {
                Momo.GetComponent<PlayerControl>().setFloat(upPoint_2.position.y, downPoint_2.position.y);
            }
            else if (FloatType == 0)
            {
                Momo.GetComponent<PlayerControl>().setstopFloat();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {


            if (collision.gameObject == Mimi) { mimiin = true; }
            else if (collision.gameObject == Momo) { momoin = true; }
            if (FloatType == 1) 
            {
                collision.GetComponent<PlayerControl>().setFloat(upPoint_1.position.y, downPoint_1.position.y);
            }else if (FloatType == 2)
            {
                collision.GetComponent<PlayerControl>().setFloat(upPoint_2.position.y, downPoint_2.position.y);
            }
            else if (FloatType == 0)
            {
                collision.GetComponent<PlayerControl>().setstopFloat();
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            if (collision.gameObject == Mimi) { mimiin = false; }
            else if (collision.gameObject == Momo) { momoin = false; }
            collision.GetComponent<PlayerControl>().setstopFloat();
        }
    }
}
