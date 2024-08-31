using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _UISFX;
    public AudioSource _musicBackground;
    public AudioSource _bottleSound;
    public AudioSource _swordSound;
    public AudioSource _bowSound;
    public AudioSource _takeDamageSound;
    public AudioSource _newRecordSound;
    public AudioSource _gameOverSound;

    void LateUpdate()
    {
        _musicBackground.volume += 0.2f * Time.deltaTime;
        if (Time.timeScale == 0)
        {
            _musicBackground.volume = 0;
        }
    }
    void Start()
    {
        _musicBackground.volume = 0.1f;
        _musicBackground.Play();
    }
    public void PlayUISFX()
    {
        _UISFX.Play();
    }

    public void TakeBoostSound()
    {
        _bottleSound.Play();
    }

    public void SwordSound()
    {
        _swordSound.Play();
    }

    public void BowSound()
    {
        _bowSound.Play();
    }

    public void TakeDamageSound()
    {
        _takeDamageSound.Play();
    }

    public void NewRecordSound()
    {
        _newRecordSound.Play();
    }

    public void GameOverSound()
    {
        _gameOverSound.Play();
    }
}
