using UnityEngine;
using UnityEngine.U2D;

public class Rmagnet : MonoBehaviour
{
    private Vector3 cursorPos;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "RL")
        {
            Spline spline = col.GetComponent<SpriteShapeController>().spline;
            Vector2 point = FoundPoint(spline);
            Vector2 colliderPoint = gameObject.GetComponent<BoxCollider2D>().ClosestPoint(new Vector2(0, 1));
            cursorPos = colliderPoint;
            gameObject.transform.position =
                Vector2.Lerp(gameObject.transform.position, new Vector2(point.x, 0), 2f * Time.deltaTime);
        }
    }
    // void OnTriggerExit2D(Collider2D col){
    //    if (col.tag == "LL")
    //    {
    //       gameObject.transform.position = gameObject.transform.position;
    //
    //    }
    // }

    private Vector3 FoundPoint(Spline spline)
    {
        Vector3 closestPoint = Vector3.zero;
        float closestDistance = float.MaxValue;
        for (int i = 0; i < spline.GetPointCount(); i++)
        {
            Vector3 point = spline.GetPosition(i);
         
            float distance = Vector3.Distance(cursorPos, point);
            Debug.Log(distance);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point;
            }
        }

        return closestPoint;
    }
}