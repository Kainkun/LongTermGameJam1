﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrittanyLevelCompletion : MonoBehaviour
{
    public float time;
    public float LevelLength;
    private float percent;

    void Start()
    {
        print("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        percent = (time / LevelLength)*100;
        //if time is greater than levelLength the level should be over
        if (time > LevelLength)
        {
            print("The level is over");
            // the level is over
        }
        percent = Mathf.Floor(percent);
        GetComponent<Text>().text = percent.ToString() + "%";
       
     
    }
}
