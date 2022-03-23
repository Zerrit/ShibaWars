using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_AttackState : AttackState
{
    protected ShibaOni shibaOni;
    public ShibaOni_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
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

        if (entity.enemy.col.enabled == false && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaOni.moveState);
        }
        else if (entity.enemy.transform.position.x * entity.direction * -1 >= entity.transform.position.x * entity.direction * -1)
        {
            stateMachine.ChangeState(shibaOni.moveState);
        }
        else if (entity.direction * -1 * entity.enemy.transform.position.x + entity.maxAttackRange <= entity.direction * -1 * entity.transform.position.x)
        {
            stateMachine.ChangeState(shibaOni.moveState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
