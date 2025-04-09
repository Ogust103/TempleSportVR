using System;
using UnityEngine;

public class WaterPour : MonoBehaviour
{
    public ParticleSystem waterEffect;
    public float yMin = 1f;
    public float zMin = -1f;
    public float zMax = -3.5f;
    public float angleMin = 0.8f;

    private AudioSource audioSource;
    private float pourTime = 0f;
    private bool actionTriggered = false;
    private PlayerMovement player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        float vector = Vector3.Dot(transform.up, Vector3.down);
        //bool pouring = (transform.position.y > yMin && transform.position.z < zMin && vector > angleMin);

        if (vector > angleMin)
        {
            if (!waterEffect.isPlaying)
            {
                audioSource.Play();
                waterEffect.Play();
            }

            if (transform.position.y > yMin && transform.position.z < zMin)
            {
                pourTime += Time.deltaTime;

                if (pourTime >= 2f && !actionTriggered)
                {
                    actionTriggered = true;
                    TriggerWaterAction();
                }
            }
        }
        else
        {
            if (waterEffect.isPlaying)
            {
                waterEffect.Stop();
            }
            pourTime = 0f;
            actionTriggered = false;
        }
    }

    void TriggerWaterAction()
    {
        Debug.Log("Action après 2 secondes de versement !");
        player.Boost();
        Destroy(gameObject);
    }
}
