using UnityEngine;

public class BreakCombo : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject note = col.gameObject;

        if (note.CompareTag("RNote") || note.CompareTag("FRNote") || note.CompareTag("LNote") || note.CompareTag("FLNote"))
        {
            Score.BreakCombo();
            LifePoint.Damage();
            Destroy(note);
        }

    }
}