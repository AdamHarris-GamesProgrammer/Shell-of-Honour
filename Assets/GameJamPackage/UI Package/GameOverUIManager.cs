using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeSurvivedText;
    [SerializeField]  private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        foreach(Transform child in gameOverScreen.transform)
        {
            child.gameObject.SetActive(true);
        }

        scoreText.text = "Score: " + GameManager.instance.scoreSystem.score.ToString();
        timeSurvivedText.text = "Time Survived: " + GameManager.instance.timeSurvived.ToString();
    }

    public void Retry()
    {
        SceneSystem.LoadLevel("Game");
    }

    public void LoadMenu()
    {
        SceneSystem.LoadMainMenu();
    }

    public void Exit()
    {
        SceneSystem.QuitApplication();
    }
}
