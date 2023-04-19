using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int highScore;
    [SerializeField]
    private int secondScore;
    [SerializeField]
    private int thirdScore;
    [SerializeField]
    private string playerHighScore;
    [SerializeField]
    private string playerSecondScore;
    [SerializeField]
    private string playerThirdScore;
    private bool endGame = false;




    void Start()
    {

        SetText();
    }
    void Update()
    {
        score = Score.getScore();
        if(Audio.finMusique() == true)
        {
            endGame = true;
        }

       /* if (Input.GetKeyDown(KeyCode.E))
        {
            supprimerClassement();
                }*/
    }


    void affichageClassement()
    {
        if (score > highScore)
        {
            //record battu met à jour nouveau joueur
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetString("HighPlayer", playerName);
            //met a jour ancien joueur
            PlayerPrefs.SetInt("SecondScore", highScore);
            PlayerPrefs.SetString("SecondPlayer", playerHighScore);
            PlayerPrefs.SetInt("ThirdScore", secondScore);
            PlayerPrefs.SetString("ThirdPlayer", playerSecondScore);
            Debug.Log("Record battu ! ancien 1er passe second & ancien 2eme passe 3eme");

        }
        else
        {
            if (score > secondScore)
            {
                //met a jour nouveau joueur
                PlayerPrefs.SetInt("SecondScore", score);
                PlayerPrefs.SetString("SecondPlayer", playerName);
                Debug.Log("SecondScore battu");
                //met a jour ancien joueur
                PlayerPrefs.SetInt("ThirdScore", secondScore);
                PlayerPrefs.SetString("ThirdPlayer", playerSecondScore);
                Debug.Log("ancien 2eme passe 3eme");
            }
            else
            {
                if (score > thirdScore)
                {
                    PlayerPrefs.SetInt("ThirdScore", score);
                    PlayerPrefs.SetString("ThirdPlayer", playerName);
                    Debug.Log("Nouveau 3eme");
                }
            }
        }
    }



    void supprimerClassement()
    {

        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("SecondScore");
        PlayerPrefs.DeleteKey("ThirdScore");
        Debug.Log("Scores supprimé");
        PlayerPrefs.DeleteKey("HighPlayer");
        PlayerPrefs.DeleteKey("SecondPlayer");
        PlayerPrefs.DeleteKey("ThirdPlayer");
        Debug.Log("Player supprimé");

    }

    void SetText()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            playerHighScore = PlayerPrefs.GetString("HighPlayer");
            Debug.Log("HighScore chargé avec succès");
        }

        if (PlayerPrefs.HasKey("SecondScore"))
        {
            secondScore = PlayerPrefs.GetInt("SecondScore");
            playerSecondScore = PlayerPrefs.GetString("SecondPlayer");
            Debug.Log("SecondScore chargé avec succès");
        }
        if (PlayerPrefs.HasKey("ThirdScore"))
        {
            thirdScore = PlayerPrefs.GetInt("ThirdScore");
            playerThirdScore = PlayerPrefs.GetString("ThirdPlayer");
            Debug.Log("ThirdScore chargé avec succès");
        }
    }

    void OnGUI()
    {
        //// Crée un champ de texte dans lequel l'utilisateur entre son nom
        if (endGame == true)
        {
            playerName = GUI.TextField(new Rect(250, 200, 200, 20), playerName, 25);

            while (playerName != "")
                {
                affichageClassement();
            }
        }

        // Récupère les paramètres PlayerPrefs et les affiche à l'écran en utilisant les Labels
        if (!string.IsNullOrEmpty(playerHighScore))
        {
            GUI.Label(new Rect(580, 50, 300, 100), "1. " + playerHighScore + " - " + highScore);
        }

        if (!string.IsNullOrEmpty(playerSecondScore))
        {
            GUI.Label(new Rect(580, 70, 300, 100), "2. " + playerSecondScore + " - " + secondScore);
        }

        if (!string.IsNullOrEmpty(playerThirdScore))
        {
            GUI.Label(new Rect(580, 90, 300, 100), "3. " + playerThirdScore + " - " + thirdScore);
        }
    }






}

