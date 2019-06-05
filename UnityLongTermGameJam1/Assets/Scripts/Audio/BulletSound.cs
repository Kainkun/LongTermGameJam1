using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class BulletSound : MonoBehaviour
{
    AudioSource cybepunkBullets;

    public AudioClip CyberpunkGunshot;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.PlayOneShot(CyberpunkGunshot, 0.5F);
        }
        
    }
}
