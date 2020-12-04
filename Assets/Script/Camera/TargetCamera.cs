using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera2P, CameraCombine;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisCombine()
    {
        Camera2P.SetActive(true);
        CameraCombine.SetActive(false);

    }

    public void Combine()
    {
        CameraCombine.SetActive(true);
        Camera2P.SetActive(false);

    }
}
