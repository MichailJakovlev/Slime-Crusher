using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScore : MonoBehaviour
{
    public TextMeshProUGUI _recordText;
    void Start()
    {
        _recordText.text = PlayerPrefs.GetInt("Record").ToString();
    }
}
