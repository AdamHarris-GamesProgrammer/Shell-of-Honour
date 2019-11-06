using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timeSurvived;

    GameOverUIManager gameOverManager;
    UIManager uiManager;
    public ScoreSystem scoreSystem;

    public UnityEvent gameOverEvent;

    public bool isGameOver = false;
    public bool isGameStarted = false;
    bool isPaused = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

        gameOverManager = GameObject.Find("UISystem/GameOverUI").GetComponent<GameOverUIManager>();
        uiManager = GameObject.Find("UISystem/GameUI").GetComponent<UIManager>();

        scoreSystem = GetComponent<ScoreSystem>();

        gameOverEvent.AddListener(GameOver);
    }

    private void LateUpdate()
    {
        if (!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameStarted = true;
                uiManager.SetGameStartScreen(isGameStarted);
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                uiManager.SetGamePauseScreen(isPaused);
            }

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if (Debug.isDebugBuild && !isGameOver && isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                gameOverEvent.Invoke();
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverManager.OnGameOver();
    }
}
