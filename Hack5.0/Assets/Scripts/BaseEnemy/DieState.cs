using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private Enemy enemy;
    private float waitTime;
    private string animationBoolName;
    public DieState(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName) : base(stateMachine, enemy, animationBoolName)
    {
        this.enemy = enemy;
        this.animationBoolName = animationBoolName;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("die Enter");
        enemy.Die();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
