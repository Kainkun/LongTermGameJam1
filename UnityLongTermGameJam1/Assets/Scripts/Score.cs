using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score ScoreScript;
    public static int score;
    public static int prevScore;
    Color start;

    void Start()
    {

        if (ScoreScript == null)
        {
            ScoreScript = this;
            DontDestroyOnLoad(transform.parent);
        }
        else
        {
            Destroy(gameObject);
        }


        start = GetComponent<Text>().color;
    }


    public void AddScore(int Amount)
    {
        score += Amount;
        StartCoroutine(BlinkText(Color.white));
    }

    public void SubScore(int Amount)
    {
        score -= Amount;
        StartCoroutine(BlinkText(Color.red));
        if (score < 0)
            score = 0;
    }


    void Update()
    {
        GetComponent<Text>().text = "Score: " + score;
    }

    IEnumerator BlinkText(Color color)
    {
        GetComponent<Text>().color = color;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Text>().color = start;
    }

    public void setScore(int setScore)
    {
        score = setScore;
        if (score < 0)
            score = 0;
    }

    public void setPrevScore(int setscore)
    {
        prevScore = setscore;
    }

    public int getScore()
    {
        return score;
    }

    public int getPrevScore()
    {
        return prevScore;
    }
}
