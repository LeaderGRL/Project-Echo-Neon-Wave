using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AddScore : MonoBehaviour
{

    private void Start()
    {
        GiveRandomScore();
    }

    // Start is called before the first frame update
    public void GiveRandomScore()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("Music");
        string[] AllPseudo = new string[9] { "Cédric", "Jordan", "Félicien", "François", "Guillaume", "Mathieu", "Valentin", "Henri", "Line" };

        foreach (GameObject music in btn)
        {

            List<Score> AllScore = new List<Score>();
            string Title = music.transform.Find("Title").GetComponent<Text>().text;
            for (int i = 0; i < AllPseudo.Length; i++)
            {
                Score randomscore = new Score(AllPseudo[i], Random.Range(1, 100000));
                AllScore.Add(randomscore);
            }
            foreach(Score score in AllScore)
            {

            }
            Debug.Log(AllScore);

            string json = JsonUtility.ToJson(AllScore);
            Debug.Log(json);

        }

    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }


    public struct Scores
    {
        public List<Score> Allscores;
    }

    public struct Score
    {
        public string Name;
        public int Scoring;

        public Score(string pseudo, int scoring)
        {
            this.Name = pseudo;
            this.Scoring = scoring;
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
