using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    public ObjectSpawner objectSpawner;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy if out of range
        if (transform.position.z <= player.minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + player.resetZ);
            obstacleSpawner.SpawnObstacle();
            objectSpawner.SpawnObject();
        }
        //Move the floor at every frame
        transform.Translate(Vector3.back * player.speed * Time.deltaTime);
    }
}
