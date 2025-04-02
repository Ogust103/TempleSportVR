using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Transform playerTransform; // assigné dans l'inspecteur
    public float knockbackDistance = 1f;

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
            StartCoroutine(KnockBack());

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

        // ----------- FLASH (1 sec total = 0.5 up + 0.5 down) -----------
        float flashTime = 0f;
        while (flashTime < flashDuration / 2)
        {
            flashTime += Time.deltaTime;
            float t = flashTime / (flashDuration / 2);
            float alpha = Mathf.Lerp(0, 0.7f, t);
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        flashTime = 0f;
        while (flashTime < flashDuration / 2)
        {
            flashTime += Time.deltaTime;
            float t = flashTime / (flashDuration / 2);
            float alpha = Mathf.Lerp(0.7f, 0, t);
            damageImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        damageImage.color = originalColor;

        isFlashing = false;
    }

    private IEnumerator KnockBack()
    {
        // ----------- RECUL (3 secondes en ligne droite) -----------
        float knockbackDuration = 0.5f;
        float elapsedKnockback = 0f;

        Vector3 startPosition = playerTransform.position;
        Vector3 targetPosition = startPosition + playerTransform.TransformDirection(Vector3.back.normalized * knockbackDistance);

        while (elapsedKnockback < knockbackDuration)
        {
            elapsedKnockback += Time.deltaTime;
            float t = elapsedKnockback / knockbackDuration;
            playerTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

    }


}
