using UnityEngine;
using UnityEngine.SceneManagement;

public class BrittanyLevelChanger : MonoBehaviour
{  //Brittany Hughes

    public Animator animator;
    private int levelToLoad;

    public GameObject canvas;

    // Update is called once per frame
    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        canvas.SetActive(true);
    }
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            // print("space key was pressed");
            FadeToNextLevel();

        }
        */

    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        if(levelToLoad == -1)
        {
            Score.ScoreScript.setScore(0);
            Score.ScoreScript.setPrevScore(0);
            SceneManager.LoadScene(0);
        }
        else
        SceneManager.LoadScene(levelToLoad);
    }

    public void MenuIgnoreScore()
    {
        levelToLoad = -1;
        animator.SetTrigger("FadeOut");
    }
}
