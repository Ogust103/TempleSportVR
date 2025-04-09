using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectMovement : MonoBehaviour
{
    private PlayerMovement player;
    public float moveDistance;
    private XRGrabInteractable grabInteractable;

    public Vector3 localOffset = new Vector3(0, 0, 0.3f); // Position par rapport à la main
    private Transform handTransform;
    private bool isGrabbed = false;
    private bool isColliding = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        transform.position += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 5);
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if (!isGrabbed)
        {
            if (isColliding)
            {
                transform.position -= Vector3.forward * player.speed * Time.deltaTime;
            }

            if (transform.position.z <= player.minZ)
            {
                Destroy(gameObject);
            }
        }
        else if (handTransform != null)
        {
            transform.position = handTransform.TransformPoint(localOffset);
            transform.rotation = handTransform.rotation;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        handTransform = args.interactorObject.transform;
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        handTransform = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
