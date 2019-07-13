using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrittanyLevelCompletion : MonoBehaviour
{
    public float time;
    public float LevelLength;
    public float percent;
    public Image loadingBar;

    public bool crazytime; //for boss

    public bool levelOver;

    public static BrittanyLevelCompletion Script;

    void Start()
    {
        Script = this;
        //print("Starting");

        if (crazytime)
            LevelLength = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < LevelLength && GameObject.FindGameObjectWithTag("Player") && !crazytime)
        time += Time.deltaTime;

        if (crazytime)
        {
           time = Mathf.PerlinNoise(Time.time, Mathf.Sin(Time.time)) * 0.8f;
        }

        percent = (time / LevelLength)*100;



        loadingBar.fillAmount = time/LevelLength;

        //if time is greater than levelLength the level should be over
        if (time > LevelLength)
        {
            if(!levelOver) // this way it only activates once instead of over frame
            {
                levelOver = true;
                levelManager.instance.nextLevel();
                //print("The level is over");
                // the level is over
            }
        }
        percent = Mathf.Floor(percent);
        GetComponent<Text>().text = percent.ToString();
       
     
    }
}
