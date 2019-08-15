using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkMainTheme : MonoBehaviour
{
    AudioSource steamPunkTheme;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        steamPunkTheme = GetComponent<AudioSource>();
        steamPunkTheme.PlayDelayed(24.003f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 30 && !steamPunkTheme.isPlaying)
        {
            print("loop stopped, resuming");
            steamPunkTheme.Play();
        }
    }
}
