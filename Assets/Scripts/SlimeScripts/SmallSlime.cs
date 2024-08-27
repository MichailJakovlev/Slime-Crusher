using System;
using System.Collections;
using UnityEngine;

public class SmallSlime : MonoBehaviour
{
    [SerializeField] public int _damageValue;
    [SerializeField] public int _slimeHealth;
    [SerializeField] public float _animationTime;
    [SerializeField] public float _cooldownTime;

    public Animator _slimeAnim;
    public SlimesMovement _moveScript;
    public CharacterHealth _characterHealth;
    public SpawnSlimes _spawnSlimes;
    public GameObject _healBottle;
    public GameObject _speedBottle;
    public GameObject _damageBottle;

    public int _currentHealth;
    public int _luck;
    public int _boost;
    public bool _cooldown = false;
    public bool _isDamageTaking = false;




    void Start()
    {
        _currentHealth = _slimeHealth;
        _characterHealth = GameObject.FindWithTag("CharacterManager").GetComponent<CharacterHealth>();
        _spawnSlimes = GameObject.FindWithTag("SpawnSlimes").GetComponent<SpawnSlimes>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.layerOverridePriority == 1)
        {
            if (_cooldown == false && _isDamageTaking == false)
            {
                StartCoroutine(CooldownTimer());
                StartCoroutine(Attack());
                _characterHealth.GetHit(_damageValue);
            }
        }
    }

    public void GetHit(int hitAmount)
    {
        if (_currentHealth - hitAmount <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(DeathSlime());

            _spawnSlimes.Spawn();

            if (_characterHealth._currentHealth <= _characterHealth._maxHealth / 2)
            {
                _luck = UnityEngine.Random.Range(0, 10);
                if (_luck == 1)
                {
                    Instantiate(_healBottle, gameObject.transform.position, Quaternion.identity);
                }
            }

            else
            {
                _boost = UnityEngine.Random.Range(0, 15);
                if (_boost == 0)
                {
                    Instantiate(_speedBottle, gameObject.transform.position, Quaternion.identity);
                }
                else if (_boost == 15)
                {
                    Instantiate(_damageBottle, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            _currentHealth = _currentHealth - hitAmount;
        }
    }

    IEnumerator CooldownTimer()
    {
        float startTime = Time.time;
        _cooldown = true;

        while (Time.time < startTime + _cooldownTime)
        {
            yield return null;
        }

        _cooldown = false;
    }

    IEnumerator Attack()
    {
        float startTime = Time.time;
        _moveScript.isAttack = true;

        while (Time.time < startTime + _animationTime)
        {
            _slimeAnim.Play("Jump");
            yield return null;
        }

        _moveScript.isAttack = false;
    }

    IEnumerator DeathSlime()
    {
        float startTime = Time.time;
        _moveScript.isAttack = true;
        _isDamageTaking = true;

        while (Time.time < startTime + _animationTime)
        {
            _slimeAnim.Play("Damage_02");
            yield return null;
        }

        _moveScript.isAttack = false;
        _isDamageTaking = false;
        Destroy(gameObject);
    }
}
