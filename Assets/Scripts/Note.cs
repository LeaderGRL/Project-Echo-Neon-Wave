using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private static Note noteInstance;
    Rigidbody rb;
    Rigidbody2D rb2d;
    Rigidbody velocityRb;
    GameObject velocityObj;
    Rigidbody test;
    GameObject testObj;
    public float speed;

    private void Awake()
    {
        /*testObj = new GameObject();
        testObj.AddComponent<Rigidbody>();
        test = testObj.GetComponent<Rigidbody>();
        test.useGravity = false;
        test.velocity = new Vector3(0, -speed, -speed);*/
        //test.velocity = new Vector3(0, -speed, -speed);*/
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, -speed, 0);
        }
        else
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector3(0, -speed, 0);
        }

        /*if (!GameObject.Find("Beatmap").GetComponent<Rigidbody>())
        {
            velocityObj = GameObject.Find("Beatmap");
            velocityObj.AddComponent<Rigidbody>();
            velocityRb = velocityObj.GetComponent<Rigidbody>();
            velocityRb.useGravity = false;
            velocityRb.velocity = new Vector3(0, -speed, -speed);
        }*/
    }

    // Update is called once per frame
    /* void Update()
     {
         if (GetComponent<Rigidbody2D>())
         {
             GameObject obj = GetComponent<Rigidbody2D>().gameObject;
             Debug.Log(GameObject.Find("Beatmap").GetComponent<Rigidbody>().velocity);
             obj.transform.position -= GameObject.Find("Beatmap").GetComponent<Rigidbody>().velocity;

         }
     } */




}
