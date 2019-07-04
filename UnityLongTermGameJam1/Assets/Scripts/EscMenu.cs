using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EscMenu : MonoBehaviour
{
    bool menuOpen;
    GameObject Canvas;
    public GameObject eventSystem;
    public GameObject resume;

    void Start()
    {
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
        Canvas = transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            toggleMenu();
        }

        if (Input.GetButtonDown("Back") && menuOpen)
        {
            toggleMenu();
        }

    }

    void toggleMenu()
    {
        if (menuOpen)
        {
            Time.timeScale = 1;
            Canvas.SetActive(false);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
            menuOpen = false;
        }
        else
        {
            Time.timeScale = 0;
            Canvas.SetActive(true);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(resume);
            menuOpen = true;
        }

    }

    public void Resume()
    {
        toggleMenu();
    }

    public void Menu()
    {
        GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled = false;
        FindObjectOfType<BrittanyLevelChanger>().MenuIgnoreScore();
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
