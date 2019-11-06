using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSystem
{
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}
