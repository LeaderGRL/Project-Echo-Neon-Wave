using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public bool isWaiting;
    public float startTime;

    public GameObject pauseMenu;
    public GameObject pauseWaitingTime;
    public GameObject[] pauseButtons;
    public GameObject music;

    public float pitchValue;
    public int timeToDecrease = 5;
    public bool isOver = false;
    void Start()
    {
        isPaused = false;
        isWaiting = false;
        pitchValue = 1.0f;
        music.GetComponent<AudioSource>().pitch = pitchValue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //SetPause();
            isOver = true;
        }

        if (isOver)
        {
            GameOver();
        }
        
        if (isPaused && isWaiting)
        {
            WaitingTime();
        }
    }

    void GameOver()
    {
        pitchValue -= 0.001f;
        music.GetComponent<AudioSource>().pitch = pitchValue;
    }
    void WaitingTime()
    {
        if (Time.realtimeSinceStartup - startTime < 3)
        {
            pauseWaitingTime.GetComponentInChildren<Text>().text = 
                (3 - (int) (Time.realtimeSinceStartup - startTime)).ToString();
        } else
        {
            music.GetComponent<AudioSource>().Play();
            pauseWaitingTime.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            isWaiting = false;
        }
    }

    public void SetPause()
    {
        if (!isPaused)
        {
            music.GetComponent<AudioSource>().Pause();
            pauseMenu.SetActive(true);
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(pauseButtons[0]);
            Time.timeScale = 0;
            isPaused = true;
        } else
        {
            pauseMenu.SetActive(false);
            pauseWaitingTime.SetActive(true);
            startTime = Time.realtimeSinceStartup;
            isWaiting = true;
        }

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
