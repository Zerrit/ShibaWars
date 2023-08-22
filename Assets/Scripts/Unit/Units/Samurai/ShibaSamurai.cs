using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai : Unit
{
    public ShibaSamurai_IdleState idleState { get; private set; }
    public ShibaSamurai_MoveState moveState { get; private set; }
    public ShibaSamurai_AttackState attackState { get; private set; }
    public ShibaSamurai_DeathState deathState { get; private set; }


    public override void Awake()
    {
        base.Awake();

        idleState = new ShibaSamurai_IdleState(this, StateMachine, "Idle", this);
        moveState = new ShibaSamurai_MoveState(this, StateMachine, "Move", this);
        attackState = new ShibaSamurai_AttackState(this, StateMachine, "Attack", this);
        deathState = new ShibaSamurai_DeathState(this, StateMachine, "Death", this);
    }

    private void OnEnable()
    {
        StateMachine.Initialize(idleState);
    }

    public override void Attack()
    {
        base.Attack();
        AudioManager.instance.Play("SamuraiAttack", 5);
        enemy.GetDamage(damage);
    }

    public override void DefeatSelf()
    {
        base.DefeatSelf();
        StateMachine.ChangeState(deathState);
    }
}
