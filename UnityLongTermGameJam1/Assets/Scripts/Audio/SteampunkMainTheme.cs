using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkMainTheme : MonoBehaviour
{
    AudioSource steamPunkTheme;

    // Start is called before the first frame update
    void Start()
    {
        steamPunkTheme = GetComponent<AudioSource>();
        steamPunkTheme.PlayDelayed(24.033f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
