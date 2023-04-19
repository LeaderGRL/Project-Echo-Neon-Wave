using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    public GameObject gameOver;
    public GameObject music;
    public GameObject[] gameOverButtons;
    public bool gameIsOver;
    private bool endGame = false;
    private string pseudonyme;
    private DataBase dataBase = new DataBase();
    private bool AlreadyRegistered;

    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LifePoint.lifePoint <= 0 && !gameIsOver)
        {
            ShowGameOver();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            VictoryEnd();
        }
    }

    private void VictoryEnd()
    {
        int score = Score.getScore();
        endScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ShowGameOver()
    {
        music.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0;
        gameIsOver = true;
        gameOver.SetActive(true);
        // EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(gameOverButtons[0]);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Score.SetScore(0);
        Score.BreakCombo();
        LifePoint.SetLifePoint(100);

    }
    public void Quit()
    {
        //Reload la scene du menu
    }

    public void ReadStringInput(string s)
    {
        if (!AlreadyRegistered)
        {
            dataBase.JsonWritter(s);
            return;
        }
    }

}