using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeightSelector : MonoBehaviour
{
    public Slider heightSlider;
    public TMP_Text heightText;

    void Start()
    {
        heightSlider.onValueChanged.AddListener(UpdateHeightText);
        UpdateHeightText(heightSlider.value); // init affichage
    }

    void UpdateHeightText(float value)
    {
        heightText.text = value.ToString();
    }
}
