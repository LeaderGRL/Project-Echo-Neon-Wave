using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
   static AudioSource audioSource;
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

    public bool finMusique()
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

    public static string GetMusiqueName()
    {
        string myString = audioSource.clip.ToString();
        int length = 24;
        int startIndex = myString.Length - length;

        string name = myString.Remove(startIndex, length);

        return name;
    }
}
