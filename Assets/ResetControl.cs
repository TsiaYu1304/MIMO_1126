using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class ResetControl : MonoBehaviour
{

    public PlayerInput playerControls;
    public GameObject mimi;
    public GameObject momo;

    [Header("第三關")]
    public Transform replayPoint3;
    public GameObject windcontroller;
    public GameObject windGear;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReplayPlayer() {
        if (mimi.GetComponent<PlayerMovement>().getReplayPoint() == replayPoint3)
        {
            windcontroller.GetComponent<button_Floatcontrol>().ResetFlow();
        }
        mimi.GetComponent<PlayerMovement>().Replay();
        momo.GetComponent<PlayerMovement>().Replay();
    }


    public void OnReset(CallbackContext context)
    {
        if (context.performed) {
            
            ReplayPlayer();
        }
    }
}
