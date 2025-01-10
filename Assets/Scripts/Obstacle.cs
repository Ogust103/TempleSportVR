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

        Transform childTransform = transform.Find("Obstacle");
        if (childTransform != null)
        {
            childTransform.localPosition += new Vector3(Random.Range(-moveDistance, moveDistance), 0, 0);
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assure-toi que l'objet joueur a le tag "Player"
        {
            Debug.Log("Collision détectée avec le joueur !");
        }
    }
}
