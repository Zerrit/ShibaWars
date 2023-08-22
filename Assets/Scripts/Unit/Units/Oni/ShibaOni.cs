using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni : Unit
{
    public ShibaOni_MoveState moveState { get; private set; }
    public ShibaOni_AttackState attackState { get; private set; }
    public ShibaOni_DeathState deathState { get; private set; }
    public ShibaOni_IdleState idleState { get; private set; }


    public Transform AttackPoint;


    public override void Awake()
    {
        base.Awake();

        moveState = new ShibaOni_MoveState(this, StateMachine, "Move", this);
        attackState = new ShibaOni_AttackState(this, StateMachine, "Attack", this);
        deathState = new ShibaOni_DeathState(this, StateMachine, "Death", this);
        idleState = new ShibaOni_IdleState(this, StateMachine, "Idle", this);
    }
    private void OnEnable()
    {
        StateMachine.Initialize(idleState);
    }
    public override void Attack()
    {
        base.Attack();

        List<Unit> enemies = BattleCommunicator.instance.CheckEnemies(this);
        foreach (Unit unit in enemies)
        {
            unit.GetDamage(damage);
        }
    }

    public override void DefeatSelf()
    {
        base.DefeatSelf();
        StateMachine.ChangeState(deathState);
    }
}
