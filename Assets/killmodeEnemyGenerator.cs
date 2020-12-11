using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killmodeEnemyGenerator : MonoBehaviour
{
    public GameObject ControllTrigger;
    public GameObject Enemy;

    public bool isLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEnemy() {
        GameObject GenEnemy =  Instantiate(Enemy, transform.position, Quaternion.identity);
        GenEnemy.GetComponent<EnemyControlltest>().setDirection(isLeft);
    }

}
