using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai : Entity
{
    public ShibaSamurai_IdleState idleState { get; private set; }
    public ShibaSamurai_MoveState moveState { get; private set; }
    public ShibaSamurai_AttackState attackState { get; private set; }
    public ShibaSamurai_StunState stunState { get; private set; }
    public ShibaSamurai_DeathState deathState { get; private set; }


    public override void Start()
    {
        base.Start();
        idleState = new ShibaSamurai_IdleState(this, stateMachine, "Idle", this);
        moveState = new ShibaSamurai_MoveState(this, stateMachine, "Move", this);
        stunState = new ShibaSamurai_StunState(this, stateMachine, "Stun", this);
        attackState = new ShibaSamurai_AttackState(this, stateMachine, "Attack", this);
        deathState = new ShibaSamurai_DeathState(this, stateMachine, "Death", this);

        if (neutralState) stateMachine.Initialize(idleState);
        else stateMachine.Initialize(moveState);
    }

    public override void Attack()
    {
        base.Attack();
        AudioManager.instance.Play("SamuraiAttack", 5);
        enemy.GetDamage(damage);
    }



}
