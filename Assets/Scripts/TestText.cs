using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestText : MonoBehaviour
{
    public TextMeshProUGUI temp_text;
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        temp += 0.1f;
        temp_text.text = Convert.ToString(temp) + " °C";
    }
}
