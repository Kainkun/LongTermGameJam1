using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuThemes : MonoBehaviour
{
    AudioSource menuTheme;
    public AudioClip[] audioClipArray;

    
    void Start()
    {
        menuTheme = GetComponent<AudioSource>();
        menuTheme.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        menuTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
