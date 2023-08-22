using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShibaNinja : Unit
{
    // нянане слемхе
    //public Button abilityButton;
    //private Entity abilityPrey;

    //private bool isAbilityAvailable = true;
    //private bool isAbilityRefreshed = false;


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
    }

    private void OnEnable()
    {
        StateMachine.Initialize(idleState);
    }

    public override void Update()
    {
        base.Update();

        //CheckHealthLimit();
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
