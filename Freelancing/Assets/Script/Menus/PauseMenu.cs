using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject settingsScreenUI;
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused != true)
            {
                Time.timeScale = 0f;
                PauseMenuUI.SetActive(true);
                isPaused = true;
            }

            else if (isPaused)
            {
                Time.timeScale = 1;
                PauseMenuUI.SetActive(false);
                isPaused = false;
            }

        }      
    }

    public void Settings()
    {
        PauseMenuUI.SetActive(false);
        settingsScreenUI.SetActive(true);
    }

    public void Back()
    {
        settingsScreenUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
