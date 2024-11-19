using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    private bool paused;

    private void Start()
    {
        pauseCanvas.enabled = false;
        paused = false;
    }

    void Update()
    {
        if (GameManager.instance.levelActive)
        {
            if (!paused)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseCanvas.enabled = true;
                    paused = true;
                }
            }
            else if (paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseCanvas.enabled = false;
                    paused = false;
                }
            }
        }
        else
        {
            return;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ShowSettings()
    {

    }

    public void Resume()
    {
        pauseCanvas.enabled = false;
        paused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
