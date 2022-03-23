using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_AttackState : AttackState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
    {
        this.shibaArcher = shibaArcher;
    }

    public override void Enter()
    {
        base.Enter();

        shibaArcher.weapon.start = shibaArcher.AttackPoint.transform.position;
        shibaArcher.weapon.enemy = entity.enemy.transform;
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

        if (entity.enemy.col.enabled == false && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaArcher.moveState);
        }
        else if (entity.enemy.transform.position.x * entity.direction * -1 >= entity.transform.position.x * entity.direction * -1)
        {
            stateMachine.ChangeState(shibaArcher.moveState);
        }
        else if (entity.direction * -1 * entity.enemy.transform.position.x + entity.maxAttackRange <= entity.direction * -1 * entity.transform.position.x)
        {
            stateMachine.ChangeState(shibaArcher.moveState);
        }
        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
