using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public CardManager cardManager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(cardManager.ShowNextCard);
    }
}