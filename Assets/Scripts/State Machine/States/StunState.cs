using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    protected bool isStunTimeOver;

    public StunState(Entity entity, FinitStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        /*if(Time.time >= startTime + entity.entityData.stunTime)
        {
            isStunTimeOver = true;
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
