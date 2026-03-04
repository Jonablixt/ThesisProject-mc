using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AS;
    private PlayerMovement player;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement>();
        AS.clip = SoundBank.SB.stepsAudio;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.Moving && player.isGrounded && !AS.isPlaying)
        {
            AS.Play();
        }
        if(!player.Moving && AS.isPlaying)
        {
            AS.Pause();
        }
    }
}