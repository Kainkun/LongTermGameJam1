using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    int highscore;

    // Start is called before the first frame update
    void Start()
    {


        if(Score.ScoreScript != null)
        {
            if (Score.ScoreScript.getScore() > PlayerPrefs.GetInt("HighScore"))
            {
                highscore = Score.ScoreScript.getScore();
                GetComponent<Text>().text = "High-Score: " + highscore;
                PlayerPrefs.SetInt("HighScore", highscore);
            }
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("HighScore");
            if(highscore != 0)
            GetComponent<Text>().text = "High-Score: " + highscore;
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            GetComponent<Text>().text = "";
        }
    }
}
