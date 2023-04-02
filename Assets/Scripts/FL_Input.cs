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
    public Movement_Input input;
    public GameObject impact;
    private float remainingTime = 0f;
    private bool disable;
    private GameObject collidNote;
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
                StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor,input.FL));
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

    public void buttonPressed()
    {

        if (input.FL == 0)
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b);


        if (input.FL == 1 && remainingTime < 5f && disable == false)
        {
            StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor, input.FL));
            remainingTime += 1;
            destroyNote.destroyNote(collidNote, impact);
            collidNote = null;

        }
        else
        {
            remainingTime = 0;
            disable = true;
            if (disable && input.FL == 0)
            {
                disable = false;
            }
        }


    }

    private void OnDisable()
    {
        FLDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;
        collidNote = note;

        if (note.tag == "FLNote")
        {
            FLDestroy.performed += ctx =>
            {
                if (ctx.interaction is TapInteraction)
                {
                    StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor, input.FL));
                    //Destroy(note);
                    destroyNote.destroyNote(note, impact);
                }
            };

        }
        else
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }

        
    }
}
