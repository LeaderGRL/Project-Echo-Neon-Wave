using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private float angle = 0.0f;
    private int direction;
    public GameObject RightLaserEye;
    public GameObject LeftLaserEye;
    private int lastLaserEyePosition = 0;
    private bool regressAngle = false;
    private bool startBend = false;
    private bool bend = false;
    private bool stopBend = false;
    private bool fullTurn = false;
    private bool swing = false;
    public float speedFullTurn1;
    public float speedFullTurn2;
    public float speedFullTurn3;
    public float speedSwing1;
    public float speedSwing2;
    public float speedBend;
    // Start is called before the first frame update
    void Start()
    {
        RightLaserEye = GameObject.Find("RightLaserEye");
        LeftLaserEye = GameObject.Find("LeftLaserEye");
        //StartFullTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (OneLaserEyeIsMoving() && !startBend && !stopBend) {
            bend = true;
        } else if (!OneLaserEyeIsMoving() && !TwoLaserEyeIsMoving() && !startBend && !stopBend) {
            EndBend();
            bend = false;
        }
        // if (!TwoLaserEyeIsMoving() && stopBend) {
        //     stopBend = false;
        //     StartCoroutine(StartBend());
        // }
        if (bend) {
            if (TwoLaserEyeIsMoving()) {
                bend = false;
                stopBend = true;
            } else {
                StartCoroutine(Bend());
            }
        }

        if (stopBend) {
            if (!TwoLaserEyeIsMoving()) {
                stopBend = false;
                if (OneLaserEyeIsMoving()) {
                    startBend = true;
                }
            } else {
                StartCoroutine(StopBend());
            }
        }

        if (startBend) {
            StartCoroutine(StartBend());
        }
        // if (bend)
        // {
        //     StartCoroutine(Bend());
        // } else if (fullTurn) {
        //     StartCoroutine(FullTurn());
        // } else if (swing)
        // {
        //     StartCoroutine(Swing());
        // } else if (stopBend) {
        //     StartCoroutine(StopBend());
        // }
    }

    void RestartBend()
    {
        if (RightLaserEye.transform.position.x < 1.8f)
        {
            angle = RightLaserEye.transform.position.x - speedBend;
            angle *= angle;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * -1, angle / 4);
        } else if (LeftLaserEye.transform.position.x > -1.8f)
        {
            angle = LeftLaserEye.transform.position.x + speedBend;
            angle *= angle;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * 1, angle / -4);
        }
        stopBend = false;
        bend = true;
    }

    void EndBend()
    {
        angle = 0;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
    }

    bool OneLaserEyeIsMoving() {
        if (RightLaserEye.transform.position.x < 1.8f && LeftLaserEye.transform.position.x < -1.8f)
        {
            return true;
        } else if (RightLaserEye.transform.position.x > 1.8f && LeftLaserEye.transform.position.x > -1.8f) {
            return true;
        }
        return false;
    }

    bool TwoLaserEyeIsMoving() {
        if (RightLaserEye.transform.position.x < 1.8f && LeftLaserEye.transform.position.x > -1.8f)
        {
            return true;
        }
        return false;
    }

    void StartFullTurn()
    {
        direction = RightLaserEye.transform.position.x > 1.8 ? -1 : 1;
        fullTurn = true;
    }

    int WhereIsLaserEye()
    {
        if (RightLaserEye.transform.position.x < -1.8 && RightLaserEye.transform.position.x > -3.6)
        {
            return direction == 1 ? 1 : 4;
        }
        else if (RightLaserEye.transform.position.x < 0 && RightLaserEye.transform.position.x > -1.8)
        {
            return direction == 1 ? 2 : 3;
        }
        else if (RightLaserEye.transform.position.x < 1.8 && RightLaserEye.transform.position.x > 0)
        {
            return direction == 1 ? 3 : 2;
        }
        else
        {
            return direction == 1 ? 4 : 1;
        }
    }

    int LimitIsReached()
    {
        int laserEyePosition = WhereIsLaserEye();

        if (laserEyePosition < lastLaserEyePosition || regressAngle == true)
        {
            regressAngle = true;
            lastLaserEyePosition = laserEyePosition;
            if (angle >= laserEyePosition * 5 - 5) { return -1; }
            else
            {
                regressAngle = false;
                return 0;
            }

        } else
        {
            lastLaserEyePosition = laserEyePosition;
            return angle >= laserEyePosition * 5 - 5 ? 0 : 1;
        }
    }
    
    IEnumerator Bend()
    {
        // if (RightLaserEye.transform.position.x < 1.8f && LeftLaserEye.transform.position.x > -1.8f) {
        //     bend = false;
        // } else 
        if (RightLaserEye.transform.position.x < 1.8f)
        {
            angle = RightLaserEye.transform.position.x - speedBend;
            angle *= angle;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * -1, angle / 4);
        } else if (LeftLaserEye.transform.position.x > -1.8f)
        {
            angle = LeftLaserEye.transform.position.x + speedBend;
            angle *= angle;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * 1, angle / -4);
        } 
        yield return new WaitForSeconds(0.001f);
    }

    IEnumerator StartBend()
    {
        float objectifAngle = 0.0f;

         if (RightLaserEye.transform.position.x < 1.8f)
        {
            objectifAngle = RightLaserEye.transform.position.x - speedBend;
            objectifAngle *= objectifAngle;
        } else if (LeftLaserEye.transform.position.x > -1.8f)
        {
            objectifAngle = LeftLaserEye.transform.position.x - speedBend;
            objectifAngle *= objectifAngle;
        }

        if (angle > objectifAngle) {
                angle -= speedBend;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * 1, angle / -4);
                if (angle <= objectifAngle) {
                    // RestartBend();
                    startBend = false;
                    // bend = true;
                }
        } else {
            angle += speedBend;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * -1, angle / 4);
            if (angle >= objectifAngle) {
                // RestartBend();
                startBend = false;
                // bend = true;
            }
        }
        
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator StopBend()
    {
        if (angle > 0) {
            angle -= speedBend;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * -1, angle / 4);
            if (angle <= 0) {
                EndBend();
            }
        } else {
            angle += speedBend;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * 1, angle / -4);
            if (angle >= 0) {
                EndBend();
            }
        }
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator FullTurn()
    {
        if (angle > 390)
        {
            fullTurn = false;
            swing = true;
        } else
        {

            if (angle > 80 || angle < 280)
            {
                angle += speedFullTurn3;
            } else if (angle > 40 || angle < 320)
            {
                angle += speedFullTurn2;
            } else { 
                angle += speedFullTurn1; 
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * direction, transform.eulerAngles.z);
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator Swing()
    {
        if (angle < 345 || regressAngle == true)
        {
            regressAngle = true;
            if (angle > 368)
            {
                angle = 0;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                swing = false;
            } else
            {
                angle += speedSwing2;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * direction, transform.eulerAngles.z);
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            angle -= speedSwing1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle * direction, transform.eulerAngles.z);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
