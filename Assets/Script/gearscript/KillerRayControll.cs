using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KillerRayControll : MonoBehaviour
{

    [Header("Laser參數")]
    public GameObject Laser;
    public Transform rotatpoint;
    bool isShoot = false;
    float time = 0;
    public bool open = false;
    float f_x ;
    float f_y;

    public Animator anim;


// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (open) setAnimOpen();
    }

    private void Update()
    {
        if (isShoot) {
            if (time < 0.5f)
            {
                time = time + Time.deltaTime;
            }
            else if (time > 0.5f && time < 1.2f)
            {
                
                Laser.GetComponent<LaserTut>().closeLaser();
                time = time + Time.deltaTime;

            }
            else if(time > 1.2f){
                time = 0;
                isShoot = false;
                rotatpoint.rotation = Quaternion.Euler(0, 0, 0);
                Laser.GetComponent<LaserTut>().ForwardPointedit();
            }
        }
    }


    public void setAnimOpen() {
        anim.SetBool("Open", true);
    }
    public void setAnimClose()
    {
        anim.SetBool("Open", false);
    }

    public void KillPlayer(Vector3 PlayerPosition) {

       
        Vector2 shootDir = PlayerPosition - transform.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg + 90f ;
        //float radiant = Mathf.Abs(shootDir.y) / Mathf.Abs(shootDir.x);
        //float degree = 180 / Mathf.PI * radiant;

        rotatpoint.rotation = Quaternion.Euler(0, 0 ,angle);
        EnableLaser(PlayerPosition);

        isShoot = true;
    }


    void EnableLaser(Vector3 PlayerPosition) {
       // f_x = PlayerPosition.x - firePoint.position.x;
        //f_y = -2.862f - firePoint.position.y;
        
       
        Laser.SetActive(true);
        Laser.GetComponent<LaserTut>().SetLaserPoint(PlayerPosition);
        Laser.GetComponent<LaserTut>().openLaser();
    }

    void UpdateLaser() {

    }

    void DisableLaser() {
    }
}
