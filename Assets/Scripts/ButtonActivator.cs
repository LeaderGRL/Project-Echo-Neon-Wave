using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonActivator : MonoBehaviour
{
    public bool active = false;
    public PlayerControl control;
    public GameObject note;
    protected Score score;
    protected DestroyNote destroyNote = new DestroyNote();
    private LifePoint lifePoint;
    private string tag;

    private void Awake()
    {
        //destroyNote = new DestroyNote();
        control = new PlayerControl();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(FLDestroy.triggered == true)
        //{
        //    activator = GameObject.Find("FL Activator");
        //    Debug.Log(activator.name);
        //    //FLdestroy();
        //}
        //else if (LDestroy.triggered == true)
        //{
        //    activator = GameObject.Find("L Activator");
        //    Debug.Log(activator.name);
        //    //Ldestroy();
        //}
        //else if (RDestroy.triggered == true)
        //{
        //    activator = GameObject.Find("R Activator");
        //    Debug.Log(activator.name);
        //    Rdestroy();
        //}
        //else if (FRDestroy.triggered == true)
        //{
        //    activator = GameObject.Find("FR Activator");
        //    Debug.Log(activator.name);
        //    FRdestroy();
        //}
        //if (input.getkeydown(key))
        //{
        //    /*debug.log("j'appuie !");
        //    startcoroutine(onkeypressed());*/
        //}

        //if (input.getkey(key))
        //{
        //    if (tag == "longnote")
        //    {
        //        debug.log("je reste appuyer ?");
        //    }
        //    sr.color = new color(pressedcolor.r, pressedcolor.g, pressedcolor.b);
        //    //startcoroutine(onkeypressed());
        //}
        //else
        //{
        //    sr.color = old;
        //}

        //if (input.getkeydown(key) && active)
        //{
        //    destroy(note);
        //    score.incombo(1);
        //    lifepoint.regeneration();
        //    active = false;
        //}

        //if (input.getkey(key) && active)
        //{
        //    //destroy(note);
        //    score.incombo(1);
        //    active = false;
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    active = true;
    //    if (collision.gameObject.tag == "Note")
    //    {
    //        //Debug.Log("Note detected !");
    //        note = collision.gameObject;
    //        tag = "Note";
    //    }
    //    else if (collision.gameObject.tag == "longNote")
    //    {
    //        note = collision.gameObject;
    //        tag = "longNote";
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        note = null;
    }

    //IEnumerator OnDestroy()
    //{
    //    changeColorInChild();
    //    activator.GetComponent<SpriteRenderer>().color = new Color(pressedColor.r, pressedColor.g, pressedColor.b);
    //    //sr.color = new Color(pressedColor.r, pressedColor.g, pressedColor.b);
    //    yield return new WaitForSeconds(0.1f);
    //    activator.GetComponent<SpriteRenderer>().color = old;
    //}

    //void changeColorInChild()
    //{
    //    SpriteRenderer[] children ;
    //    children = GameObject.Find("Activator").GetComponentsInChildren<SpriteRenderer>();
    //    foreach (SpriteRenderer child in children)
    //    {
    //        child.color = old;
    //    }

    //}

    private void onMovement(InputAction.CallbackContext context)
    {
        //movement = context.readvalue<vector2>();
        Debug.Log("movement");
    }

    //private void FixedUpdate()
    //{
    //    if (rMovement.ReadValue<float>() == 1)
    //    {
    //        laser.turnRight(GameObject.Find("RightLaserEye"));
    //    }
    //    else if (rMovement.ReadValue<float>() == -1)
    //    {
    //        laser.turnLeft(GameObject.Find("RightLaserEye"));
    //    }

    //    if (lMovement.ReadValue<float>() == -1)
    //    {
    //        laser.turnLeft(GameObject.Find("LeftLaserEye"));
    //    }
    //    else if (lMovement.ReadValue<float>() == 1)
    //    {
    //        laser.turnRight(GameObject.Find("LeftLaserEye"));
    //    }
    //}

    //    private void FLdestroy(InputAction.CallbackContext context)
    //    {
    //        Debug.Log("FL DESTROY CALLBACK"); 
    //        StartCoroutine(OnDestroy());
    //    }

    //    private void Ldestroy(InputAction.CallbackContext context)
    //    {
    //        Debug.Log("L DESTROY");
    //        StartCoroutine(OnDestroy());
    //    }

    //    private void Rdestroy()
    //    {
    //        Debug.Log("R DESTROY");
    //        StartCoroutine(OnDestroy());

    //    }
    //    private void FRdestroy()
    //    {
    //        Debug.Log("FR DESTROY");
    //        StartCoroutine(OnDestroy());
    //    }

}
