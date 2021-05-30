using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserfive_Controll : MonoBehaviour
{
    bool Gearopen = true;
    float time = 0;
    bool Laseropen = false;
    int num = 0;
    public GameObject[] Laserfire;
    public GameObject[] killerRay;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Gearopen) { //整個裝置是開的 

            

            if (Laseropen) //雷射是開著的
            {
                if (time > 0.8f)
                {
                    killerRay[num].GetComponent<KillerRayControll>().setAnimClose();
                    Laserfire[num].GetComponent<LaserTut>().closeLaser();
                    num = num + 1;
                    time = 0;
                    Laseropen = false;
                }
                else {
                    time = time + Time.deltaTime;
                }
                
                
            }
            else{

                if (time > 0.2f)
                {
                    if (num == 5) num = 0;  //重來
                    Laserfire[num].SetActive(true);
                    killerRay[num].GetComponent<KillerRayControll>().setAnimOpen();
                    Laserfire[num].GetComponent<LaserTut>().openLaser();
                    time = 0;
                    Laseropen = true;
                }
                else
                {
                    time = time + Time.deltaTime;
                }
            }
            
        }
        
    }

    void openLaser() {
        Laserfire[num].GetComponent<LaserTut>().openLaser();
        
    }


    public void closeLaser() { //關掉
        Laserfire[num].GetComponent<LaserTut>().closeLaser();
        Gearopen = false;
    }
}
