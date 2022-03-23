using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenState : State
{
    public HiddenState(Entity entity, FinitStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        entity.transform.Rotate(0, 180, 0);
        entity.direction *= -1;
        entity.col.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();

        entity.col.enabled = true;
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
