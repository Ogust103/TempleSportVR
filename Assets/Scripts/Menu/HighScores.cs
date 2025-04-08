using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public TMP_Text TMPtext;
    // Start is called before the first frame update
    void Start()
    {
        List<float> highscores = PlayerData.highscores;
        string text = "";
        for (int i = 0; i < highscores.Count && i < 10; i++)
        {
            text += (i+1).ToString() + " - " + highscores[i].ToString() + "\n";
        }
        TMPtext.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
