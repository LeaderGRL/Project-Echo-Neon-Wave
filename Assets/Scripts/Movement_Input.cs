using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Movement_Input : MonoBehaviour
{
    private LaserEyes laser;
    public PlayerControl control;
    public InputAction rMovement;
    public InputAction lMovement;    


    private void Awake()
    {
        control = new PlayerControl();
        laser = new LaserEyes();
    }

    private void OnEnable()
    {
        rMovement = control.Player.RightLaserMovement;
        rMovement.Enable();

        lMovement = control.Player.LeftLaserMovement;
        lMovement.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        rMovement.Disable();
        lMovement.Disable();
    }

    private void FixedUpdate()
    {
        if (rMovement.ReadValue<float>() == 1)
        {
            laser.turnRight(GameObject.Find("RightLaserEye"));
        }
        else if (rMovement.ReadValue<float>() == -1)
        {
            laser.turnLeft(GameObject.Find("RightLaserEye"));
        }

            if (lMovement.ReadValue<float>() == -1)
            {
                laser.turnLeft(GameObject.Find("LeftLaserEye"));
            }
            else if (lMovement.ReadValue<float>() == 1)
            {
                laser.turnRight(GameObject.Find("LeftLaserEye"));
            }
        }
}
