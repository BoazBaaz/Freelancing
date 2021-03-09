using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscreen : MonoBehaviour
{
    public GameObject startScreenUI;
    public GameObject settingsScreenUI;

    private void Start()
    {
        startScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }


    public void StartGame()
    {
        startScreenUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settingsScreenUI.SetActive(true);
    }

    public void Back()
    {
        settingsScreenUI.SetActive(false);
    }
}
