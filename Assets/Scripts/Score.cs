using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int affichageCombo = 1;
    public static int nbCombo = 1;
    public static bool comboActive = false;
    public static int initCombo = 0;

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Text>().text = PlayerPrefs.GetInt(namee) + "";
        GetComponent<Text>().text = "Score : " + score;
        if (initCombo != 1 && initCombo != 0)
        {
            GetComponent<Text>().text = "Score : " + score + "\n" + "Combo : X " + affichageCombo;
        }
    }


    public void Incombo(int combo)
    {

        initCombo += combo;
        if (initCombo == 1)
        {
            score += 10;
            nbCombo = 1;

        }
        else
        {
            nbCombo += combo;

            if (nbCombo <= 8)
            {
                affichageCombo = nbCombo;
                score = score + 10 * nbCombo;
            }
            else
            {
                nbCombo = 8;
                affichageCombo = nbCombo;
                score = score + 10 * nbCombo;
            }
        }

    }

    public void BreakCombo(int combo)
    {
        initCombo = combo;
        nbCombo = 1;
    }

    public static int getScore()
    {
        return score;
    }

}

