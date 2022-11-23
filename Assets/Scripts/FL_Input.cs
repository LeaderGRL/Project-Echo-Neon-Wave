using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FL_Input : ButtonActivator
{
    public InputAction FLDestroy;
    public Color pressedColor;
    public Color oldColor;
    private void Awake()
    {
        control = new PlayerControl();
    }

    private void OnEnable()
    {
        FLDestroy = control.Player.FLDestroy;
        FLDestroy.Enable();
        FLDestroy.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
            }
            else if (ctx.interaction is HoldInteraction)
            {
                Debug.Log("Hold");
            }
            else if (ctx.interaction is PressInteraction)
            {
                Debug.Log("Press");
            }
            else if (ctx.interaction is SlowTapInteraction)
            {
                Debug.Log("Press");
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
        //FLDestroy.performed += ctx =>
        //{
        //    if (ctx.interaction is TapInteraction)
        //    {
        //        StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
        //    }
        //};
    }

    private void OnDisable()
    {
        FLDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;

        if (note.tag == "FLNote")
        {
            FLDestroy.performed += ctx =>
            {
                if (ctx.interaction is TapInteraction)
                {
                    StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
                    //Destroy(note);
                    destroyNote.destroyNote(note);
                }
            };
        }
        else
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}
