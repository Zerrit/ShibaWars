using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FinitStateMachine stateMachine;
    protected Unit entity;

    protected float startTime;

    protected string animBoolName;

    public State(Unit entity, FinitStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.UnitAnimator.SetBool(animBoolName,true); 
    }   

    public virtual void Exit()
    {
        entity.UnitAnimator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void ControlledUpdate()
    {

    }


}
