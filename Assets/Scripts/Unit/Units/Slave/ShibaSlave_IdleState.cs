using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSlave_IdleState : IdleState
{
    protected ShibaSlave shibaSlave;
    public ShibaSlave_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSlave shibaSlave) : base(entity, stateMachine, animBoolName)
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
/*
        if (entity.health.currentHealth <= 0)
        {
            stateMachine.ChangeState(shibaSlave.deathState);
        }

        if (!entity.CheckWall() && !shibaSlave.CheckEnemyWall())
        {
            stateMachine.ChangeState(shibaSlave.moveState);
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
