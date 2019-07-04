using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuThemes : MonoBehaviour
{
    AudioSource menuTheme;
    public AudioClip[] audioClipArray;
    public AudioClip uiClick;
    
    void Start()
    {
        menuTheme = GetComponent<AudioSource>();
        menuTheme.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        menuTheme.Play();
    }

    public void UIClick()
    {
        menuTheme.PlayOneShot(uiClick);
    }

    public void UIClickStopsMusic()
    {
        menuTheme.Stop();
        UIClick();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
