using UnityEngine;
using UnityEngine.AI;

public class Chase : IState

{
    private readonly SpiderMech _mech;
    private readonly NavMeshAgent _navAgent;
    private readonly Animator _animator;
    private float _oldSpeed;
    private Transform target;

    private static readonly int Speed = Animator.StringToHash("Speed");

    private float velocity;
    public Chase (SpiderMech mech, NavMeshAgent navMesh, Animator animator)
    {
        _mech = mech;
        _navAgent = navMesh;
        _animator = animator;
    }
    public void StateUpdate()
    {
        velocity = _navAgent.velocity.magnitude * _navAgent.speed/_oldSpeed / _navAgent.speed;
        _animator.SetFloat(Speed, velocity);
        _navAgent.SetDestination(target.transform.position);
    }
    public void OnEnter()
    {
        _navAgent.enabled = true;
        target = _mech.GetTarget().GetComponent<Transform>();
        _oldSpeed = _navAgent.speed;
        _navAgent.speed *= 2;
    }
    public void OnExit()
    {
        _navAgent.enabled = false;
        _navAgent.speed = _oldSpeed;
    }

}
