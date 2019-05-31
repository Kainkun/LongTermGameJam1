using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<EnemySpawner>().Length == 0&&GameObject.FindGameObjectsWithTag("enemy").Length==0)
            nextLevel();
    }
    public void resetLevel()
    {
        FindObjectOfType<BrittanyLevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void nextLevel()
    {
        FindObjectOfType<BrittanyLevelChanger>().FadeToNextLevel();
    }
}
