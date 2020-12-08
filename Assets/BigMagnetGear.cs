using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMagnetGear : MonoBehaviour
{

    GameObject CombinePlayer;
    public bool islast = false;
    public bool NeedRamdom = false;
    float time = 0;
    bool canclock = true;
    int randkind = 0;
    bool canMagnet = false;
    public bool isBlue = true;
    public SpriteRenderer rend;
    public float gravityscale;
    public Sprite Blue;
    public Sprite Red;
    public Material m_Blue;
    public Material m_Red;
    // Start is called before the first frame update

    void Start()
    {
        if (isBlue)
        {
            rend.sprite = Blue;
            rend.material = m_Blue;
        }
        else if (!isBlue) {
            rend.sprite = Red;
            rend.material = m_Red;
        }
        //rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NeedRamdom) {
            time = time + Time.deltaTime;
            if (time > 5.0f)
            {
                time = 0;
                changeMagnetic();
            }
        }
        
    }
        
    
    void changeMagnetic() {

        RandNumber();
        SetPlayergravity();
        
    }

    void SetPlayergravity()
    {
        if (CombinePlayer != null && (CombinePlayer.GetComponent<CombinePlayerControll>().Magnetic == true)) {
            if (isBlue)
            {
                if (CombinePlayer.GetComponent<CombinePlayerControll>().Onbottom == 0)
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = -gravityscale;
                }
                else
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = gravityscale;
                }

            }
            else {
                if (CombinePlayer.GetComponent<CombinePlayerControll>().Onbottom == 0)
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = gravityscale;
                }
                else
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = -gravityscale;
                }
            }
        }
    }
      
   

    private void RandNumber() {

        int randomNumber = Random.Range(0,2);
        if (randomNumber == 0)
        {
            isBlue = true;
            rend.sprite = Blue;
            rend.material = m_Blue;
        }
        else if(randomNumber == 1 || randomNumber == 2) { 
            isBlue = false;
            rend.sprite = Red;
            rend.material = m_Red;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer" && !collision.isTrigger) {
            CombinePlayer = collision.gameObject;
            canMagnet = true;
            SetPlayergravity();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer" && !collision.isTrigger)
        {
            if(islast) CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = 7;
            CombinePlayer = null;
            canMagnet = false; ;
            
        }
    }

}
