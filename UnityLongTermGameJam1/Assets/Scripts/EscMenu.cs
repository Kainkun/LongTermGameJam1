using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    bool menuOpen;
    GameObject Canvas;
    
    void Start()
    {
        Canvas = transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
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
            menuOpen = false;
        }
        else
        {
            Time.timeScale = 0;
            Canvas.SetActive(true);
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
