using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    public void SpawnObstacle()
    {
        GameObject obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Length)];
        Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, transform.position.z), obstacle.transform.rotation);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
