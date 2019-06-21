using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSounds : MonoBehaviour
{
    AudioSource clickUISounds;
    /*public AudioClip[] clickSoundsArray;*/
    public AudioClip uiSound;
    // Start is called before the first frame update
    void Start()
    {
        clickUISounds = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            /*clickUISounds.clip = clickSoundsArray[Random.Range(0, clickSoundsArray.Length)];*/
            clickUISounds.PlayOneShot(uiSound);
        }
    }
}
