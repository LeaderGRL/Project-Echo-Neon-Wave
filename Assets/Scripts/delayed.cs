using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayed : MonoBehaviour
{
    public AudioSource audio;
    public GameObject countDown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        audio.mute = false;
        audio.Play();
        
        Time.timeScale = 1;
        countDown.SetActive(false);
    }
}
