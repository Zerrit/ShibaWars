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

        if (entity.health.currentHealth <= 0)
        {
            stateMachine.ChangeState(shibaSamurai.deathState);
        }

        if (entity.neutralState)
        {
            if (entity.health.currentHealth < entity.health.maxHealth || entity.CheckEnemy(entity.entityData.checkEnemyDistance + 2f))
            {
                stateMachine.ChangeState(shibaSamurai.moveState);
                entity.neutralState = false;
            }
        }
        else
        {
            if (entity.CheckEnemy(entity.entityData.checkEnemyDistance))
            {
                stateMachine.ChangeState(shibaSamurai.attackState);
            }

            if (!entity.CheckWall())
            {
                stateMachine.ChangeState(shibaSamurai.moveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
