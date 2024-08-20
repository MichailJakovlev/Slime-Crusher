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

    public int _currentHealth;
    public bool _cooldown = false;
    public bool _isDamageTaking = false;

    int _spawnScale;

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

            if(_characterHealth._currentHealth <= _characterHealth._maxHealth / 100 * 75)
            {
                _characterHealth._currentHealth += 5;
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
