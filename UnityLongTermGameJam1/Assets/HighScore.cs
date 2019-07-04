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
            if (Score.ScoreScript.getScore() > highscore)
            {
                highscore = Score.ScoreScript.getScore();
                GetComponent<Text>().text = "High-Score: " + highscore;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
