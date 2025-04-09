using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RunningSound : MonoBehaviour
{
    public AudioSource runningAudio;
    public Transform cameraTransform;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();

        runningAudio.loop = true;
        runningAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float y = cameraTransform.position.y + 0.12f;
        float minY = 0.95f * player.playerHeight;
        float maxY = 1.05f * player.playerHeight;
        float speed = player.speed;

        if (((y < minY || y > maxY) || speed == 0f) && runningAudio.isPlaying)
        {
            runningAudio.Pause();
        }
        else if ((y >= minY && y <= maxY && speed > 0f) && !runningAudio.isPlaying)
        {
            runningAudio.UnPause();
        }
    }
}