using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public CharacterController _characterController;
    public SlimeInfo _slimeInfo;
    public GameObject _target;
    float cooldown = 0f;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
        _characterController = _target.GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
        cooldown -= Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.layerOverridePriority == 1 && cooldown <= 0)
            {
                _characterController.HitCharacter(_slimeInfo.damage);
                cooldown = _slimeInfo.attackSpeed;
            }
        }
    }
}
