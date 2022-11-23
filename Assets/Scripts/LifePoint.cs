using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public static int lifePoint;
    public static int damage = 10;
    public static int regeneration = 1;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "PV : " + lifePoint;
    }

    void Start()
    {
        lifePoint = 100;
    }

    public static void Damage()
    {
        lifePoint = lifePoint - damage < 0 ? 0 : lifePoint - damage;
    }

    public void Regeneration()
    {
        lifePoint = lifePoint + regeneration > 100 ? 100 : lifePoint + regeneration;
    }
}
