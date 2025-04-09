using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectMovement : MonoBehaviour
{
    private PlayerMovement player;
    public float moveDistance;
    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        transform.position += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 0);
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabInteractable.isSelected)
        {
            //Destroy if out of range
            if (transform.position.z <= player.minZ)
            {
                Destroy(gameObject);
            }
            //Make the obstacle move at every frame
            transform.position -= Vector3.forward * player.speed * Time.deltaTime;
        }
    }
}
