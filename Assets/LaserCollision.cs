using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public bool isStraight = false;
    public GameObject HitLaser,NoHitLaser;

  

    public void setHit() {
        NoHitLaser.SetActive(false);
        HitLaser.SetActive(true);

    }

    public void setExit() {
        HitLaser.SetActive(false);
        NoHitLaser.SetActive(true);
    }
    //-2.956106f
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("有碰到");
        if (collision.tag == "UpGear")
        {
            setHit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "UpGear")
        {
            setExit();  
        }
    }
}
