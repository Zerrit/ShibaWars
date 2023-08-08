using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_AttackState : AttackState
{
    protected ShibaNinja shibaNinja;
    public Ninja_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
    {
        this.shibaNinja = shibaNinja;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (entity.enemy.IsDead == true && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaNinja.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
