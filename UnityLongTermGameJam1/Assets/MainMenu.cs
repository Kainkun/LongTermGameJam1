using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
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
        SceneManager.LoadScene(5); // Build Settings show Credits Scene as 5
    }
}
