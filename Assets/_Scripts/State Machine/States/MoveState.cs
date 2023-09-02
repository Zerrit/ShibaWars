using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Unit entity, FinitStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
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

        entity.Move();
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();

        BattleCommunicator.instance.CheckAllies(entity);
    }
}
