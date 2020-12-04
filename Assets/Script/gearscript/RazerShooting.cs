using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazerShooting : MonoBehaviour
{
    [Header("狀態參數")]
    bool isShooting = false;
    [Header("移動參數")]
    public float RazerSpeed = 1f;
    Vector2 shootVec2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isShooting) {
            transform.position = transform.position +  new Vector3 (shootVec2.x * RazerSpeed * Time.deltaTime, shootVec2.y * RazerSpeed * Time.deltaTime,0);
        }
    }
    public void setShootVec2(Vector2 shootDir) {
        shootVec2 = shootDir;
        isShooting = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isShooting = false;
    }
}
