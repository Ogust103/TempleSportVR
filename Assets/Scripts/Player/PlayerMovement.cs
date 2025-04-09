using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerHeight;
    private float playerDefaultHeight;
    public float speed;
    public float acceleration = 0.01f;
    public float minZ;      //Define the z point where the plot come back to start
    public float resetZ;    //Define the lenght between the start and the end (25*number of plots)

    public Transform playerTransform;

    private float boostTimer = 0f;
    private bool boostActive = false;
    private float speedDivisor = 50f;

    // Start is called before the first frame update
    void Start()
    {
        playerHeight = PlayerData.height;
        playerDefaultHeight = 1.7f;
        Debug.Log(playerDefaultHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0) speed += acceleration * Time.deltaTime;

        if (playerTransform.position.z < 0f)
        {
            float step = speed/speedDivisor * Time.deltaTime;
            playerTransform.Translate(Vector3.forward * step);

            // Clamp si dépasse 0
            if (playerTransform.position.z > 0f)
            {
                Vector3 pos = playerTransform.position;
                pos.z = 0f;
                playerTransform.position = pos;
            }
        }

        // Boost
        if (boostActive)
        {
            boostTimer += Time.deltaTime;

            speedDivisor = 1f;

            if (boostTimer >= 2f)
            {
                speedDivisor = 50f;
                boostActive = false;
            }
        }
    }

    public float PlayerDefaultHeight { 
        get {return playerDefaultHeight; }
    }

    public void Boost()
    {
        boostTimer = 0f;
        boostActive = true;
    }
}
