using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameOverMenu gameOverMenu;
    public CharacterHealth _characterHelth;


    private bool isExitButtonPressed = false;
    private bool isRetryButtonPressed = false;

    public bool isGame = true;

    void Start()
    {
        gameOverMenu.ExitButton.onClick.AddListener(OnExitButtonClicked);
        gameOverMenu.RetryButton.onClick.AddListener(OnRetryButtonClicked);
        pauseMenu.ExitButton.onClick.AddListener(OnExitButtonClicked);
        isGame = true;
    }

    void OnExitButtonClicked()
    {
        isExitButtonPressed = true;
    }

    void OnRetryButtonClicked()
    {
        isRetryButtonPressed = true;
    }

    public void StartTimer()
    {
        Time.timeScale = 1;
    }

    void ButtonHandler()
    {
        if (isExitButtonPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1;
            isExitButtonPressed = false;
        }
        if (isRetryButtonPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            isRetryButtonPressed = false;
        }
    }


    void LateUpdate()
    {
        if (_characterHelth._currentHealth <= 0 && isGame)
        {
            gameOverMenu.SetGameOver();
            isGame = false;
        }
        ButtonHandler();
    }
}
