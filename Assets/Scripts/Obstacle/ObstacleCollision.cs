using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private DamageEffect damage;

    void Start()
    {
        //Find script DamageEffect
        damage = FindObjectOfType<DamageEffect>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Play the animation when the phayer hit an obstacle
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger détecté avec : " + other.gameObject.name);
            damage.TriggerDamageEffect();
        }
    }
}
