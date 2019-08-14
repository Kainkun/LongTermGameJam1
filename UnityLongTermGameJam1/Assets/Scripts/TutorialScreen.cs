using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialScreen : MonoBehaviour
{
    float time;
    public GameObject eventSystem;
    public GameObject play;

    void Start()
    {

    }


    void Update()
    {
        if (time < 3.5f)
        {
            time += Time.deltaTime;
        }
        else if (time < 10)
        {
            pauseForTutorial();
            time = 100;
        }
    }

    void pauseForTutorial()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(play);
        Time.timeScale = 0;
    }

    public void unpauseForTutorial()
    {
        Time.timeScale = 1;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
