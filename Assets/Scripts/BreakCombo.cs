using UnityEngine;

public class BreakCombo : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject note = col.gameObject;
    
        if (note.tag == "RNote"|| note.tag == "FRNote" || note.tag == "LNote" || note.tag == "FLNote")
        {
            Score.BreakCombo();
            LifePoint.Damage();
            Destroy(note);
        }

    }
}
