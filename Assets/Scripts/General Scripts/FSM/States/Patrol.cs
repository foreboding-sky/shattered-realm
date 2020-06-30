using UnityEngine;
using UnityEngine.AI;

public class Patrol : IState

{
    private readonly NavMeshAgent _navAgent;
    private readonly Animator _animator;
    private readonly Vector3 _startingPos;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private Vector3 _nextPosition = Vector3.zero;
    private float velocity;
    public Patrol (SpiderMech mech, NavMeshAgent navMesh, Animator animator)
    {
        _navAgent = navMesh;
        _animator = animator;
        _startingPos = mech.transform.position;
    }

    public void StateUpdate()
    {

        velocity = _navAgent.velocity.magnitude / _navAgent.speed;
        _animator.SetFloat(Speed, velocity);
        if (velocity <= 0.05f)
        {
            _navAgent.SetDestination(RandomPoint());
        }
    }

    public void OnEnter()
    {
        _navAgent.enabled = true;
    }

    public void OnExit()
    {
        _navAgent.enabled = false;
        _animator.SetFloat(Speed, 0f);
    }

    private Vector3 RandomPoint()
    {
        _nextPosition = new Vector3(Random.Range(-10f, 10f),0, Random.Range(-10f, 10f));
        return _startingPos + _nextPosition;
    }
}
