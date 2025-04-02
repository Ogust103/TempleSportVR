using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerHeight;
    private float playerDefaultHeight;
    public float speed;
    public float minZ;      //Define the z point where the plot come back to start
    public float resetZ;    //Define the lenght between the start and the end (25*number of plots)

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerDefaultHeight = 1.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z < 0f)
        {
            float step = speed/50 * Time.deltaTime;
            playerTransform.Translate(Vector3.forward * step);

            // Clamp si dépasse 0
            if (playerTransform.position.z > 0f)
            {
                Vector3 pos = playerTransform.position;
                pos.z = 0f;
                playerTransform.position = pos;
            }
        }
    }

    public float PlayerDefaultHeight() { 
        return playerDefaultHeight;
    }
}
