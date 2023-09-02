using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_IdleState : IdleState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_IdleState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
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

        if (Time.time >= startTime + 0.5f && !BattleCommunicator.instance.CheckBarrier(shibaArcher))
        {
            stateMachine.ChangeState(shibaArcher.moveState);
        }
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();
    }
}
