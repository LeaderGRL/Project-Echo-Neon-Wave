using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int nbCombo = 1;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(getScore());
        Debug.Log(nbCombo);
        
        GetComponent<Text>().text = "Score : " + score + "\n" + "X" + nbCombo;
    }


    public void Incombo()
    {
        if (nbCombo < 8)
        {
            nbCombo += 1;
            score += 10 * nbCombo;
        }
        else
        {
            nbCombo = 8;
            score += 10 * nbCombo;
        }
    }

    public static void BreakCombo()
    {
        nbCombo = 1;
    }

    public static int getScore()
    {
        return score;
    }

    public static void SetScore(int point)
    {
        score = point;
    }

}