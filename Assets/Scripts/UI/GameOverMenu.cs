using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public UIController uiController;
    public GameObject gameOverMenu;
    public List<CharacterController> characterController;
    public Button ExitButton;
    public Button RetryButton;

    public GameObject gameOverUI;
    public GameObject newRecordUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordText;
    public TextMeshProUGUI newRecordText;

    public int score = 100;
    public int record = 963;

    public void SetGameOver()
    {
        foreach (var character in characterController)
        {
            if (character.isActiveAndEnabled)
            {
                if (character.currentHealth <= 0)
                {
                    RecordHandler();
                    gameOverMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
            }
        }
    }

    void RecordHandler()
    {
        if (score <= record)
        {
            newRecordUI.SetActive(false);
            gameOverUI.SetActive(true);
        }
        else
        {
            newRecordUI.SetActive(true);
            gameOverUI.SetActive(false);
        }
        scoreText.text = score.ToString();
        recordText.text = record.ToString();
        newRecordText.text = score.ToString();
    }

}
