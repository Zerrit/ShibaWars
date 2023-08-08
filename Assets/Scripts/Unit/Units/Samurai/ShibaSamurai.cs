using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai : Entity
{
    public ShibaSamurai_IdleState idleState { get; private set; }
    public ShibaSamurai_MoveState moveState { get; private set; }
    public ShibaSamurai_AttackState attackState { get; private set; }
    public ShibaSamurai_DeathState deathState { get; private set; }


    public override void Awake()
    {
        base.Awake();

        idleState = new ShibaSamurai_IdleState(this, stateMachine, "Idle", this);
        moveState = new ShibaSamurai_MoveState(this, stateMachine, "Move", this);
        attackState = new ShibaSamurai_AttackState(this, stateMachine, "Attack", this);
        deathState = new ShibaSamurai_DeathState(this, stateMachine, "Death", this);
    }

    private void OnEnable()
    {
        stateMachine.Initialize(idleState);
    }

    public override void Attack()
    {
        base.Attack();
        AudioManager.instance.Play("SamuraiAttack", 5);
        enemy.GetDamage(damage);
    }

    public override void KillSelf()
    {
        base.KillSelf();
        stateMachine.ChangeState(deathState);
    }

}
