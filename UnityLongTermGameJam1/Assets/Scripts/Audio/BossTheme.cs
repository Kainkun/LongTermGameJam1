using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTheme : MonoBehaviour
{

    AudioSource bossThemeVer;
    public AudioClip[] audioSourcesArray;
    public AudioClip BossThemeVer1;
    public AudioClip BossThemeVer2;

    void Start()
    {
        StartCoroutine(WaitAndExecute());
        bossThemeVer = GetComponent<AudioSource>();
    }

    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSecondsRealtime(5.647f); //sound triggers after about 6 seconds
        bossThemeVer.clip = audioSourcesArray[Random.Range(0, audioSourcesArray.Length)];
        bossThemeVer.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
