using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai_MoveState : MoveState
{
    private ShibaSamurai shibaSamurai;
    public ShibaSamurai_MoveState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaSamurai shibaSamurai) : base(entity, stateMachine, animBoolName)
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
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();

        if (BattleCommunicator.instance.CheckEnemyBuilding(shibaSamurai)) stateMachine.ChangeState(shibaSamurai.attackState);
        if (BattleCommunicator.instance.CheckEnemy(shibaSamurai)) stateMachine.ChangeState(shibaSamurai.attackState);
        if (BattleCommunicator.instance.CheckBarrier(shibaSamurai)) stateMachine.ChangeState(shibaSamurai.idleState);
    }
}
