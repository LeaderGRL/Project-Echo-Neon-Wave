using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject music;
    public GameObject[] gameOverButtons;
    public bool gameIsOver;
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
            //ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        music.GetComponent<AudioSource>().Pause();
        gameOver.SetActive(true);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(gameOverButtons[0]);
        Time.timeScale = 0;
        gameIsOver = true;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        //Reload la scene du menu
    }

}
