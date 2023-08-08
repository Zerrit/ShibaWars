using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni : Entity
{
    public ShibaOni_MoveState moveState { get; private set; }
    public ShibaOni_AttackState attackState { get; private set; }
    public ShibaOni_DeathState deathState { get; private set; }
    public ShibaOni_IdleState idleState { get; private set; }


    public Transform AttackPoint;


    public override void Awake()
    {
        base.Awake();

        moveState = new ShibaOni_MoveState(this, stateMachine, "Move", this);
        attackState = new ShibaOni_AttackState(this, stateMachine, "Attack", this);
        deathState = new ShibaOni_DeathState(this, stateMachine, "Death", this);
        idleState = new ShibaOni_IdleState(this, stateMachine, "Idle", this);
    }
    private void OnEnable()
    {
        stateMachine.Initialize(idleState);
    }
    public override void Attack()
    {
        base.Attack();

        List<Entity> enemies = BattleCommunicator.instance.CheckEnemies(this);
        foreach (Entity unit in enemies)
        {
            unit.GetDamage(damage);
        }
    }

}
