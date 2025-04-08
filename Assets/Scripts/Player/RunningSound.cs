using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        float y = cameraTransform.position.y;
        float minY = 0.9f * player.playerHeight;
        float maxY = 1.1f * player.playerHeight;
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