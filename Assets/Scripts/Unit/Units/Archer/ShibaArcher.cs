using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher : Entity
{
    public ShibaArcher_MoveState moveState { get; private set; }
    public ShibaArcher_AttackState attackState { get; private set; }
    public ShibaArcher_DeathState deathState { get; private set; }
    public ShibaArcher_IdleState idleState { get; private set; }


    public ShibaArcher_Projectile weapon;
    public Transform AttackPoint;

    public override void Awake()
    {
        base.Awake();

        moveState = new ShibaArcher_MoveState(this, stateMachine, "Move", this);
        attackState = new ShibaArcher_AttackState(this, stateMachine, "Attack", this);
        deathState = new ShibaArcher_DeathState(this, stateMachine, "Death", this);
        idleState = new ShibaArcher_IdleState(this, stateMachine, "Idle", this);
    }

    private void OnEnable()
    {
        stateMachine.Initialize(idleState);
    }

    public override void Attack()
    {
        base.Attack();
        AudioManager.instance.Play("ArcherAttack", 7);
        enemy.GetDamage(damage);
    }

    private void ActivateProjectile()
    {
        weapon.Fire();
    }

    public override void KillSelf()
    {
        base.KillSelf();
        stateMachine.ChangeState(deathState);
    }


    /*    public override void CheckUpgrade()
        {
            base.CheckUpgrade();

            if (upgradePath == 1)
            {
                anim.SetFloat("AttackSpeed",1.5f);
                weapon.arrowSpeed = 1.5f;
                //Прокачка первого уровня выбранного пути

                if (subUpgradePath == 0) return;


                if (subUpgradePath == 1)
                {
                    //Прокачка первого варианта
                }
                else if (subUpgradePath == 2)
                {
                    //Прокачка второго варианта
                }
            }
            if (upgradePath == 2)
            {
                //Прокачка первого уровня выбранного пути

                if (subUpgradePath == 0) return;


                if (subUpgradePath == 1)
                {
                    //Прокачка первого варианта
                }
                else if (subUpgradePath == 2)
                {
                    //Прокачка второго варианта
                }
            }
        }*/
}
