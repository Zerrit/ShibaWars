using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_IdleState : IdleState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
    {
        this.shibaArcher = shibaArcher;
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
            stateMachine.ChangeState(shibaArcher.deathState);
        }

        if (entity.neutralState)
        {
            if (entity.health.currentHealth < entity.health.maxHealth || entity.CheckEnemy(entity.entityData.checkEnemyDistance + 2f))
            {
                stateMachine.ChangeState(shibaArcher.moveState);
                entity.neutralState = false;
            }
        }
        else
        {
            if (entity.CheckEnemy(entity.entityData.checkEnemyDistance))
            {
                stateMachine.ChangeState(shibaArcher.attackState);
            }

            if (!entity.CheckWall())
            {
                stateMachine.ChangeState(shibaArcher.moveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
