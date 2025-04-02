using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerInfo : MonoBehaviour
{
    private PlayerMovement player;

    // Temperature
    private float temp;
    public Transform playerTransform;
    public Transform fireTransform;
    public TMP_Text tempText;

    private float minTemp = 20f;
    private float maxTemp = 50f;

    // Score
    private float score = 0f;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update Temperature
        temp = 60.0f - (playerTransform.position.z - fireTransform.position.z) * 10.0f;
        tempText.text = temp.ToString("F1") + "°C";

        // Clamp temperature
        float clampedTemp = Mathf.Clamp(temp, minTemp, maxTemp);
        float t = (clampedTemp - minTemp) / (maxTemp - minTemp);

        // blue → yellow → red
        Color tempColor;
        if (t < 0.5f)
        {
            // Blue to Yellow
            tempColor = Color.Lerp(Color.blue, Color.yellow, t * 2f);
        }
        else
        {
            // Yellow to Red
            tempColor = Color.Lerp(Color.yellow, Color.red, (t - 0.5f) * 2f);
        }

        tempText.color = tempColor;

        // Update Score
        score += player.speed/100;
        scoreText.text = "Score : " + score.ToString("F0");
    }
}
