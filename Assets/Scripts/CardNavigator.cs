using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNavigator : MonoBehaviour
{
    public GameObject[] cards;
    public Button buttonLeft;
    public Button buttonRight;

    private int currentIndex = 0;

    void Start()
    {
        ShowCard(currentIndex);
        buttonLeft.onClick.AddListener(PreviousCard);
        buttonRight.onClick.AddListener(NextCard);
    }

    void ShowCard(int index)
    {
        for (int i = 0; i < cards.Length; i++)
            cards[i].SetActive(i == index);
    }

    void NextCard()
    {
        currentIndex = (currentIndex + 1) % cards.Length;
        ShowCard(currentIndex);
    }

    void PreviousCard()
    {
        currentIndex = (currentIndex - 1 + cards.Length) % cards.Length;
        ShowCard(currentIndex);
    }
}
