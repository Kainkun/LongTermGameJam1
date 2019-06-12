using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossTheme : MonoBehaviour
{

    AudioSource bossThemeVer;
    public AudioClip[] audioClipsArray;
    int clipIndex;

    void Start()
    {
        bossThemeVer = GetComponent<AudioSource>();
        StartCoroutine(WaitAndExecute());
    }

    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSecondsRealtime(5.647f); //sound triggers after about 6 seconds

        while (true)
        {
            bossThemeVer.clip = audioClipsArray[Random.Range(0, audioClipsArray.Length)];
            bossThemeVer.Play();
            yield return new WaitForSecondsRealtime(22.588f); //sound loops after about 23 seconds
            bossThemeVer.clip = audioClipsArray[Random.Range(0, audioClipsArray.Length)];
            bossThemeVer.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
