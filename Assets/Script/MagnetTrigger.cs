using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTrigger : MonoBehaviour
{

    [Header("控制物件")]
    public GameObject Magnet;
    bool isBlue;
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        isBlue = Magnet.GetComponent<MagnetGear>().isBlue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer" && !collision.isTrigger) {

            if (collision.GetComponent<CombinePlayerControll>().Magnetic == true) { //吸引力模式開了嗎
               
                int bottomkind = collision.GetComponent<CombinePlayerControll>().Onbottom;
                if (isBlue)  //藍色磁鐵 MOMO在下
                { 
                    if(bottomkind == 0)Magnet.GetComponent<MagnetGear>().setAttract(); 
                    else if(bottomkind == 1) Magnet.GetComponent<MagnetGear>().setRepel();
                }
                else   //藍色磁鐵 MOMO在下
                {
                    if (bottomkind == 0) Magnet.GetComponent<MagnetGear>().setRepel();
                    else if (bottomkind == 1) Magnet.GetComponent<MagnetGear>().setAttract();
                }
            }
        }
    }
}
