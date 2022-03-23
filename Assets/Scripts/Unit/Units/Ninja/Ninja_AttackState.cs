using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_AttackState : AttackState
{
    protected ShibaNinja shibaNinja;
    public Ninja_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
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

        if (entity.enemy.col.enabled == false && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaNinja.moveState);
        }
        else if (entity.enemy.transform.position.x * entity.direction * -1 >= entity.transform.position.x * entity.direction * -1)
        {
            stateMachine.ChangeState(shibaNinja.moveState);
        }
        else if (entity.direction * -1 * entity.enemy.transform.position.x + entity.maxAttackRange <= entity.direction * -1 * entity.transform.position.x)
        {
            stateMachine.ChangeState(shibaNinja.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
