using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher : Unit
{
    [Header("Звуковые эффекты юнита")]
    [SerializeField] private ArcherSFX _archerSFX;
    [Header("Визуальные эффекты юнита")]
    [SerializeField] private ArcherVFX _archerVFX;



    public ShibaArcher_MoveState moveState { get; private set; }
    public ShibaArcher_AttackState attackState { get; private set; }
    public ShibaArcher_DeathState deathState { get; private set; }
    public ShibaArcher_IdleState idleState { get; private set; }


    public ShibaArcher_Projectile weapon;
    public Transform AttackPoint;

    public override void Awake()
    {
        base.Awake();

        moveState = new ShibaArcher_MoveState(this, StateMachine, "Move", this);
        attackState = new ShibaArcher_AttackState(this, StateMachine, "Attack", this);
        deathState = new ShibaArcher_DeathState(this, StateMachine, "Death", this);
        idleState = new ShibaArcher_IdleState(this, StateMachine, "Idle", this);

        _unitSFX = _archerSFX;
        _unitVFX = _archerVFX;
    }

    public override void Run()
    {
        base.Run();
        StateMachine.Initialize(idleState);
    }
/*    private void OnEnable()
    {
        StateMachine.Initialize(idleState);
    }*/

    public override void Attack()
    {
        base.Attack();

        enemy.GetDamage(damage);
    }

    private void ActivateProjectile()
    {
        weapon.Fire();
    }

    public override void DefeatSelf()
    {
        base.DefeatSelf();
        StateMachine.ChangeState(deathState);
    }
}
