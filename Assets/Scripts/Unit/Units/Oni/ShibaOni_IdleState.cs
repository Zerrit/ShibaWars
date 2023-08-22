using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_IdleState : IdleState
{
    protected ShibaOni shibaOni;
    public ShibaOni_IdleState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
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

        if (Time.time >= startTime + 0.5f && !BattleCommunicator.instance.CheckBarrier(shibaOni))
        {
            stateMachine.ChangeState(shibaOni.moveState);
        }
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();
    }
}
