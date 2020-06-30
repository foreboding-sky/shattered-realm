
using UnityEngine;
using UnityEngine.AI;


public class Attack : IState

{
    private readonly SpiderMech _mech;
    private readonly NavMeshAgent _navAgent;
    private readonly Animator _animator;
    private float _oldSpeed;
    private Transform _target;
    private Health _targetHP;
    private float _nextAttack;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    private float velocity;
    public Attack(SpiderMech mech, NavMeshAgent navMesh, Animator animator)
    {
        _mech = mech;
        _navAgent = navMesh;
        _animator = animator;
    }
    public void StateUpdate()
    {
        velocity = _navAgent.velocity.magnitude * _navAgent.speed / _oldSpeed / _navAgent.speed;
        _animator.SetFloat(Speed, velocity);
        _navAgent.SetDestination(_target.transform.position);
        if (_nextAttack <= Time.time)
        {
            _nextAttack = Time.time + (1f / _mech.attackSpeed);

            if (_animator.GetBool(Shoot) == false)
            {
                    _animator.SetBool(Shoot, true);
            }

            _targetHP.TakeDamage(_mech.damage);
        }
    }
    public void OnEnter()
    {
        _target = _mech.GetTarget().GetComponent<Transform>();
        _targetHP = _mech.GetTarget().GetComponent<Health>();

        _navAgent.enabled = true;
        _oldSpeed = _navAgent.speed;
        _navAgent.speed /= 2;    
    }
    public void OnExit()
    {
        _navAgent.enabled = false;
        _navAgent.speed = _oldSpeed;
        _animator.SetBool(Shoot, false);
    }
    
}
