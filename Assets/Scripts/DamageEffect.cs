using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image damageImage; // Assignez l'image rouge ici dans l'�diteur
    public float flashDuration = 0.5f; // Dur�e du flash

    private Color originalColor; // Couleur d'origine
    private bool isFlashing;

    void Start()
    {
        // Stockez la couleur d'origine (avec alpha � 0 pour transparence totale)
        originalColor = damageImage.color;
        originalColor.a = 0;
        damageImage.color = originalColor;
    }

    void Update()
    {
        // V�rifiez si la touche Espace est press�e
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDamageEffect();
        }
    }

    public void TriggerDamageEffect()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashEffect());
        }
    }

    private IEnumerator FlashEffect()
    {
        isFlashing = true;
        float elapsedTime = 0f;

        // Augmenter l'opacit�
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / (flashDuration / 2));
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // R�duire l'opacit�
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / (flashDuration / 2));
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        damageImage.color = originalColor;
        isFlashing = false;
    }
}
