using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_DeathState : DeathState
{
    protected ShibaNinja shibaNinja;
    public Ninja_DeathState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
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

        if (Time.time > startTime + 1.5f)
        {
            base.LogicUpdate();
            stateMachine.ChangeState(shibaNinja.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
