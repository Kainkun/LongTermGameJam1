using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    bool creditsOpen;
    public GameObject slider;

    private void Start()
    {
        slider.GetComponent<Slider>().value = AudioListener.volume;
    }


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        // Debug.Log("Quit!"); // Testing to see if Quit button works
        Application.Quit();
    }

    public void SetVolume (float newVolume)
    {
        //Debug.Log(newVolume); // Testing to see if volume slider works
        AudioListener.volume = newVolume;
    }
    public void ViewCredits ()
    {
        toggleCredits();
    }

    void toggleCredits()
    {
        if (creditsOpen)
        {
            credits.SetActive(false);
            creditsOpen = false;
        }
        else
        {
            credits.SetActive(true);
            creditsOpen = true;
        }

    }
}
