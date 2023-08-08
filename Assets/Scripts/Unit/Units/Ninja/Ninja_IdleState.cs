using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_IdleState : IdleState
{
    protected ShibaNinja shibaNinja;
    public Ninja_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
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

        if (Time.time >= startTime + 0.7f) stateMachine.ChangeState(shibaNinja.moveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
