using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Transform cameraTransform;
    private CapsuleCollider capsuleCollider;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        //Test pour gérer les différentes tailles
        /*
        capsuleCollider = GetComponent<CapsuleCollider>();

        if (capsuleCollider != null)
        {
            capsuleCollider.height = player.playerHeight;   // Set capsule height to player height
            Vector3 capsulePosition = capsuleCollider.center;
            capsulePosition.y = - (player.playerHeight/2 - 0.12f);
            capsuleCollider.center = capsulePosition;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Teleport the player collider to the camera
        Vector3 newPosition = cameraTransform.position;
        newPosition.y = Mathf.Max(newPosition.y, 0.1f); // Limit minimal height
        transform.position = newPosition;
    }
}
