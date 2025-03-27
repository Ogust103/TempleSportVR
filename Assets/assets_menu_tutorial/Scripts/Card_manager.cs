using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject[] movementCards; // Liste des cartes de mouvement
    private int currentCardIndex = 0;  // Index de la carte actuelle

    public Button nextButton1;  // Bouton "Next" de la premi�re carte
    public Button nextButton2;  // Bouton "Next" de la deuxi�me carte
    public Button prevButton;   // Bouton "Previous"

    void Start()
    {
        UpdateCardVisibility();

        // Ajouter des listeners aux boutons
        nextButton1.onClick.AddListener(ShowNextCard);
        nextButton2.onClick.AddListener(ShowNextCard);
        prevButton.onClick.AddListener(ShowPreviousCard);
    }

    // Afficher la carte suivante
    public void ShowNextCard()
    {
        movementCards[currentCardIndex].SetActive(false);
        currentCardIndex = (currentCardIndex + 1) % movementCards.Length;
        UpdateCardVisibility();
    }

    // Afficher la carte pr�c�dente
    public void ShowPreviousCard()
    {
        movementCards[currentCardIndex].SetActive(false);
        currentCardIndex = (currentCardIndex - 1 + movementCards.Length) % movementCards.Length;
        UpdateCardVisibility();
    }

    // Met � jour l'affichage des cartes et la visibilit� des boutons
    private void UpdateCardVisibility()
    {
        for (int i = 0; i < movementCards.Length; i++)
        {
            movementCards[i].SetActive(i == currentCardIndex);
        }

        // Afficher les boutons appropri�s selon l'index de la carte actuelle
        nextButton1.gameObject.SetActive(currentCardIndex == 0);
        nextButton2.gameObject.SetActive(currentCardIndex == 1);
        prevButton.gameObject.SetActive(currentCardIndex > 0);
    }
}
