using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_LaserControll : MonoBehaviour
{
    [Header("物件控制")]
    public GameObject LaserFire;
    bool TurnOn = true;
    bool PlayerTriggerme = false;

    [Header("元件控制")]
    private SpriteRenderer rend;

    public Sprite Laser_Turnon;
    public Sprite Laser_Turnoff;
    public Material Laser_Turnon_material;
    public Material Laser_Turnoff_material;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerLaser() {

        if (TurnOn) TurnoffLaser(); //燈如果開著
        else TurnOnLaser();
    }

    public void TurnoffLaser()
    {
        if (PlayerTriggerme)
        {
            LaserFire.SetActive(false);
            TurnOn = false;
            rend.sprite = Laser_Turnoff;
        }
    }

    public void TurnOnLaser()
    {
        if (PlayerTriggerme)
        {
            LaserFire.SetActive(true);
            TurnOn = true;
            rend.sprite = Laser_Turnon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            PlayerTriggerme = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            PlayerTriggerme = false;
        }
    }

}
