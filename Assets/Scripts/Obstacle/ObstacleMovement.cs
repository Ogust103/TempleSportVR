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
            float ratio = player.playerHeight / player.PlayerDefaultHeight();
            Vector3 scale = childTransform.localScale;
            scale.y *= ratio;
            scale.z *= ratio;
            childTransform.localScale = scale;



            //Get the extremal position of the collider
            /*
            Collider childCollider = childTransform.GetComponent<Collider>();
            if (childCollider != null)
            {
                string obstacleType = this.tag;
                float ratio = player.playerHeight/player.PlayerDefaultHeight();
                switch (obstacleType)
                {
                    case "UpObstacle":

                        Debug.Log($"Coordonée min : {childCollider.bounds.min.y}");
                        break;
                    case "DownObstacle":
                        Debug.Log($"Coordonée max : {childCollider.bounds.max.y}");
                        break;
                }
            }
            */
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
