using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField]
    public new string _name = "";
    [SerializeField]
    public new string _description = "";
    [SerializeField]
    public new float _cooldown = 2f;

    private void Start()
    {
    }
    public override void TriggerAbility()
    {
        
    }
}
