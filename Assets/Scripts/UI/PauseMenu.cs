using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public UIController uiController;
    public GameObject menu;
    public Button ExitButton;

    public void PauseMenuToggle(bool isPosible)
    {
        if (isPosible)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!uiController.pauseMenu.isActiveAndEnabled)
                {
                    menu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    menu.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
    }
    public void SetPauseMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
