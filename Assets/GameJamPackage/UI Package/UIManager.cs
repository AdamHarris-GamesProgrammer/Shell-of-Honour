using System;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameStartScreen;
    [SerializeField] private GameObject gamePauseScreen;
    [SerializeField] private GameObject healthSlider;
    [SerializeField] private GameObject bloodImage;
    [SerializeField] private Text timeSurvivedText;

    private float timer = 0f;

    public void SetGamePauseScreen(bool value)
    {
        gamePauseScreen.SetActive(value);
        healthSlider.SetActive(!value);
        bloodImage.SetActive(!value);
        timeSurvivedText.gameObject.SetActive(!value);
    }

    public void SetGameStartScreen(bool value)
    {
        gameStartScreen.SetActive(!value);
        healthSlider.SetActive(value);
        bloodImage.SetActive(value);
        timeSurvivedText.gameObject.SetActive(value);
    }

    void Update()
    {
        if(GameManager.instance.isGameStarted)
            timer += Time.deltaTime;

        if(GameManager.instance.isGameOver)
            timeSurvivedText.gameObject.SetActive(false);

        if(timeSurvivedText.gameObject.activeInHierarchy)
            timeSurvivedText.text = timer.ToString("F2") + "s";

        GameManager.instance.timeSurvived = timer;
    }
}
