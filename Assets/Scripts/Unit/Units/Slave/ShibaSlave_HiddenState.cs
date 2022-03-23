using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSlave_HiddenState : HiddenState
{
    protected ShibaSlave shibaSlave;
    public ShibaSlave_HiddenState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaSlave shibaSlave) : base(entity, stateMachine, animBoolName)
    {
        this.shibaSlave = shibaSlave;
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

        if (Time.time > startTime + 2f)
        {
            shibaSlave.isHaveGold = !shibaSlave.isHaveGold;
            stateMachine.ChangeState(shibaSlave.moveState);
            //entity.col.enabled = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
