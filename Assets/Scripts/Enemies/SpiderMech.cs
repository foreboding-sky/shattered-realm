using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMech : MonoBehaviour
{
    [SerializeField] private float _aggroRange = 20;   
    [SerializeField] private float _attackRange = 8;
    private float _deaggroRange;

    [SerializeField] public float damage = 5;
    [SerializeField] public float attackSpeed = 4;

    [SerializeField] private LayerMask _layerPlayer;
    private StateMachine _stateMachine;
    private Collider[] _aggroSphere;
    private Collider[] _deaggroSphere;
    private Collider[] _combatSphere;


    private void Awake()
    {
        var navAgent = GetComponent<NavMeshAgent>();
        var animator = GetComponent<Animator>();
        _deaggroRange = _aggroRange * 2f;

        _stateMachine = new StateMachine();

        var patrol = new Patrol(this, navAgent, animator);
        var chase = new Chase(this, navAgent, animator);
        var attack = new Attack(this, navAgent, animator);

        AddTrans(patrol, chase, Target_Spotted());
        AddTrans(chase, patrol, Target_Escaped());

        _stateMachine.AddAnyStateTransition(attack,() => _combatSphere.Length > 0);
        AddTrans(attack, chase,() => _combatSphere.Length == 0);

        _stateMachine.SetState(patrol);
        void AddTrans(IState to, IState from, Func<bool> condition)
        {
            _stateMachine.AddTransition(to, from, condition);
        }
        Func<bool> Target_Spotted() => () => _aggroSphere.Length > 0;
        Func<bool> Target_Escaped() => () => _deaggroSphere.Length == 0;
    }

    private void Update()
    {
        StartCoroutine("SearchTarget");
        _stateMachine.StateMachineUpdate();

    }

    IEnumerator SearchTarget()
    {
        _aggroSphere = Physics.OverlapSphere(this.transform.position, _aggroRange, _layerPlayer);
        new WaitForSeconds(0.05f);
        _deaggroSphere = Physics.OverlapSphere(this.transform.position, _deaggroRange, _layerPlayer);
        new WaitForSeconds(0.05f);
        _combatSphere = Physics.OverlapSphere(this.transform.position, _attackRange, _layerPlayer);
        yield return new WaitForSeconds(0.05f);
    }

    public Collider GetTarget()
    {
        if (_deaggroSphere != null) return _deaggroSphere[0];
        else return this.GetComponent<Collider>();
    }
}
