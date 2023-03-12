using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserEyes : MonoBehaviour
{
    public KeyCode keyLeft, keyRight;

    private Vector3 position;
    private float speed;



    //PlayerControl controls;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        /* if (leftlaserGoLeft.triggered || rightLaserGoLeft.triggered)
         {
             turnLeft();
         }

         if (rightLaserGoLeft.triggered || rightLaserGoRight.triggered)
         {
             turnRight();
         }*/
    }

    public void moveEyes()
    {
        /*if ((Input.GetKeyDown(keyLeft) || Input.GetKey(keyLeft)) && this.transform.position.x >= -4.5)
        {
            position = this.transform.position;
            position.x -= 0.1f;
            this.transform.position = position;
        }
        else if ((Input.GetKeyDown(keyRight) || Input.GetKey(keyRight)) && this.transform.position.x <= 4.5)
        {
            position = this.transform.position;
            position.x += 0.1f;
            this.transform.position = position;
        }*/
    }

    public void turnLeft(GameObject obj)
    {
        if (obj.transform.position.x >= -4.5)
        {
            position = obj.transform.position;
            position.x -= 0.2f;
            obj.transform.position = position;
        }
    }

    public void turnRight(GameObject obj)
    {
        if (obj.transform.position.x <= 4.5)
        {
            position = obj.transform.position;
            position.x += 0.2f;
            obj.transform.position = position;
        }
    }
}
