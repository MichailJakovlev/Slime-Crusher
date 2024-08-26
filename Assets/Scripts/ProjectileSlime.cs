using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSlime : MonoBehaviour
{
    public float life = 3;
    public ShootSlime _shootSlime;

    public CharacterHealth _characterHealth;

    void Start()
    {
        _characterHealth = GameObject.FindWithTag("CharacterManager").GetComponent<CharacterHealth>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"  && other.layerOverridePriority == 1)
        {
            _characterHealth.GetHit(_shootSlime._projectileDamage);
            Destroy(gameObject);
        }
        if (other.gameObject && other.gameObject.tag != "Slime" && other.gameObject.tag != "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
