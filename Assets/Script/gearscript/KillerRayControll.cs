using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KillerRayControll : MonoBehaviour
{
    
    [Header("Laser參數")]
    public GameObject Laser;
    public Transform firePoint;
    bool isShoot = false;

    float f_x ;
    float f_y;

    public bool Canshootlaser = true;
    public Animator anim;


// Start is called before the first frame update
void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAnimOpen() {
        anim.SetBool("Open", true);
        Debug.Log("開起雷射");
    }
    public void setAnimClose()
    {
        anim.SetBool("Open", false);
        Debug.Log("關閉雷設");
    }

    public void KillPlayer(Vector3 PlayerPosition) {

       
        Vector2 shootDir = PlayerPosition - transform.position;
        //float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg + 90f ;
        float radiant = Mathf.Abs(shootDir.y) / Mathf.Abs(shootDir.x);
        float degree = 180 / Mathf.PI * radiant;

        transform.rotation = Quaternion.Euler(0, 0 ,-degree);
        
        
        EnableLaser(PlayerPosition);

    }


    void EnableLaser(Vector3 PlayerPosition) {
        f_x = PlayerPosition.x - firePoint.position.x;
        f_y = -2.862f - firePoint.position.y;
        
        Laser.GetComponent<VolumetricLines.VolumetricLineBehavior>().SetEndPoint(firePoint.position.x, firePoint.position.y);
        Laser.GetComponent<VolumetricLines.VolumetricLineBehavior>().SetStartPoint(f_x, f_y);
        
        Laser.SetActive(true);
        isShoot = true;
    }

    void UpdateLaser() {

    }

    void DisableLaser() {
    }
}
