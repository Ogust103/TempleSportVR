using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject obj;
    public PlayerInfo player;


    public void SpawnObject()
    {
        float temp = player.Temp;
        Debug.Log(temp);
        if (temp >= 30 && UnityEngine.Random.value < 0.2f)
        {
            Debug.Log("Spawn");
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), obj.transform.rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
