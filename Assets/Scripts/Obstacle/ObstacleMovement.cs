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


        Transform childTransform = transform.Find("Obstacle");
        if (childTransform != null)
        {
            //Move the obstacle on the path
            childTransform.localPosition += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 0);

            //Adjust scale of the obstacle with the height of the player
            float ratio = player.playerHeight / player.PlayerDefaultHeight;
            Vector3 scale = childTransform.localScale;
            scale.y *= ratio;
            scale.z *= ratio;
            childTransform.localScale = scale;
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