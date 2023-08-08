using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_DeathState : DeathState
{
    protected ShibaOni shibaOni;
    public ShibaOni_DeathState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
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
        if (Time.time > startTime + 1.5f)
        {
            base.LogicUpdate();
            stateMachine.ChangeState(shibaOni.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
