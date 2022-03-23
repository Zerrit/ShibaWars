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

        shibaNinja.SearchFragileUnits();

        if (entity.health.currentHealth <= 0)
        {
            stateMachine.ChangeState(shibaNinja.deathState);
        }

        if (entity.neutralState)
        {
            if (entity.health.currentHealth < entity.health.maxHealth || entity.CheckEnemy(entity.entityData.checkEnemyDistance + 2f))
            {
                stateMachine.ChangeState(shibaNinja.moveState);
                entity.neutralState = false;
            }
        }
        else
        {
            if (entity.CheckEnemy(entity.entityData.checkEnemyDistance))
            {
                stateMachine.ChangeState(shibaNinja.attackState);
            }

            if (!entity.CheckWall())
            {
                stateMachine.ChangeState(shibaNinja.moveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
