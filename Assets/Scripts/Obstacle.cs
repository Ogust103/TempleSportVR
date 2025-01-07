using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerMovement player;
    public float moveDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        transform.position += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= player.minZ)
        {
            Destroy(gameObject);
        }
        transform.position -= Vector3.forward * player.speed * Time.deltaTime;
    }
}
