using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSlave_DeathState : DeathState
{
    protected ShibaSlave shibaSlave;
    public ShibaSlave_DeathState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSlave shibaSlave) : base(entity, stateMachine, animBoolName)
    {
        this.shibaSlave = shibaSlave;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
