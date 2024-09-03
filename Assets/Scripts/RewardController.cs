using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{
    public CharacterSelection _characterSelection;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _adButton;
    [SerializeField] private Button _donateButton;

    public GameObject _rewardContainer;

    public Renderer _shooterRenderer;
    public Renderer _bowRenderer;
    public Renderer _cloakRenderer;
    public Renderer _wizardRenderer;

    private int _openedCharacters;

    void Start()
    {
        _openedCharacters = PlayerPrefs.GetInt("OpenedCharacters", 1);
    }

    public void AdButtonPress()
    {
        PlayerPrefs.SetInt("OpenedCharacters", _openedCharacters + 1);
        _characterSelection.ChangeCharacter(0);
    }
    public void DonateButtonPress()
    {
        PlayerPrefs.SetInt("OpenedCharacters", 3);
        _characterSelection.ChangeCharacter(0);
    }
    public void RewordHandler(int currentCharacter)
    {
        _openedCharacters = PlayerPrefs.GetInt("OpenedCharacters", 1);

        if (currentCharacter >= 1 && _openedCharacters == 1)
        {
            _shooterRenderer.material.color = Color.black;
            _bowRenderer.material.color = Color.black;
            _cloakRenderer.material.color = Color.black;
            _wizardRenderer.material.color = Color.black;

            _rewardContainer.SetActive(true);
            _playButton.interactable = false;

            if (currentCharacter == 2)
            {
                _adButton.interactable = false;
            }
            else
            {
                _adButton.interactable = true;
            }
        }
        else if (currentCharacter == 2 && _openedCharacters == 2)
        {
            _cloakRenderer.material.color = Color.black;
            _wizardRenderer.material.color = Color.black;
            _rewardContainer.SetActive(true);
            _playButton.interactable = false;
            }
        else {
            _rewardContainer.SetActive(false);
            _playButton.interactable = true;
            _shooterRenderer.material.color = Color.white;
            _bowRenderer.material.color = Color.white;
            _cloakRenderer.material.color = Color.white;
            _wizardRenderer.material.color = Color.white;
        }
    }
}
