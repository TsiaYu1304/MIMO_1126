using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTrigger : MonoBehaviour
{
    public Transform upPoint_1;
    public Transform upPoint_2;
    public Transform downPoint_1;
    public Transform downPoint_2;

    public BoxCollider2D collider2, collider1;

    public GameObject Mimi;
    public GameObject Momo;
    public GameObject MiMo;
    public GameObject Windanime;

    public bool havegear = false;

    bool mimiin = false;
    bool momoin = false;
    bool mimoin = false;

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
    
    public void HitGear()
    {
        print("collide");
        FloatType = 1;
        setFloatType(1);
        Windanime.GetComponent<WindControl>().SetFloatType(1);
        Windanime.transform.position = Windanime.transform.position - new Vector3(0, 2.66f, 0);
        collider2.enabled = false;
        collider1.enabled = true;
    }
    public void ExitGear() {
        FloatType = 2;
        setFloatType(2);
        Windanime.GetComponent<WindControl>().SetFloatType(2);
        Windanime.transform.position = Windanime.transform.position + new Vector3(0, 2.66f, 0);
        collider1.enabled = false;
        collider2.enabled = true;
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

        if (mimoin)
        {
            if (FloatType == 1)
            {
                MiMo.GetComponent<CombinePlayerControll>().setFloat(upPoint_1.position.y, downPoint_1.position.y);
            }
            else if (FloatType == 2)
            {
                MiMo.GetComponent<CombinePlayerControll>().setFloat(upPoint_2.position.y, downPoint_2.position.y);
            }
            else if (FloatType == 0)
            {
                MiMo.GetComponent<CombinePlayerControll>().setstopFloat();
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

        if (collision.tag == "CombinePlayer" && !collision.isTrigger)
        {
            if (collision.gameObject == MiMo) { mimoin = true; }
            if (FloatType == 1)
            {
                collision.GetComponent<CombinePlayerControll>().setFloat(upPoint_1.position.y, downPoint_1.position.y);
            }
            else if (FloatType == 2)
            {
                collision.GetComponent<CombinePlayerControll>().setFloat(upPoint_2.position.y, downPoint_2.position.y);
            }
            else if (FloatType == 0)
            {
                collision.GetComponent<CombinePlayerControll>().setstopFloat();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "flowGear")
        {
            FloatType = 2;
            setFloatType(2);
            Windanime.GetComponent<WindControl>().SetFloatType(2);
        }

        if (collision.tag == "Player" && !collision.isTrigger)
        {
            if (collision.gameObject == Mimi) { mimiin = false; }
            else if (collision.gameObject == Momo) { momoin = false; }
            collision.GetComponent<PlayerControl>().setstopFloat();
        }

        if (collision.tag == "CombinePlayer" &&!collision.isTrigger) {
            if (collision.gameObject == Mimi) { mimoin = false; }
            collision.GetComponent<CombinePlayerControll>().setstopFloat();
        }
    }
}
