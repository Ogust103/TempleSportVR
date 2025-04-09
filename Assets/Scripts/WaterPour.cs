using System;
using UnityEngine;

public class WaterPourTrigger : MonoBehaviour
{
    public ParticleSystem[] waterEffects;  // Référence à l'effet de particules d'eau
    public float yMin = 1.5f;  // Condition de hauteur
    public float zMin = -2.5f;  // Condition de position Z
    public float zMax = -3.5f;
    public float angleMin = 0.85f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Vérifier la position du seau
        if ((transform.position.y > yMin && transform.position.z > zMin && transform.position.z < zMax))
        {
            // Vérifier si le seau est presque à l'envers en se basant sur l'angle autour de l'axe X
            float vector = Vector3.Dot(transform.up, Vector3.down);

            // Si l'angle est proche de 180 (presque à l'envers)
            if (vector > angleMin)
            {
                audioSource.Play();
                foreach (var waterEffect in waterEffects)
                {
                    Debug.Log(!waterEffect.isPlaying);
                    // Si l'effet de particules n'est pas déjà actif
                    if (!waterEffect.isPlaying)
                    {
                        waterEffect.Play();  // Déclenche l'animation de l'eau
                    }
                }
            }
        }
        else
        {
            foreach (var waterEffect in waterEffects)
            {
                if (waterEffect.isPlaying)
                {
                    waterEffect.Stop();
                }
            }
        }
    }
}
