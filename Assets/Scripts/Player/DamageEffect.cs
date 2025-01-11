using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image damageImage; // Red Image
    public float flashDuration = 0.5f; // Flash duration
    public AudioClip damageSound;

    private AudioSource audioSource;
    private Color originalColor; // Original color
    private bool isFlashing;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Get the original color (alpha = 0 for total transparency)
        originalColor = damageImage.color;
        originalColor.a = 0;
        damageImage.color = originalColor;
    }

    public void TriggerDamageEffect()
    {
        if (!isFlashing)
        {
            //Play animation
            StartCoroutine(FlashEffect());

            //Play sound
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
                Debug.Log("Test");
            }
        }
    }

    private IEnumerator FlashEffect()
    {
        isFlashing = true;
        float elapsedTime = 0f;

        // Increase opacity
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 0.7f, elapsedTime / (flashDuration / 2));
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // Reduce opacity
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0.7f, 0, elapsedTime / (flashDuration / 2));
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        damageImage.color = originalColor;
        isFlashing = false;
    }
}
