using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_AttackState : AttackState
{
    protected ShibaArcher shibaArcher;
    public ShibaArcher_AttackState(Unit entity, FinitStateMachine stateMachine, string animBoolName, ShibaArcher shibaArcher) : base(entity, stateMachine, animBoolName)
    {
        this.shibaArcher = shibaArcher;
    }

    public override void Enter()
    {
        base.Enter();

        shibaArcher.weapon.start = shibaArcher.AttackPoint.position;
        shibaArcher.weapon.enemy = entity.enemy.SelfTransform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (entity.enemy.IsDefeated == true && entity.attackFinished)
        {
            stateMachine.ChangeState(shibaArcher.moveState);
        }
    }

    public override void ControlledUpdate()
    {
        base.ControlledUpdate();
    }
}
