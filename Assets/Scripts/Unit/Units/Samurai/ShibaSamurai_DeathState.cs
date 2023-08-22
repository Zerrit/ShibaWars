using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_DeathState : DeathState
{
    protected ShibaSamurai shibaSamurai;
    public ShibaSamurai_DeathState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
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
        if (Time.time > startTime + 1.5f)
        {
            base.LogicUpdate();
            stateMachine.ChangeState(shibaSamurai.idleState);
        }
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();
    }
}
