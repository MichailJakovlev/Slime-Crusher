using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public UIController uiController;
    public GameObject gameOverMenu;
    public Button ExitButton;
    public Button RetryButton;
    public SpawnSlimes spawnSlimes;

    public GameObject gameOverUI;
    public GameObject newRecordUI;
    public TextMeshProUGUI _scoreTextMenu;
    public TextMeshProUGUI _recordTextMenu;
    public TextMeshProUGUI _newRecordTextMenu;

    int _score = 0;

    public void SetGameOver()
    {
        RecordHandler();
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void RecordHandler()
    {
        _score = spawnSlimes._score;
        if (_score > PlayerPrefs.GetInt("Record"))
        {
            newRecordUI.SetActive(true);
            gameOverUI.SetActive(false);
            _newRecordTextMenu.text = _score.ToString();
            PlayerPrefs.SetInt("Record", _score);
        }
        else
        {
            newRecordUI.SetActive(false);
            gameOverUI.SetActive(true);
            _scoreTextMenu.text = _score.ToString();
            _recordTextMenu.text = PlayerPrefs.GetInt("Record").ToString();
        }
    }

}
