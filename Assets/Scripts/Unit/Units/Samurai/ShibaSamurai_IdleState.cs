using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_IdleState : IdleState
{
    protected ShibaSamurai shibaSamurai;
    public ShibaSamurai_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
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

        if (Time.time >= startTime + 0.7f) stateMachine.ChangeState(shibaSamurai.moveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
