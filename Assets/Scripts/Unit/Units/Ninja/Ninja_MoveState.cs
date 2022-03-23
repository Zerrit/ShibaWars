using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_MoveState : MoveState
{
    protected ShibaNinja shibaNinja;
    public Ninja_MoveState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
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

        if (entity.CheckEnemy(entity.entityData.checkEnemyDistance))
        {
            stateMachine.ChangeState(shibaNinja.attackState);
        }

        if (entity.CheckWall())
        {
            stateMachine.ChangeState(shibaNinja.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
