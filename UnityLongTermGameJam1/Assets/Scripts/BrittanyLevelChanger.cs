using UnityEngine;
using UnityEngine.SceneManagement;

public class BrittanyLevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // print("space key was pressed");
            FadeToNextLevel();

        }
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
        SceneManager.LoadScene(levelToLoad);
    }
}
