using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private PlayerMovement player;
    public float moveDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        //Move the obstacle on the path
        Transform childTransform = transform.Find("Obstacle");
        if (childTransform != null)
        {
            childTransform.localPosition += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
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
