using UnityEngine;

public class AvatarSquatController : MonoBehaviour
{
    public GameObject avatar; // L'avatar � afficher/masquer.
    public Animator avatarAnimator; // Le contr�leur Animator de l'avatar.
    public Transform obstacleSquat; // Le GameObject repr�sentant l'obstacle.
    public Camera mainCamera; // La cam�ra principale.
    public float distanceThreshold = 20f; // Distance en Z pour d�clencher l'animation.

    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("Veuillez assigner l'avatar au script.");
            return;
        }

        if (avatarAnimator == null)
        {
            Debug.LogError("Veuillez assigner l'Animator de l'avatar au script.");
            return;
        }

        if (mainCamera == null)
        {
            Debug.LogError("Veuillez assigner la cam�ra principale au script.");
            return;
        }

        // Masquer l'avatar au d�marrage.
        avatar.SetActive(false);
    }

    void Update()
    {
        // V�rifier si l'obstacle existe toujours avant de calculer la distance.
        if (obstacleSquat != null)
        {
            float distanceZ = obstacleSquat.position.z - mainCamera.transform.position.z;

            if (distanceZ >= -2 && distanceZ < distanceThreshold)
            {
                // Si la distance est valide, activer l'avatar et d�marrer l'animation.
                avatar.SetActive(true);
                avatarAnimator.SetBool("IsSquatting", true);
            }
            else
            {
                // Si la distance est n�gative ou trop grande, d�sactiver l'avatar.
                EndSquatSequence();
            }
        }
        else
        {
            // Si l'obstacle a �t� d�truit, d�sactiver l'avatar.
            EndSquatSequence();
        }
    }

    void EndSquatSequence()
    {
        // R�initialiser l'�tat de l'avatar.
        avatarAnimator.SetBool("IsSquatting", false);
        avatar.SetActive(false);
    }
}
