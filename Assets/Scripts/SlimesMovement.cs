using UnityEngine;
using UnityEngine.AI;

public class SlimesMovement : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject _target;
    
    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        _agent.SetDestination(_target.transform.position);
    }
}
