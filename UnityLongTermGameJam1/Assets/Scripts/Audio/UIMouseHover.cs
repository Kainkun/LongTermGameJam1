using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMouseHover : MonoBehaviour
{
    AudioSource uiAudioSource;
    public AudioClip uiMouseClip;
    // Start is called before the first frame update
    void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
    }

    public void UIMouseHoverSound()
    {
        uiAudioSource.PlayOneShot(uiMouseClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
