using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrittanyLevelCompletion : MonoBehaviour
{
    public float time;
    public float LevelLength;
    private float percent;
    public Image loadingBar;

    bool levelOver;
    void Start()
    {
        print("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        if(time < LevelLength)
        time += Time.deltaTime;
        percent = (time / LevelLength)*100;

        loadingBar.fillAmount = time/LevelLength;

        //if time is greater than levelLength the level should be over
        if (time > LevelLength)
        {
            if(!levelOver) // this way it only activates once instead of over frame
            {
                levelOver = true;
                levelManager.instance.nextLevel();
                print("The level is over");
                // the level is over
            }
        }
        percent = Mathf.Floor(percent);
        GetComponent<Text>().text = percent.ToString() + "%";
       
     
    }
}
