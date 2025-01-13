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

    // Start is called before the first frame update
    void Start()
    {
        playerDefaultHeight = 1.7f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float PlayerDefaultHeight() { 
        return playerDefaultHeight;
    }
}
