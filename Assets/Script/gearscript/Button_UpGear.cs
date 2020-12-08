using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_UpGear : MonoBehaviour
{
    [Header("控制物件")]
    public GameObject controllUpGear;
    // Start is called before the first frame update
    public Sprite Down_Sprite;
    public Sprite Up_Sprite;
    public Material Up_Material;
    public Material Down_Material;
    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)  //踩到的話就上升
    {
        if ((collision.tag == "Player" || collision.tag == "CombinePlayer") && !collision.isTrigger) {
            controllUpGear.GetComponent<UpGear>().changeUp();
            rend.sprite = Down_Sprite;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Player"|| collision.tag == "CombinePlayer" )&& !collision.isTrigger)
        {
            controllUpGear.GetComponent<UpGear>().changeDown();
            rend.sprite = Up_Sprite;
        }
    }
}
