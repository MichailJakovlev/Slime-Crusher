using System.Collections;
using UnityEngine;

public class CharacterBoosts : MonoBehaviour
{
    public GameObject _character;

    public float _speedBoostTime;
    public float _damageBoostTime;
    public float _speed;
    public int _damage;

    public void Start()
    {
        _character = GameObject.FindWithTag("Player");
        _speed = _character.GetComponent<CharacterMovement>()._moveSpeed;

        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                _damage = _character.GetComponent<Warrior>()._damageValue;
                break;
            case "Shooter":
                _damage = _character.GetComponent<Shooter>()._damageValue;
                break;
            case "Wizard":
                _damage = _character.GetComponent<Wizard>()._damageValue;
                break;
        }
    }

    public void SpeedBoost(Collider other)
    {
        Destroy(other.gameObject);
        _character.GetComponent<CharacterMovement>()._moveSpeed = _speed * 1.75f;
        StartCoroutine(Speed());
    }

    public void DamageBoost(Collider other)
    {
        Destroy(other.gameObject);
        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                _character.GetComponent<Warrior>()._damageValue = _damage * 2;
                break;
            case "Shooter":
                _character.GetComponent<Shooter>()._damageValue = _damage * 2;
                break;
            case "Wizard":
                _damage = _character.GetComponent<Wizard>()._damageValue = _damage * 2;
                break;
        }
        StartCoroutine(Damage());
    }

    IEnumerator Speed()
    {
        float _startTime = Time.time;
        
        while (Time.time < _startTime + _speedBoostTime)
        {
            yield return null;
        }
        _character.GetComponent<CharacterMovement>()._moveSpeed = _speed;
    }

    IEnumerator Damage()
    {
        float _startTime = Time.time;

        while (Time.time < _startTime + _damageBoostTime)
        {
            yield return null;
        }

        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                _character.GetComponent<Warrior>()._damageValue = _damage;
                break;
            case "Shooter":
                _character.GetComponent<Shooter>()._damageValue = _damage;
                break;
            case "Wizard":
                _damage = _character.GetComponent<Wizard>()._damageValue = _damage;
                break;
        }
    }
}
