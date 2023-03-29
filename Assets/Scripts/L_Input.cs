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
    public Movement_Input input;
    private float remainingTime = 0f;
    private bool disable;
    private GameObject collidNote;
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
                //StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
            }
        };
    }

    public void ButtonPressed()
    {
        if (input.L == 0)
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b);


        if (input.L == 1 && remainingTime < 5f && disable == false)
        {
            StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor, input.L));
            remainingTime += 1;
            destroyNote.destroyNote(collidNote);
            collidNote = null;

        }
        else
        {
            remainingTime = 0;
            disable = true;
            if (disable && input.L == 0)
            {
                disable = false;
            }
        }
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
        collidNote = note;
        if (note.tag == "LNote")
        {
            LDestroy.performed += ctx =>
            {
                if (ctx.interaction is TapInteraction)
                {
                  //  StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
                    //Destroy(note);
                    destroyNote.destroyNote(note);
                }
            };

            if (input.L == 1)
            {
              //  StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
            }
        }
        else
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}
