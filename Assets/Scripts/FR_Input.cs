using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FR_Input : ButtonActivator
{
    public InputAction FRDestroy;
    public Color pressedColor;
    public Color oldColor;
    private void Awake()
    {
        //destroyNote = new DestroyNote();
        control = new PlayerControl();

    }

    private void OnEnable()
    {
        FRDestroy = control.Player.FRDestroy;
        FRDestroy.Enable();
        FRDestroy.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
                Debug.Log("Tap");
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
        //FRDestroy.performed += ctx => StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
    }

    private void OnDisable()
    {
        FRDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;

        if (note.tag == "FRNote")
        {
            FRDestroy.performed += ctx =>
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
