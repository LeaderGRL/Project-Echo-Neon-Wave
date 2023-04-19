using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class L_Input : ButtonActivator
{

    public InputAction LDestroy;
    public Color pressedColor;
    public Color oldColor;    
    private void Awake()
    {
        //destroyNote = new DestroyNote();
        control = new PlayerControl();

    }

    private void OnEnable()
    {
        LDestroy = control.Player.LDestroy;
        LDestroy.Enable();
        LDestroy.performed += ctx => {
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
        //LDestroy.performed += ctx => StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
    }

    private void OnDisable()
    {
        LDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;

        if (note.tag == "LNote")
        {
            LDestroy.performed += ctx =>
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
