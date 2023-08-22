using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_MoveState : MoveState
{
    protected ShibaNinja shibaNinja;
    public Ninja_MoveState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaNinja shibaNinja) : base(entity, stateMachine, animBoolName)
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
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();

        if (BattleCommunicator.instance.CheckEnemyBuilding(shibaNinja)) stateMachine.ChangeState(shibaNinja.attackState);
        if (BattleCommunicator.instance.CheckEnemy(shibaNinja)) stateMachine.ChangeState(shibaNinja.attackState);
        if (BattleCommunicator.instance.CheckBarrier(shibaNinja)) stateMachine.ChangeState(shibaNinja.idleState);
    }
}
