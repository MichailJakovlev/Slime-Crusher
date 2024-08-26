using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSlime : MonoBehaviour
{
    [SerializeField] public float _cooldownTime;
    public bool _cooldown = false;

    public Transform _projectileSpawnPoint;
    public int projectileSpeed = 3;

    public int _projectileDamage = 10;

    public GameObject _projectile;
    void LateUpdate()
    {
        if (_cooldown == false)
        {
            var projectile = Instantiate(_projectile, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = _projectileSpawnPoint.forward * projectileSpeed;
            StartCoroutine(CooldownTimer());
            // StartCoroutine(Attack());
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
    // IEnumerator Attack()
    // {
    //     float startTime = Time.time;
    //     _moveScript.isAttack = true;
    //     _smallSlime._isDamageTaking = true;

    //     while (Time.time < startTime + _animationTime)
    //     {
    //         _characterAnim.Play("BowShot");
    //         yield return null;
    //     }

    //     _smallSlime._isDamageTaking = false;
    //     _moveScript.isAttack = false;
    // }
}
