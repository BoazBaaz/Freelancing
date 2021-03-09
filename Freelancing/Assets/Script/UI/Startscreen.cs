using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(1);
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
