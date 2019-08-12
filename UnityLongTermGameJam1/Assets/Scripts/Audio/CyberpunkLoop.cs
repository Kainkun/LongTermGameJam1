using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CyberpunkLoop : MonoBehaviour
{
    AudioSource cyberpunkMainTheme;

    public void Start()
    {
        cyberpunkMainTheme = GetComponent<AudioSource>();
        cyberpunkMainTheme.PlayDelayed(8.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
