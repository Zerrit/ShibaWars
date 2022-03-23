using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaSlave : Entity
{
    public bool isHaveGold = false;
    public int goldIncrease = 30;

    private LayerMask layerMaskMine = 1 << 3;

    [HideInInspector]
    public Vector2 CastlePos;
    [HideInInspector]
    public MainTower mainTowerGold;

    public ShibaSlave_MoveState moveState { get; private set; }
    public ShibaSlave_DeathState deathState { get; private set; }
    public ShibaSlave_IdleState idleState { get; private set; }
    public ShibaSlave_HiddenState hiddenState { get; private set; }



    public override void Start()
    {
        base.Start();

        moveState = new ShibaSlave_MoveState(this, stateMachine, "Move", this);
        deathState = new ShibaSlave_DeathState(this, stateMachine, "Death", this);
        idleState = new ShibaSlave_IdleState(this, stateMachine, "Idle", this);
        hiddenState = new ShibaSlave_HiddenState(this, stateMachine, "Hidden", this);

        stateMachine.Initialize(moveState);
    }


    public bool CheckMine()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * direction, 1f, layerMaskMine))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckEnemyWall()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * direction, 3f, layerMaskEnemyWall))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
