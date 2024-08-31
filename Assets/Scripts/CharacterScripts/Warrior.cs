using System.Collections;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] public int _damageValue;
    [SerializeField] public float _animationTime;
    [SerializeField] public float _cooldownTime;

    public Animator _characterAnim;
    public CharacterMovement _moveScript;
    public CharacterHealth _characterHealth;
    public CharacterBoosts _characterBoosts;

    public bool _cooldown = false;
    public SmallSlime _smallSlime;

    public AudioManager _audioManager;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Slime")
        {
            if (Input.GetMouseButton(0) && _cooldown == false)
            {
                other.gameObject.GetComponent<SmallSlime>().GetHit(_damageValue);
                StartCoroutine(CooldownTimer());
                StartCoroutine(Attack());
                _audioManager.SwordSound();
            }
        }

        if(other.gameObject.tag == "Heal")
        {
            _characterHealth.GetHeal(other);
            _audioManager.TakeBoostSound();
        }

        if(other.gameObject.tag == "Speed")
        {
            _characterBoosts.SpeedBoost(other);
            _audioManager.TakeBoostSound();
        }

        if (other.gameObject.tag == "Damage")
        {
            _characterBoosts.DamageBoost(other);
            _audioManager.TakeBoostSound();
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
        _smallSlime._isDamageTaking = true;

        while (Time.time < startTime + _animationTime)
        {
            _characterAnim.Play("MeleeAttack_OneHanded");
            yield return null;
        }

        _smallSlime._isDamageTaking = false;
        _moveScript.isAttack = false;
    }
}
