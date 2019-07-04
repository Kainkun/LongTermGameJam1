using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelManager : MonoBehaviour
{
    public bool SkipLevel;
    public static levelManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(SkipLevel)
        {
            SkipLevel = false;
            nextLevel();
        }

        //if (FindObjectsOfType<EnemySpawner>().Length == 0&&GameObject.FindGameObjectsWithTag("enemy").Length==0)
         //   nextLevel();
    }
    public void beginResetLevel()
    {
        StartCoroutine(resetLevel());
    }
    public IEnumerator resetLevel()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<BrittanyLevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void nextLevel()
    {
        Score.ScoreScript.setPrevScore(Score.ScoreScript.getScore());

        if (GetComponent<PlayerDimensionHop>() != null)
        GetComponent<PlayerDimensionHop>().HopOut();
        else
        FindObjectOfType<BrittanyLevelChanger>().FadeToNextLevel();
    }
}
