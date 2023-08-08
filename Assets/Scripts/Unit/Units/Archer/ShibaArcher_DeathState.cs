using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_DeathState : DeathState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_DeathState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
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
        if (Time.time > startTime + 1.5f)
        {
            base.LogicUpdate();
            stateMachine.ChangeState(shibaArcher.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
