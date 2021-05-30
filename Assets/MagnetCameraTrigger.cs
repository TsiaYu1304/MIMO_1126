using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCameraTrigger : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject scaleCamera;
    public GameObject DialogGUI;
    public GameObject DialogManager;
    public bool MagnetTrigger = false;
    public GameObject LearnAnim;
    int i_Player = 0;
    bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i_Player == 2) {
            i_Player = 3;
            openScaleCamera();
        }
    }

    public void closeScaleCamera() {
        Camera1.SetActive(true);
        scaleCamera.SetActive(false);
        if (MagnetTrigger) LearnAnim.SetActive(false); ;

    }

    public void openScaleCamera() {
        scaleCamera.SetActive(true);
        Camera1.SetActive(false);
        DialogGUI.SetActive(true);
        print("UI開啟");
        DialogGUI.GetComponent<DiaLogGUIControl>().opendialogGUI();
        if (MagnetTrigger) LearnAnim.SetActive(true);
        DialogManager.GetComponent<Dialog_Learn>().NextSentence();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.isTrigger) {
            i_Player = i_Player + 1;
        }
    }

}
