using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaOni : Entity
{
    public ShibaOni_MoveState moveState { get; private set; }
    public ShibaOni_AttackState attackState { get; private set; }
    public ShibaOni_DeathState deathState { get; private set; }
    public ShibaOni_IdleState idleState { get; private set; }


    public Transform AttackPoint;


    public override void Start()
    {
        base.Start();
        moveState = new ShibaOni_MoveState(this, stateMachine, "Move", this);
        attackState = new ShibaOni_AttackState(this, stateMachine, "Attack", this);
        deathState = new ShibaOni_DeathState(this, stateMachine, "Death", this);
        idleState = new ShibaOni_IdleState(this, stateMachine, "Idle", this);

        if (neutralState) stateMachine.Initialize(idleState);
        else stateMachine.Initialize(moveState);
    }

    public override void Attack()
    {
        base.Attack();
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right * direction, 6f, layerMaskEnemy);
        foreach(RaycastHit2D item in hit)
        {
            item.transform.gameObject.GetComponent<Health>().GetDamage(50);
        }
    }

}
