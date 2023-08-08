using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_MoveState : MoveState
{
    protected ShibaArcher shibaArcher;

    public ShibaArcher_MoveState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
    {
        this.shibaArcher = shibaArcher;
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

        if (BattleCommunicator.instance.CheckEnemyTower(shibaArcher)) stateMachine.ChangeState(shibaArcher.attackState);
        if (BattleCommunicator.instance.CheckEnemy(shibaArcher)) stateMachine.ChangeState(shibaArcher.attackState);
        if (BattleCommunicator.instance.CheckBarrier(shibaArcher)) stateMachine.ChangeState(shibaArcher.idleState);
    }

    public override void PhysicsUpdate()    
    {
        base.PhysicsUpdate();
    }
}
