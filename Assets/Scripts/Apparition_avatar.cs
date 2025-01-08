using UnityEngine;

public class AvatarSquatController : MonoBehaviour
{
    public GameObject avatar; // L'avatar à afficher/masquer.
    public Animator avatarAnimator; // Le contrôleur Animator de l'avatar.
    public Transform obstacleSquat; // Le GameObject représentant l'obstacle.
    public Camera mainCamera; // La caméra principale.
    public float distanceThreshold = 20f; // Distance en Z pour déclencher l'animation.

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
            Debug.LogError("Veuillez assigner la caméra principale au script.");
            return;
        }

        // Masquer l'avatar au démarrage.
        avatar.SetActive(false);
    }

    void Update()
    {
        // Vérifier si l'obstacle existe toujours avant de calculer la distance.
        if (obstacleSquat != null)
        {
            float distanceZ = obstacleSquat.position.z - mainCamera.transform.position.z;

            if (distanceZ >= -2 && distanceZ < distanceThreshold)
            {
                // Si la distance est valide, activer l'avatar et démarrer l'animation.
                avatar.SetActive(true);
                avatarAnimator.SetBool("IsSquatting", true);
            }
            else
            {
                // Si la distance est négative ou trop grande, désactiver l'avatar.
                EndSquatSequence();
            }
        }
        else
        {
            // Si l'obstacle a été détruit, désactiver l'avatar.
            EndSquatSequence();
        }
    }

    void EndSquatSequence()
    {
        // Réinitialiser l'état de l'avatar.
        avatarAnimator.SetBool("IsSquatting", false);
        avatar.SetActive(false);
    }
}
