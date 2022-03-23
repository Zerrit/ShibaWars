using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShibaNinja : Entity
{
    // ОСОБОЕ УМЕНИЕ
    public Button abilityButton;
    private Health abilityPrey;

    private bool isAbilityAvailable = true;
    private bool isAbilityRefreshed = false;


    public Ninja_MoveState moveState { get; private set; }
    public Ninja_AttackState attackState { get; private set; }
    public Ninja_DeathState deathState { get; private set; }
    public Ninja_IdleState idleState { get; private set; }
    public Ninja_AbilityState abilityState { get; private set; }


    public override void Start()
    {
        base.Start();
        moveState = new Ninja_MoveState(this, stateMachine, "Move", this);
        attackState = new Ninja_AttackState(this, stateMachine, "Attack", this);
        deathState = new Ninja_DeathState(this, stateMachine, "Death", this);
        idleState = new Ninja_IdleState(this, stateMachine, "Idle", this);
        abilityState = new Ninja_AbilityState(this, stateMachine, "Ability", this);

        if (neutralState) stateMachine.Initialize(idleState);
        else stateMachine.Initialize(moveState);

        StatsBuff();
    }

    
    public override void Update()
    {
        base.Update();

        CheckHealthLimit();
    }

    public override void Attack()
    {
        base.Attack();

        enemy.GetDamage(damage);
    }


    // Способность

    public void SearchFragileUnits()
    {
        if (!isAbilityAvailable) return;

        if (Physics2D.Raycast(transform.position, Vector2.right * direction, 18f, layerMaskEnemyFragileUnits))
        {
            abilityPrey = Physics2D.Raycast(transform.position, Vector2.right * direction, 18f, layerMaskEnemyFragileUnits).transform.GetComponent<Health>();
            abilityButton.animator.SetBool("ViewButton", true);
        }
        else
        {
            abilityButton.animator.SetBool("ViewButton", false);
        }
    }

    public override void StartAbilityState()
    {
        base.StartAbilityState();

        isAbilityAvailable = false;
        abilityButton.animator.SetBool("ViewButton", false);
        stateMachine.ChangeState(abilityState);
    }

    public void Assassinate()
    {
        abilityPrey.GetDamage(100);
    }



    //Адреналин

    public override void CheckHealthLimit()
    {
        if (upgradePath == 1 || isAbilityRefreshed) return;

        if (health.currentHealth <= health.maxHealth / 2)
        {
            isAbilityAvailable = true;
            isAbilityRefreshed = true;
        } 
            
    }


    // Прокачка

}
