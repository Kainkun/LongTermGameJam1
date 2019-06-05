using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CyberpunkLoop : MonoBehaviour
{
    AudioSource cyberpunkMainTheme;
    public AudioClip CyberPunkMainTheme;

    void Start()
    {
        cyberpunkMainTheme = GetComponent<AudioSource>();
        cyberpunkMainTheme.PlayDelayed(6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
