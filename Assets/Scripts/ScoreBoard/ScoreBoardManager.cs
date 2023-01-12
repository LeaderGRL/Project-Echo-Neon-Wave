using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
    public GameObject rowPrefab;
    private string save = "";
    public Transform rowsParent;
    private DataArray dataArray;


     void Awake()
    {
        string path = Directory.GetCurrentDirectory() +"/Assets/database/database.json";

        dataArray = new DataBase().JsonReader(path);
    }
     
    private void Update()
    {
        GameObject thePlayer = GameObject.Find("Pivot");
        RotateMenu playerScript = thePlayer.GetComponent<RotateMenu>();
        string title = playerScript.SelectedMusic.transform.Find("Title").GetComponent<Text>().text;
        if (title != save)
        {
            GetScoreBoard(title);
        }

        save = title;
    }

    public void GetScoreBoard(string music)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        
      
       foreach (MusicObject musicObject in dataArray.Data)
        {
            if (musicObject.Name == music)
            {
                int i = 1;
                Array.Sort(musicObject.Players, new Comparer());
                foreach (Player player in musicObject.Players)
                {
                    rowPrefab.transform.Find("Name").GetComponent<Text>().text = player.Pseudo;
                    rowPrefab.transform.Find("Score").GetComponent<Text>().text = player.Score.ToString();
                    rowPrefab.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
                    Instantiate(rowPrefab, rowsParent);
                    if (i == 5)
                    {
                        break;
                    }
                    i++;
                    
                }

            }
        }
    }
}
