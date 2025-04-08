using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeCardInfo : MonoBehaviour
{
    public Transform cameraTransform;
    public float thresholdDistance = 0.4f;
    public float nearScale = 0.01f;
    public float farScale = 0.003f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, cameraTransform.position);

        if (distance <= thresholdDistance)
        {
            transform.localScale = Vector3.one * nearScale;
        }
        else
        {
            transform.localScale = Vector3.one * farScale;
        }
    }
}
