using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_IdleState : IdleState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_IdleState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
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

        if (Time.time >= startTime + 0.7f) stateMachine.ChangeState(shibaArcher.moveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
