using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDelay : MonoBehaviour
{
    public AudioSource introSteamPunk;
    //public AudioClip playerDamage;


    // Start is called before the first frame update
    void Start()
    {
        introSteamPunk = GetComponent<AudioSource>();
        introSteamPunk.PlayDelayed(2.7f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        damagePlayer enemy = collision.gameObject.GetComponent<damagePlayer>();
        {
            if (enemy != null)
            {
                //introSteamPunk.PlayOneShot(playerDamage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
