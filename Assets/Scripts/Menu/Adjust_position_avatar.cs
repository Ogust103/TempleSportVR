using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCenterOfGravity : MonoBehaviour
{
    public Animator animator;
    public Transform rootTransform; // L'�l�ment racine du mod�le (XBot)
    private Vector3 referencePosition; // Position de r�f�rence pour �viter les d�calages

    void Start()
    {
        referencePosition = rootTransform.position; // Stocke la position initiale
    }

    void LateUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Si on est � la fin de 'start plank', on stocke la position
        if (stateInfo.IsName("start plank") && stateInfo.normalizedTime >= 0.95f)
        {
            referencePosition = rootTransform.position;
        }

        // Si on commence 'end plank', on applique la position de r�f�rence
        if (stateInfo.IsName("end plank") && stateInfo.normalizedTime < 0.1f)
        {
            rootTransform.position = referencePosition;
        }
    }
}



