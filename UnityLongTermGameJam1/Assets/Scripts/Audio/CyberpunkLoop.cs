using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CyberpunkLoop : MonoBehaviour
{
    AudioSource cyberpunkMainTheme;

    float time;

    public void Start()
    {
        cyberpunkMainTheme = GetComponent<AudioSource>();
        cyberpunkMainTheme.PlayDelayed(8.7f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 15 && !cyberpunkMainTheme.isPlaying)
        {
            print("loop stopped, resuming");
            cyberpunkMainTheme.Play();
        }
    }
}
