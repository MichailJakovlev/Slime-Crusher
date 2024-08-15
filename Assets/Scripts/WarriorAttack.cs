using System.Collections;
using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    
    public SlimeController _slimeController;
    public CharacterMovement _moveScript;
    public Animator _characterAnim;

    public float attackTime;
    public int _damageValue;

    public void Start()
    {
        var _moveScript = GetComponent<CharacterMovement>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            if(Input.GetMouseButton(0))
            {
                StartCoroutine(Attack());
                _slimeController.HitSlime(_damageValue, other);
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
