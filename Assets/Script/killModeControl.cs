using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killModeControl : MonoBehaviour
{
    int PlayerCount = 0;
    public GameObject[] warmLight;
    public GameObject[] button;
    public GameObject[] Enemy_Generate;
    public GameObject[] RedGate;
    int i_button = 0;
    int i_Ramdon = 0;
    bool OpenAllbutton = false;
    bool CloseAllbutton = false;
    bool readyTokill = false;
    bool readytoRelease = false;
    bool isLeft = false;
    float time = 0;
    int EnemyDie_Count = 0;
    bool Stopkillmode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCount == 2) {
            PlayerCount = -10;
            killModeOpen();
            
        }
        if (OpenAllbutton) {
            if (time > 0.2f)
            {
                button[i_button].GetComponent<Button_LaserControll>().SetcanPush();
                i_button = i_button + 1;
                if (i_button == 4)  //如果已經全部都開了
                {
                    i_button = 3; //數字停在最後一顆
                    CloseAllbutton = true; //開始準備關掉全部的燈
                    OpenAllbutton = false;
                    time = -1;
                }
                else
                {
                    time = 0;
                }

            }
            else {
                time = time + Time.deltaTime;
            }
        }

        if (CloseAllbutton) {
            if (time > 0.2f)
            {
                button[3].GetComponent<Button_LaserControll>().SetcannotPush();
                button[2].GetComponent<Button_LaserControll>().SetcannotPush();
                button[1].GetComponent<Button_LaserControll>().SetcannotPush();
                button[0].GetComponent<Button_LaserControll>().SetcannotPush();
                CloseAllbutton = false;
                time = 0;
                if(!Stopkillmode) readyTokill = true;
                
            }
            else {
                time = time + Time.deltaTime;
            }
        }

        if (readyTokill) {
            if (time > 0.5)
            {
                readyTokill = false;
                RandomButton();
                time = 0;
            }
            else {
                time = time + Time.deltaTime;
            }
        }

        if (readytoRelease)
        {
            if (time > 0.5)
            {
                readytoRelease = false;
                RandomRobotRelease();
                time = 0;
                

            }
            else
            {
                time = time + Time.deltaTime;
            }
        }
    }

    public void killModeOpen()
    {
        for (int i = 0; i < 5; i++)
        {
            RedGate[i].GetComponent<RedGate>().ClosetheGate();
        }
        OpenAllbutton = true;
        
    }

    public void AddDieCount() {
        EnemyDie_Count = EnemyDie_Count + 1;
        if (EnemyDie_Count < 4)
        {
            CloseAllbutton = true;
            time = 0;
        }
        else {
            for (int i = 0; i < 5; i++)
            {
                RedGate[i].GetComponent<RedGate>().backtheGate();
            }
            Stopkillmode = true;
            CloseAllbutton = true;
        }
    }

    public void OpenbuttonLight() {
        if (i_Ramdon == 1)
        {
            button[0].GetComponent<Button_LaserControll>().SetcanPush();
            button[1].GetComponent<Button_LaserControll>().SetcanPush();
        }
        else if (i_Ramdon == 2)
        {
            button[2].GetComponent<Button_LaserControll>().SetcanPush();
            button[3].GetComponent<Button_LaserControll>().SetcanPush();
        }
        else if (i_Ramdon == 3) {
            button[1].GetComponent<Button_LaserControll>().SetcanPush();
            button[3].GetComponent<Button_LaserControll>().SetcanPush();
        }
        else if (i_Ramdon == 4)
        {
            button[0].GetComponent<Button_LaserControll>().SetcanPush();
            button[2].GetComponent<Button_LaserControll>().SetcanPush();
        }
        readytoRelease = true;
    }

    public void ClosebuttonLight()
    {
        if (i_Ramdon == 1)
        {
            button[0].GetComponent<Button_LaserControll>().SetcannotPush();
            button[1].GetComponent<Button_LaserControll>().SetcannotPush();
        }
        else if (i_Ramdon == 2)
        {
            button[2].GetComponent<Button_LaserControll>().SetcannotPush();
            button[3].GetComponent<Button_LaserControll>().SetcannotPush();
        }
        else if (i_Ramdon == 3)
        {
            button[1].GetComponent<Button_LaserControll>().SetcannotPush();
            button[3].GetComponent<Button_LaserControll>().SetcannotPush();
        }
        else if (i_Ramdon == 4)
        {
            button[0].GetComponent<Button_LaserControll>().SetcannotPush();
            button[2].GetComponent<Button_LaserControll>().SetcannotPush();
        }

        readyTokill = true;
    }

    public void RandomButton()
    {
        i_Ramdon = Random.Range(1, 5);
        OpenbuttonLight();
    }

    public void RandomRobotRelease() {
        if (isLeft) { 
            Enemy_Generate[1].GetComponent<killmodeEnemyGenerator>().GenerateEnemy();
            warmLight[1].SetActive(true);
        }
        else { 
            Enemy_Generate[0].GetComponent<killmodeEnemyGenerator>().GenerateEnemy();
            warmLight[0].SetActive(true);
        }
        isLeft = !isLeft;
    }


    public void PlayerAdd() {
        PlayerCount = PlayerCount + 1;
    }

    public void PlayerSub() {
        PlayerCount = PlayerCount - 1;
    }
}
