using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public GameObject _onButtonGameObject;
    public GameObject _offButtonGameObject;
    public AudioMixer _audioMixer;

    void Start()
    {
        var prefsVolume = PlayerPrefs.GetInt("Volume", 1);
        if (prefsVolume == 1)
        {
            _audioMixer.SetFloat("MasterVolume", 0);
            _offButtonGameObject.SetActive(false);
            _onButtonGameObject.SetActive(true);
        }
        if (prefsVolume == 0)
        {
            _audioMixer.SetFloat("MasterVolume", -80);
            _offButtonGameObject.SetActive(true);
            _onButtonGameObject.SetActive(false);
        }
    }

    public void OnButtonPress()
    {
        _offButtonGameObject.SetActive(true);
        _onButtonGameObject.SetActive(false);
        PlayerPrefs.SetInt("Volume", 0);
        _audioMixer.SetFloat("MasterVolume", -80);
    }

    public void OffButtonPress()
    {
        _offButtonGameObject.SetActive(false);
        _onButtonGameObject.SetActive(true);
        PlayerPrefs.SetInt("Volume", 1);
        _audioMixer.SetFloat("MasterVolume", 0);
    }

}
