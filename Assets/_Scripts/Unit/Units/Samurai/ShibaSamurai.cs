using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSamurai : Unit
{
    [Header("Звуковые эффекты юнита")]
    [SerializeField] private SamuraiSFX _samuraiSFX;
    [Header("Визуальные эффекты юнита")]
    [SerializeField] private SamuraiVFX _samuraiVFX;

    public ShibaSamurai_IdleState idleState { get; private set; }
    public ShibaSamurai_MoveState moveState { get; private set; }
    public ShibaSamurai_AttackState attackState { get; private set; }
    public ShibaSamurai_DeathState deathState { get; private set; }


    public override void Awake()
    {
        base.Awake();

        idleState = new ShibaSamurai_IdleState(this, StateMachine, "Idle", this);
        moveState = new ShibaSamurai_MoveState(this, StateMachine, "Move", this);
        attackState = new ShibaSamurai_AttackState(this, StateMachine, "Attack", this);
        deathState = new ShibaSamurai_DeathState(this, StateMachine, "Death", this);

        _unitSFX = _samuraiSFX;
        _unitVFX = _samuraiVFX;
    }

    public override void Run()
    {
        base.Run();
        StateMachine.Initialize(idleState);
    }

    public override void Attack()
    {
        base.Attack();
        enemy.GetDamage(damage);
    }

    public override void DefeatSelf()
    {
        base.DefeatSelf();
        StateMachine.ChangeState(deathState);
    }
}
