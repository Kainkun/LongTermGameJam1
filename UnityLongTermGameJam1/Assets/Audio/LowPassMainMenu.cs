using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class LowPassMainMenu : MonoBehaviour
{

    public AudioMixer Lowpass;
    // Start is called before the first frame update
    void Start()
    {
        float LowpassOff = -80f;
        //lowpass off
        Lowpass.SetFloat("WetMixLvl", LowpassOff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
