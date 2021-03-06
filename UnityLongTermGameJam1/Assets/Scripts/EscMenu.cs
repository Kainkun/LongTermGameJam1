﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class EscMenu : MonoBehaviour
{
    bool menuOpen;
    GameObject Canvas;
    public GameObject eventSystem;
    public GameObject resume;
    public AudioMixer Lowpass;

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

        if(menuOpen && eventSystem.GetComponent<EventSystem>().currentSelectedGameObject == null && (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0))
        {
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(resume);
        }

    }

    void toggleMenu()
    {

        float LowpassOn = 0f;
        float LowpassOff = -80f;
        if (menuOpen)
        {
            //lowpass off
            Lowpass.SetFloat("WetMixLvl", LowpassOff);
            print("lowpass off");

            Time.timeScale = 1;
            Canvas.SetActive(false);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
            menuOpen = false;
        }
        else
        {
            //lowpass on
            Lowpass.SetFloat("WetMixLvl", LowpassOn);
            print("lowpass on");

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
        GameObject.FindWithTag("Player").GetComponent<PolygonCollider2D>().enabled = false;
        FindObjectOfType<BrittanyLevelChanger>().MenuIgnoreScore();
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetButtonSelectionNull()
    {
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }
}
