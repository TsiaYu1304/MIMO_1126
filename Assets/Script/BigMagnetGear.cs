using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMagnetGear : MonoBehaviour
{
    [Header("控制元件")]
    GameObject CombinePlayer;
    public SpriteRenderer rend;
    public Animator anim;

    [Header("狀態變數")]
    public bool islast = false;
    public bool NeedRamdom = false;
    public bool isBlue = true;
    
    public float gravityscale;

    [Header("render用")]
    public Sprite Blue;
    public Sprite Red;
    public Material m_Blue;
    public Material m_Red;

    float time = 0;
    bool canclock = true;
    int randkind = 0;
    bool canMagnet = false;

    public AudioSource sounds;
    
    
    
    
    // Start is called before the first frame update

    void Start()
    {
        if (isBlue)
        {
            rend.sprite = Blue;
            rend.material = m_Blue;
        }
        else if (!isBlue)
        {
            rend.sprite = Red;
            rend.material = m_Red;
        }
        //    //rend = GetComponent<SpriteRenderer>();
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

        if (CombinePlayer != null && (CombinePlayer.GetComponent<CombinePlayerControll>().Magnetic == true))
        {
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
            else
            {
                if (CombinePlayer.GetComponent<CombinePlayerControll>().Onbottom == 0)
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = gravityscale;
                }
                else
                {
                    CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = -gravityscale;
                }
            }

            if (NeedRamdom)
            {
                anim.SetBool("Active", true);
            }
            else
            {
                if (isBlue) anim.SetBool("Blue", true);
                else anim.SetBool("Red", true);
            }
        }

        
    }
      
   

    private void RandNumber() {

        //int randomNumber = Random.Range(0,2);
        isBlue = !isBlue;
        if (isBlue)
        {

            rend.sprite = Blue;
            rend.material = m_Blue;

            if (anim.GetBool("Red"))
            {

                anim.SetBool("Blue", true);
                anim.SetBool("Red", false);
            }
        }
        else
        {
            rend.sprite = Red;
            rend.material = m_Red;

            if (anim.GetBool("Blue") == true)
            {
                anim.SetBool("Red", true);
                anim.SetBool("Blue", false);
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer" && !collision.isTrigger) {
            CombinePlayer = collision.gameObject;
            canMagnet = true;
            SetPlayergravity();
            sounds.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CombinePlayer" && !collision.isTrigger)
        {
            Debug.Log(gameObject.name + " " + collision.gameObject.name);

            if (islast) CombinePlayer.GetComponent<Rigidbody2D>().gravityScale = 7;
            CombinePlayer = null;
            canMagnet = false; ;

            if (!NeedRamdom)
            {
                if (isBlue) anim.SetBool("Blue", false);
                else anim.SetBool("Red", false);
            }
            else
            {
                anim.SetBool("Active", false);
            }

            sounds.Pause();
        }
    }

}
