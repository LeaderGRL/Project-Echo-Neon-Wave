using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class R_Input : ButtonActivator
{
    public InputAction RDestroy;
    public Color pressedColor;
    public Color oldColor;
    private void Awake()
    {
        note = new GameObject();
        //destroyNote = new DestroyNote();
        control = new PlayerControl();

    }

    private void OnEnable()
    {
        RDestroy = control.Player.RDestroy;
        RDestroy.Enable();
        RDestroy.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
            }
        };
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RDestroy.performed += ctx => StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
    }

    private void OnDisable()
    {
        RDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;
        
        if (note.tag == "RNote")
        {
            RDestroy.performed += ctx =>
            {
                if (ctx.interaction is TapInteraction)
                {
                    StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
                    //Destroy(note);
                    destroyNote.destroyNote(note);
                    Debug.Log(note);
                }
            };
        }
        else
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "RNote")
    //    {
    //        Debug.Log("RNote exited");
    //        note = null;
    //    }
    //}
}
