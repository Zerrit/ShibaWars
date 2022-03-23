using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_AttackState : AttackState
{
    protected ShibaSamurai shibaSamurai;
    public ShibaSamurai_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
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

        if (entity.enemy.col.enabled == false && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaSamurai.moveState);
        }
        else if (entity.enemy.transform.position.x * entity.direction * -1 >= entity.transform.position.x * entity.direction * -1)
        {
            stateMachine.ChangeState(shibaSamurai.moveState);
        }
        else if (entity.direction * -1 * entity.enemy.transform.position.x + entity.maxAttackRange <= entity.direction * -1 * entity.transform.position.x)
        {
            stateMachine.ChangeState(shibaSamurai.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
