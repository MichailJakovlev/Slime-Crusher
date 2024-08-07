using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    public SpawnSlimes _spawn;
    public CharacterMovement _moveScript;
    public Animator _characterAnim;
    public float attackTime;


    public void Start()
    {
        var _spawn = GetComponent<SpawnSlimes>();
        var _moveScript = GetComponent<CharacterMovement>(); 
        
    }

    public void OnTriggerStay(Collider other)
    {      
        if (other.gameObject.tag == "Slime")
        {
            if(Input.GetMouseButton(0))
            {
                StartCoroutine(Attack());
                _spawn.SpawnOnce();
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator Attack()
    {
        float startTime = Time.time;
        _moveScript.isAttack = true;

        while (Time.time < startTime + attackTime)
        {
            _characterAnim.Play("MeleeAttack_OneHanded");
            yield return null;
        }
        _moveScript.isAttack = false;
    }
}
