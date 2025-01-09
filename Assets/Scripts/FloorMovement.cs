using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= player.minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + player.resetZ);
            obstacleSpawner.SpawnObstacle();
        }
        else {             
        }
        transform.Translate(Vector3.back * player.speed * Time.deltaTime);
    }
}
