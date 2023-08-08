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

        if (BattleCommunicator.instance.CheckEnemyTower(shibaNinja)) stateMachine.ChangeState(shibaNinja.attackState);
        if (BattleCommunicator.instance.CheckEnemy(shibaNinja)) stateMachine.ChangeState(shibaNinja.attackState);
        if (BattleCommunicator.instance.CheckBarrier(shibaNinja)) stateMachine.ChangeState(shibaNinja.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
