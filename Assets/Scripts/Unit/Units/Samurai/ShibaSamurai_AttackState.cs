using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_AttackState : AttackState
{
    protected ShibaSamurai shibaSamurai;
    public ShibaSamurai_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
    {
        this.shibaSamurai = shibaSamurai;
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
            stateMachine.ChangeState(shibaSamurai.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
