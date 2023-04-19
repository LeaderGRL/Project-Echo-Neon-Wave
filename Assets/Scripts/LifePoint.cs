using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public static int lifePoint;
    public static int damage = 10;
    public static int regeneration = 2;

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Text>().text = "PV : " + lifePoint;
    }

    private void Start()
    {
        lifePoint = 100;
    }

    public static void Damage()
    {
        lifePoint = lifePoint - damage < 0 ? 0 : lifePoint - damage;
    }

    public static void Regeneration()
    {
        lifePoint = lifePoint + regeneration > 100 ? 100 : lifePoint + regeneration;
    }

    public static void SetLifePoint(int life)
    {
        lifePoint = life;
    }
}