using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public GameObject[] obstacles;
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
            transform.position = new Vector3(transform.position.x, transform.position.y, player.resetZ);
            GameObject obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, player.resetZ - 20), obstacle.transform.rotation);
            obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, player.resetZ + 5), obstacle.transform.rotation);
            Debug.Log(obstacle.transform.rotation);
        }
        transform.Translate(Vector3.back * player.speed * Time.deltaTime);
    }
}
