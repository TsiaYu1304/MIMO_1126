using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_BlueLine : MonoBehaviour
{
    public GameObject MoveLaserController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            //觸發到玩家就啟動雷射
            MoveLaserController.GetComponent<MoveLaserControll>().StarttoMove();
        }
    }
}
