using UnityEngine;
using UnityEngine.AI;

public class SlimesMovement : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject _target;
    public Animator _anim;
    public bool isAttack = false;
    
    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        _agent.SetDestination(_target.transform.position);

        if(isAttack == false)
        {
            _anim.Play("Walk");
        }
    }
}
