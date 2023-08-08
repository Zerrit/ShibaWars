using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSlave_MoveState : MoveState
{
    protected ShibaSlave shibaSlave;
    public ShibaSlave_MoveState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSlave shibaSlave) : base(entity, stateMachine, animBoolName)
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

/*        if (entity.health.currentHealth <= 0)
        {
            stateMachine.ChangeState(shibaSlave.deathState);
        }

        if (shibaSlave.CheckMine() && !shibaSlave.isHaveGold)
        {
            stateMachine.ChangeState(shibaSlave.hiddenState);
            shibaSlave.anim.SetBool("IsHaveGold", true);
        }

        if (shibaSlave.isHaveGold && -1 * shibaSlave.direction * shibaSlave.transform.position.x <= -1 * shibaSlave.direction * shibaSlave.CastlePos.x)
        {
            stateMachine.ChangeState(shibaSlave.hiddenState);
            shibaSlave.anim.SetBool("IsHaveGold", false);
            shibaSlave.mainTowerGold.gold += shibaSlave.goldIncrease;
        }

        if (entity.CheckWall())
        {
            stateMachine.ChangeState(shibaSlave.idleState);
        }

        if (shibaSlave.CheckEnemyWall())
        {
            stateMachine.ChangeState(shibaSlave.idleState);
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
