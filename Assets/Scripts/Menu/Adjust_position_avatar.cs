using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCenterOfGravity : MonoBehaviour
{
    public Animator animator;
    public Transform rootTransform; // L'élément racine du modèle (XBot)
    private Vector3 referencePosition; // Position de référence pour éviter les décalages

    void Start()
    {
        referencePosition = rootTransform.position; // Stocke la position initiale
    }

    void LateUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Si on est à la fin de 'start plank', on stocke la position
        if (stateInfo.IsName("start plank") && stateInfo.normalizedTime >= 0.95f)
        {
            referencePosition = rootTransform.position;
        }

        // Si on commence 'end plank', on applique la position de référence
        if (stateInfo.IsName("end plank") && stateInfo.normalizedTime < 0.1f)
        {
            rootTransform.position = referencePosition;
        }
    }
}



