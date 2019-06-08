using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTheme : MonoBehaviour
{

    AudioSource bossThemeVer;
    public AudioClip[] audioClipsArray;
    private int clipIndex;

    void Start()
    {
        bossThemeVer = GetComponent<AudioSource>();
        StartCoroutine(WaitAndExecute());
    }

    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSecondsRealtime(5.647f); //sound triggers after about 6 seconds
        
       bossThemeVer.clip = audioClipsArray[Random.Range(0, audioClipsArray.Length)];
       bossThemeVer.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
