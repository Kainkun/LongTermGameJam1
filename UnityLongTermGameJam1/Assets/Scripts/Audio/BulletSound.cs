using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class BulletSound : MonoBehaviour
{
    AudioSource bulletSounds;
    public AudioClip CyberpunkGunshot;

    public float pitchMin, pitchMax;
    public float Volume = 0.7f;

    void Start()
    {
        bulletSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playSound()
    {
        bulletSounds.PlayOneShot(CyberpunkGunshot);
        bulletSounds.pitch = Random.Range(pitchMin, pitchMax);
        bulletSounds.volume = Volume;
    }
}
