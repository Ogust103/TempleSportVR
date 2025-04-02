using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class PlayerInfo : MonoBehaviour
{
    private float temp;
    public Transform playerTransform;
    public Transform fireTransform;
    public TMP_Text tempText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp = 60.0f - (playerTransform.position.z - fireTransform.position.z) * 10.0f;
        tempText.text = temp.ToString("F1") + "°C";

    }
}
