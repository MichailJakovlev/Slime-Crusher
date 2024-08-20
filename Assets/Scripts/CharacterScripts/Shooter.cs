using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public int _damageValue;
    [SerializeField] public float _animationTime;
    [SerializeField] public float _cooldownTime;

    public Animator _characterAnim;
    public CharacterMovement _moveScript;

    public bool _cooldown = false;
    public SmallSlime _smallSlime;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Slime")
        {
            if (Input.GetMouseButton(0) && _cooldown == false)
            {
                other.gameObject.GetComponent<SmallSlime>().GetHit(_damageValue);
                StartCoroutine(CooldownTimer());
                StartCoroutine(Attack());
            }
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
            _characterAnim.Play("Shooter.BowShot");
            yield return null;
        }

        _smallSlime._isDamageTaking = false;
        _moveScript.isAttack = false;
    }
}
