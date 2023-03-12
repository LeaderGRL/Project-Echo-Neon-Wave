using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LaserMagnetism : MonoBehaviour
{
    public Spline spline;
    public Transform cursor;
    public float attractionForce = 10f;

    private void Start()
    {
        spline = GetComponent<SpriteShapeController>().spline;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == cursor.gameObject)
        {
            Vector2 closestPoint = Vector2.zero;
            float closestDistance = float.MaxValue;

            for (int i = 0; i < spline.GetPointCount(); i++)
            {
                Vector2 point = spline.GetPosition(i);
                float distance = Vector2.Distance(point, collision.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = point;
                }
            }
            //{
            //    Vector3 point = spline.points[i].position;
            //    float distance = Vector3.Distance(cursorPos, point);
            //    if (distance < closestDistance)
            //    {
            //        closestDistance = distance;
            //        closestPoint = point;
            //    }
            //}
            
            Vector2 cursorPos = cursor.position;
            //Vector2 closestPoint = spline.GetClosestPointOnSpline(cursorPos);
            Vector2 direction = (closestPoint - cursorPos).normalized;
            cursor.position = Vector2.Lerp(cursorPos, closestPoint, attractionForce * Time.deltaTime);

        }
    }
}