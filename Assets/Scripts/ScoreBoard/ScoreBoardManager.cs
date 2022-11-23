using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
    public GameObject rowPrefab;
    private string save = "";
    public Transform rowsParent;

    private void Start()
    {
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
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        var reader = new StreamReader(File.OpenRead(@".\Assets\Audio\" + music + "\\Highscore.csv"));
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        List<Score> AllScore = new List<Score>();
        while (!reader.EndOfStream)
        {
        var line = reader.ReadLine();
        var values = line.Split(';');
        listA.Add(values[0]);
        listB.Add(values[1]);
        }
        for(int i = 0; i < 5; i++)
        {
            Score score = new Score();
            score.Name = listA[i];
            score.Scoring = Int32.Parse(listB[i]);
            AllScore.Add(score);
        }
        AllScore.Sort((x, y) => x.Scoring.CompareTo(y.Scoring));
        AllScore.Reverse();
        int position = 1;
        foreach (Score score in AllScore)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = position.ToString();
            texts[1].text = score.Name;
            texts[2].text = score.Scoring.ToString();
            position++;
        }
    }

    void OnScoreboardGet()
    {

    }


    public struct Scores
    {
        public List<Score> Allscores;
    }

    public struct Score
    {
        public string Name;
        public int Scoring;

        public Score(string pseudo, int scoring,int rank)
        {
            this.Name = pseudo;
            this.Scoring = scoring;
        }
    }

}
