using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni : Unit
{
    [Header("Звуковые эффекты юнита")]
    [SerializeField] private OniSFX _oniSFX;
    [Header("Визуальные эффекты юнита")]
    [SerializeField] private OniVFX _oniVFX;

    private List<Unit> enemies = new();

    public ShibaOni_MoveState moveState { get; private set; }
    public ShibaOni_AttackState attackState { get; private set; }
    public ShibaOni_DeathState deathState { get; private set; }
    public ShibaOni_IdleState idleState { get; private set; }


    public override void Awake()
    {
        base.Awake();

        moveState = new ShibaOni_MoveState(this, StateMachine, "Move", this);
        attackState = new ShibaOni_AttackState(this, StateMachine, "Attack", this);
        deathState = new ShibaOni_DeathState(this, StateMachine, "Death", this);
        idleState = new ShibaOni_IdleState(this, StateMachine, "Idle", this);

        _unitSFX = _oniSFX;
        _unitVFX = _oniVFX;
    }


    public override void Run()
    {
        base.Run();
        StateMachine.Initialize(idleState);
    }
 /*   private void OnEnable()
    {
        StateMachine.Initialize(idleState);
    }*/
    public override void Attack()
    {
        base.Attack();

        _oniVFX.PlayOnPlace(enemy.SelfTransform.position, _oniVFX.SlamFX);
        BattleCommunicator.instance.GetAllEnemies(this, ref enemies);
        foreach (Unit unit in enemies)
        {
            unit.GetDamage(damage);
        }
        enemies.Clear();
    }

    public override void DefeatSelf()
    {
        base.DefeatSelf();
        StateMachine.ChangeState(deathState);
    }
}
