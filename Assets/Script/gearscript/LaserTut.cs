using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTut : MonoBehaviour
{
    public GameObject Laser;
    public LineRenderer linerender;
    public Transform firePoint;
    public Transform ToPoint;
    // Start is called before the first frame update
    void Start()
    {
        //linerender.enabled = true;
        //UpdateLaser();
        //DisableLLaser();
    }

    //void UpdateLaser()
    //{
    //    linerender.SetPosition(0, firePoint.position);
    //    linerender.SetPosition(1, ToPoint.position);
    //}

    
    public void EnableLaser() {
        //linerender.enabled = true;
       // UpdateLaser();
        //Laser.SetActive(true);
    }


    public void DisableLLaser() {
        //linerender.enabled = false;
        Laser.SetActive(false);
    }
}
