using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public UIController uiController;
    public GameObject menu;
    public Button ExitButton;


    public void SetPauseMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
