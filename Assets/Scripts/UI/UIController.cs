using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameOverMenu gameOverMenu;

    private bool isExitButtonPressed = false;
    private bool isRetryButtonPressed = false;

    void Start()
    {
        gameOverMenu.ExitButton.onClick.AddListener(OnExitButtonClicked);
        gameOverMenu.RetryButton.onClick.AddListener(OnRetryButtonClicked);
        pauseMenu.ExitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnExitButtonClicked()
    {
        isExitButtonPressed = true;
    }

    void OnRetryButtonClicked()
    {
        isRetryButtonPressed = true;
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

    void UIHandler()
    {
        if (gameOverMenu.isActiveAndEnabled)
        {
            pauseMenu.PauseMenuToggle(false);
        }
        else
        {
            pauseMenu.PauseMenuToggle(true);
        }
        if (!pauseMenu.isActiveAndEnabled)
        {
            Time.timeScale = 1;
        }
        gameOverMenu.SetGameOver();
    }

    void LateUpdate()
    {
        UIHandler();
        ButtonHandler();
    }
}
