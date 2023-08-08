using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni_AttackState : AttackState
{
    protected ShibaOni shibaOni;
    public ShibaOni_AttackState(Entity entity, FinitStateMachine stateMachine, string animBoolName, ShibaOni shibaOni) : base(entity, stateMachine, animBoolName)
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

        if (entity.enemy.IsDead == true && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaOni.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
