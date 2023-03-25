using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Uduino;
using System.Globalization;

public class Movement_Input : MonoBehaviour
{
    [SerializeField] private LaserEyes laser;
    [SerializeField] private GameObject rightLaser;
    [SerializeField] private GameObject leftLaser;
    [SerializeField] public PlayerControl control;
    private InputAction rMovement;
    private InputAction lMovement;
    private UduinoManager uduinoManager;
    private float rightCursorValue;
    private float leftCursorValue;






    private void Awake()
    {
        control = new PlayerControl();        
        //control = new PlayerControl();
        //laser = new LaserEyes();
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
        uduinoManager = UduinoManager.Instance;
        uduinoManager.OnDataReceived += DataReceived;
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
        laser.turnRight(rightLaser, rightCursorValue);
        laser.turnRight(leftLaser, leftCursorValue);

        //if (rMovement.ReadValue<float>() == 1)
        //{
        //}
        //else if (rMovement.ReadValue<float>() == -1)
        //{
        //    laser.turnLeft(GameObject.Find("RightLaserEye"));
        //}

        //    if (lMovement.ReadValue<float>() == -1)
        //    {
        //        laser.turnLeft(GameObject.Find("LeftLaserEye"));
        //    }
        //    else if (lMovement.ReadValue<float>() == 1)
        //    {
        //        laser.turnRight(GameObject.Find("LeftLaserEye"));
        //    }
    }

    public void DataReceived(string Data, UduinoDevice board)
    {
        string[] extractData = Data.Split(';');
        //int.TryParse(Data, out cursorValue);
        //float.TryParse(Data, out cursorValue);
        //cursorValue = float.Parse(Data, CultureInfo.InvariantCulture.NumberFormat);
        //cursorValue = System.Convert(Data);

        leftCursorValue = float.Parse(extractData[0], CultureInfo.InvariantCulture.NumberFormat);
        rightCursorValue = float.Parse(extractData[1], CultureInfo.InvariantCulture.NumberFormat);

        Debug.Log("left : " + leftCursorValue);
        Debug.Log("right : " + rightCursorValue);
    }

}
