using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_UpGate : MonoBehaviour
{
    [Header("控制物件")]
    public GameObject controllUpGate;
    private SpriteRenderer rend;
    public AudioSource PushSound;
    public Sprite Up_Sprite;
    public Material Up_Material;
    public Sprite Down_Sprite;
    public Material Down_Material;

    // Start is called before the first frame update

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)  //踩到的話就上升
    {
        if (collision.tag == "Player" || collision.tag == "EnemyAI" || collision.tag == "CombinePlayer")
        {
            if (collision.tag == "Player")
            {
                PushSound.Play();
                controllUpGate.GetComponent<buttonOpenGate>().changetoOpen(true);
            }
            else {
                controllUpGate.GetComponent<buttonOpenGate>().changetoOpen(false);
            }
            rend.sprite = Down_Sprite;
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "EnemyAI" || collision.tag == "CombinePlayer")
        {
            controllUpGate.GetComponent<buttonOpenGate>().changetoDown();
            rend.sprite = Up_Sprite;
        }
    }

}
