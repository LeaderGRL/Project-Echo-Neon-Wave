using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    public static float timeMusique;
    public static float lengthMusique;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lengthMusique = audioSource.clip.length;
    }

    void Update()
    {
        timeMusique = audioSource.time;

    }

    public static bool  finMusique()
    {
        if (lengthMusique == timeMusique)
        {
            //Player.OnGUI(true);
            Time.timeScale = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
