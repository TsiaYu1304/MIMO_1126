using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMoveLaser : MonoBehaviour
{
    public Transform[] Point;
    public GameObject[] Laserhead;
    public GameObject[] Laserfire;//0:L,1:R,2:水平的
    public BoxCollider2D box;

    float time = 0;
    float chagetime = 2;
    int playercount = 0;
    bool start = false;
    int state = 0;

    // Start is called before the first frame update
    void Start()
    {

       // openobject();
    }

    public void openobject() {
        start = true;
        state = -1;

        Laserfire[0].GetComponent<LaserTut>().openLaser();
        Laserfire[1].GetComponent<LaserTut>().openLaser();
        Laserfire[2].GetComponent<LaserTut>().openLaser();

        Laserhead[0].GetComponent<KillerRayControll>().setAnimOpen();
        Laserhead[1].GetComponent<KillerRayControll>().setAnimOpen();
        Laserhead[2].GetComponent<KillerRayControll>().setAnimOpen();

        


    }

    void movelaser() {

        if (state == 0) //中間
        {
            Laserhead[0].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[1], false);
            Laserfire[0].GetComponent<LaserTut>().startmove_SinglePoint(Point[1], false);

            Laserhead[1].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[2], true);
            Laserfire[1].GetComponent<LaserTut>().startmove_SinglePoint(Point[2], true);

        }
        else if (state == 1) //左邊
        {
            Laserhead[0].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[0], true);
            Laserfire[0].GetComponent<LaserTut>().startmove_SinglePoint(Point[0], true);
            Laserhead[1].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[1], true);
            Laserfire[1].GetComponent<LaserTut>().startmove_SinglePoint(Point[1], true);
        }
        else if (state == 2) //右邊+水平往上
        {
            Laserhead[0].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[2], false);
            Laserfire[0].GetComponent<LaserTut>().startmove_SinglePoint(Point[2], false);
            Laserhead[1].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[3], false);
            Laserfire[1].GetComponent<LaserTut>().startmove_SinglePoint(Point[3], false);
            Laserhead[2].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[4], false);
            Laserfire[2].GetComponent<LaserTut>().startmove_SinglePoint(Point[4], false);
        }
        else if (state == 3)
        { //中間 水平往下
            Laserhead[0].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[1], true);
            Laserfire[0].GetComponent<LaserTut>().startmove_SinglePoint(Point[1], true);
            Laserhead[1].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[2], true);
            Laserfire[1].GetComponent<LaserTut>().startmove_SinglePoint(Point[2], true);
            Laserhead[2].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[5], true);
            Laserfire[2].GetComponent<LaserTut>().startmove_SinglePoint(Point[5], true);
        }
        else if (state == 4)
        { //回左右邊關掉
            Laserhead[0].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[0], true);
            Laserfire[0].GetComponent<LaserTut>().startmove_SinglePoint(Point[0], true);
            Laserhead[1].GetComponent<KillerRayControll>().startmove_SinglePoint(Point[3], false);
            Laserfire[1].GetComponent<LaserTut>().startmove_SinglePoint(Point[3], false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (start) {

            if (time > chagetime)
            {
                state = state + 1;
                time = 0;
                if (state == 5)
                {
                    Laserhead[0].GetComponent<KillerRayControll>().setAnimClose();
                    Laserfire[0].GetComponent<LaserTut>().closeLaser();
                    Laserhead[1].GetComponent<KillerRayControll>().setAnimClose();
                    Laserfire[1].GetComponent<LaserTut>().closeLaser();
                    Laserhead[2].GetComponent<KillerRayControll>().setAnimClose();
                    Laserfire[2].GetComponent<LaserTut>().closeLaser();
                }
                else
                {
                    if (state == 2) { chagetime = 4.0f; }
                    else if (state == 3) { chagetime = 2.0f; }
                    movelaser();
                }
            }
            else
            {
                time = time + Time.deltaTime;
            }

            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            playercount = playercount + 1;
            if (playercount == 2)
            {
                box.enabled = false;
                openobject();
            }
        }
    }
}
