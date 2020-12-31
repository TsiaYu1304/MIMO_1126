using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killmodeEnemyGenerator : MonoBehaviour
{
    public GameObject warmLight;
    public GameObject killmodeController;
    public Transform closePoint;
    public GameObject ControllTrigger;
    public GameObject Enemy;
    GameObject controlenemy;
    public GameObject RedGate;
    public Transform GenPoint;
    public bool isLeft = true; //要產生往左邊的
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controlenemy != null) {
            if (isLeft) //在左邊
            {
                if (controlenemy.transform.position.x  > closePoint.position.x)
                {
                    ControllTrigger.SetActive(true);
                    RedGate.GetComponent<RedGate>().ClosetheGate();
                    controlenemy = null;
                    warmLight.SetActive(false);
                }

            }
            else {
                if (controlenemy.transform.position.x < closePoint.position.x)
                {
                    ControllTrigger.SetActive(true);
                    RedGate.GetComponent<RedGate>().ClosetheGate();
                    controlenemy = null;
                    warmLight.SetActive(false);
                }
            }
        }
    }

    public void GenerateEnemy() {
        RedGate.GetComponent<RedGate>().backtheGate();
        GameObject GenEnemy =  Instantiate(Enemy, new Vector3 (GenPoint.position.x, GenPoint.position.y,10), Quaternion.identity);
        GenEnemy.GetComponent<EnemyControlltest>().setDirection(isLeft,killmodeController);
        ControllTrigger.SetActive(false);
        controlenemy = GenEnemy;

    }

}
