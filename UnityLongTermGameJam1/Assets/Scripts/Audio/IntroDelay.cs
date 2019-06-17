using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDelay : MonoBehaviour
{
    AudioSource introSteamPunk;

    // Start is called before the first frame update
    void Start()
    {
        introSteamPunk = GetComponent<AudioSource>();
        introSteamPunk.PlayDelayed(2.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
