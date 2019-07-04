using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenuVolume : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().value = AudioListener.volume;
    }
    

    public void SetVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}
