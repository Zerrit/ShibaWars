using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_IdleState : IdleState
{
    protected ShibaOni shibaOni;
    public ShibaOni_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
    {
        this.shibaOni = shibaOni;
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
            stateMachine.ChangeState(shibaOni.deathState);
        }

        if (entity.neutralState)
        {
            if (entity.health.currentHealth < entity.health.maxHealth || entity.CheckEnemy(entity.entityData.checkEnemyDistance + 2f))
            {
                stateMachine.ChangeState(shibaOni.moveState);
                entity.neutralState = false;
            }
        }
        else
        {
            if (entity.CheckEnemy(entity.entityData.checkEnemyDistance))
            {
                stateMachine.ChangeState(shibaOni.attackState);
            }

            if (!entity.CheckWall())
            {
                stateMachine.ChangeState(shibaOni.moveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
