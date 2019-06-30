using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class BulletSound : MonoBehaviour
{
    AudioSource bulletSounds;
    public AudioClip CyberpunkGunshot;

    public float pitchMin, pitchMax;

    void Start()
    {
        bulletSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        */
    }
    public void playSound()
    {
        bulletSounds.PlayOneShot(CyberpunkGunshot, 0.3F);
        bulletSounds.pitch = Random.Range(pitchMin, pitchMax);
        bulletSounds.PlayOneShot(CyberpunkGunshot);
    }
}
