using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public AudioClip HopInSound;
    public AudioClip HopOutSound;

    bool sound1HasPlayed;
    bool sound2HasPlayed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time >= 0.6 && !sound1HasPlayed)
        {
            sound1HasPlayed = true;
            GetComponent<AudioSource>().PlayOneShot(HopInSound);
        }

      if (BrittanyLevelCompletion.Script.percent >= 100 && !sound2HasPlayed)
        {
            sound2HasPlayed = true;
            GetComponent<AudioSource>().PlayOneShot(HopOutSound);
        }
    }
}
