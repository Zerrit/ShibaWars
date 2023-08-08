using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_MoveState : MoveState
{
    protected ShibaOni shibaOni;
    public ShibaOni_MoveState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
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

        if (BattleCommunicator.instance.CheckEnemyTower(shibaOni)) stateMachine.ChangeState(shibaOni.attackState);
        if (BattleCommunicator.instance.CheckEnemy(shibaOni)) stateMachine.ChangeState(shibaOni.attackState);
        if (BattleCommunicator.instance.CheckBarrier(shibaOni)) stateMachine.ChangeState(shibaOni.idleState);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
