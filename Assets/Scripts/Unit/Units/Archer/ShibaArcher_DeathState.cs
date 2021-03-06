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
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
