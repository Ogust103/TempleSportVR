using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PlayerData
{
    public static float height = 1.7f; // stocke la taille choisie
    public static List<float> highscores = new List<float>();

    private static string filePath => Application.persistentDataPath + "/highscores.json";

    [System.Serializable]
    private class HighscoreData
    {
        public List<float> scores = new List<float>();
    }

    public static void AddHighscore(float score)
    {
        LoadHighscores(); // Assure-toi de charger les scores avant d’en ajouter
        highscores.Add(score);
        highscores.Sort((a, b) => b.CompareTo(a)); // Tri décroissant
        SaveHighscores();
    }

    public static List<float> GetHighscores()
    {
        LoadHighscores();
        return highscores;
    }

    private static void SaveHighscores()
    {
        HighscoreData data = new HighscoreData { scores = highscores };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    private static void LoadHighscores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighscoreData data = JsonUtility.FromJson<HighscoreData>(json);
            highscores = data.scores ?? new List<float>();
        }
        else
        {
            highscores = new List<float>();
        }
    }
}
