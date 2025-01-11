using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerHeight;
    public float speed;
    public float minZ;      //Define the z point where the plot come back to start
    public float resetZ;    //Define the lenght between the start and the end (25*number of plots)

    // Start is called before the first frame update
    void Start()
    {
        //Test pour gérer les différentes tailles
        /*
        Vector3 position = transform.position;
        position.y = (1.7f + playerHeight) / 2 - 1.12f;
        position.y = 100;
        transform.position = position;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
