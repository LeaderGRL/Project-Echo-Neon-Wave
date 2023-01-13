using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Debug = UnityEngine.Debug;

public class DataBase : MonoBehaviour
{
    private MusicObject finalMusicObject;

    private bool Existing(string filePath)
    {
        // Check if the file exists
        return File.Exists(filePath);
    }

    private MusicObject CreateMusic()
    {
        MusicObject musicObject = new MusicObject();
        musicObject.Name = Audio.GetMusiqueName();
        return musicObject;
    }

    private void SetPlayer(string pseudo)
    {
        Array.Resize(ref finalMusicObject.Players, finalMusicObject.Players.Length + 1);
        finalMusicObject.Players[finalMusicObject.Players.Length - 1] = new Player()
        {
            Pseudo = pseudo,
            Score = Score.getScore()
        };
    }

    public DataArray JsonReader(string path)
    {

        if (!Existing(path))
        {
            File.Create(path);
        }

        string jsonString = File.ReadAllText(path);
        DataArray dataArray = JsonConvert.DeserializeObject<DataArray>(jsonString);
        return dataArray;

    }
    public void JsonWritter(string pseudo)
    {
        string path = Directory.GetCurrentDirectory() + "/Assets/database/database.json";
        DataArray dataArray = JsonReader(path);
        bool found = false;
        int index = -1;
        foreach (MusicObject musicObject in dataArray.Data)
        {
            index++;
            Debug.Log(musicObject);
            if (musicObject.Name == Audio.GetMusiqueName())
            {
                found = true;
            }
        }

        if (!found)
        {
            finalMusicObject = CreateMusic();
            finalMusicObject.Players = new Player[] { };
            SetPlayer(pseudo);
            Array.Resize(ref dataArray.Data, dataArray.Data.Length + 1);
            dataArray.Data[dataArray.Data.Length - 1] = finalMusicObject;
        }
        else
        {
            finalMusicObject = dataArray.Data[index];
            int indexPlayer = -1;
            int i = 0;
            foreach (Player player in finalMusicObject.Players)
            {
                if (player.Pseudo == pseudo)
                {
                    indexPlayer = i;
                    break;
                }
                i++;
            }

            if (indexPlayer == -1)
            {
                SetPlayer(pseudo);
            }
            else
            {
                if (Score.getScore() > finalMusicObject.Players[indexPlayer].Score)
                {
                    finalMusicObject.Players[indexPlayer].Score = Score.getScore();
                }
            }

            dataArray.Data[index] = finalMusicObject;
        }

        string jsonObject = JsonConvert.SerializeObject(dataArray);
        File.WriteAllText(path, jsonObject);
    }
}

public struct MusicObject
{
    public string Name;
    public Player[] Players;
}

public struct DataArray
{
    public MusicObject[] Data;
}

public struct Player
{
    public string Pseudo;
    public int Score;
}