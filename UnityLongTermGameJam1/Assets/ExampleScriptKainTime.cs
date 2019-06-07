using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleScriptKainTime : MonoBehaviour
{
    public float time;
    public float levelLength;
    string percentage;
    bool fading;

    void Start()
    {
        
    }


    void Update()
    {
        
        if (time < levelLength)
            time += Time.deltaTime;
        else
        {
            time = levelLength;
            nextLevel();
        }

        percentage = Mathf.Floor(time / levelLength * 100).ToString() + "%";
        GetComponent<Text>().text = percentage;
    }

    void nextLevel()
    {
        if (fading == false)
        {
            fading = true;
            FindObjectOfType<BrittanyLevelChanger>().FadeToNextLevel();
        }
    }
}
