using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_StunState : StunState
{
    private ShibaSamurai shibaSamurai; 
    public ShibaSamurai_StunState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
