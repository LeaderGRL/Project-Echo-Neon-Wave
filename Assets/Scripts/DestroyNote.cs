using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    GameObject note;
    private Score score = new Score();

    private void Awake()
    {
        //score = new Score();
    }
    //private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator destroyInput(GameObject activator, Color pressedColor, Color oldColor)
    {
        activator.GetComponent<SpriteRenderer>().color = new Color(pressedColor.r, pressedColor.g, pressedColor.b);

        yield return new WaitForSeconds(0.1f);
        activator.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b);
    }

    public void destroyNote(GameObject note)
    {
        if (note != null)
        {
            score.Incombo(1);
            Debug.Log("break combo");
        }
        
        Destroy(note);
        score.BreakCombo(1);
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Note")
    //    {
    //        Debug.Log("Note entered");
    //        note = col.gameObject;
    //        if(active == true)
    //        {
    //            destroyNote(note);
    //            active = false;
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log(active);
    }
        //void changeColorInChild()
        //{
        //    SpriteRenderer[] children;
        //    children = GameObject.Find("Activator").GetComponentsInChildren<SpriteRenderer>();
        //    foreach (SpriteRenderer child in children)
        //    {
        //        child.color = old;
        //    }

    //}
}
