using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickEvent : MonoBehaviour
{
 

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        // Load the game scene
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Stage_1");
    }

    public void Reset()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameStart");
    }
}

