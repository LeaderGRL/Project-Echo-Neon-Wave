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
    public Movement_Input input;
    public GameObject impact;
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
        FRDestroy = control.Player.FRDestroy;
        FRDestroy.Enable();
        FRDestroy.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor, input.FR));
                Debug.Log("Tap");
            }
        };

      
    }
    
    public void ButtonPressed()
    {
       if(input.FR==0)
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b);
        

        if (input.FR == 1 && remainingTime < 5f && disable == false)
        {
            StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor, input.FR));
            remainingTime += 1;
            destroyNote.destroyNote(collidNote, impact);
            collidNote = null;
            
        }
        else
        {
            remainingTime = 0;
            disable = true;
            if (disable && input.FR == 0)
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
        //FRDestroy.performed += ctx => StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor));
    }

    private void OnDisable()
    {
        FRDestroy.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note = collision.gameObject;
        collidNote = note;
        if (note.tag == "FRNote")
        {
            FRDestroy.performed += ctx =>
            {
                if (ctx.interaction is TapInteraction)
                {
                    StartCoroutine(destroyNote.destroyInput(this.gameObject, pressedColor, oldColor,input.FR));
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
