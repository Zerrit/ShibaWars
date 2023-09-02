using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShibaNinja : Unit
{
    [Header("Звуковые эффекты юнита")]
    [SerializeField] private NinjaSFX _ninjaSFX;
    [Header("Визуальные эффекты юнита")]
    [SerializeField] private NinjaVFX _ninjaVFX;

    public Ninja_MoveState moveState { get; private set; }
    public Ninja_AttackState attackState { get; private set; }
    public Ninja_DeathState deathState { get; private set; }
    public Ninja_IdleState idleState { get; private set; }
    public Ninja_AbilityState abilityState { get; private set; }


    public override void Awake()
    {
        base.Awake();

        moveState = new Ninja_MoveState(this, StateMachine, "Move", this);
        attackState = new Ninja_AttackState(this, StateMachine, "Attack", this);
        deathState = new Ninja_DeathState(this, StateMachine, "Death", this);
        idleState = new Ninja_IdleState(this, StateMachine, "Idle", this);
        abilityState = new Ninja_AbilityState(this, StateMachine, "Ability", this);

        _unitSFX = _ninjaSFX;
        _unitVFX = _ninjaVFX;
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
