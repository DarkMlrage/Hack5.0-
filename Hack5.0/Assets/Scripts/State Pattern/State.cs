using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine StateMachine;
    protected Enemy Enemy;

    protected string AnimationBoolName;
    protected float StartTime;

    public State(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName)
    {
        StateMachine = stateMachine;
        Enemy = enemy;
        AnimationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        Enemy.animator.SetBool(AnimationBoolName, true);
        StartTime = Time.time;
    }

    public virtual void Exit()
    {
        Enemy.animator.SetBool(AnimationBoolName, false);
    }

    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
}
