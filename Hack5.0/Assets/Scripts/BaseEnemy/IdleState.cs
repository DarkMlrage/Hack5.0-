using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State // Спокійний стан
{
    private Enemy enemy;
    private float waitTime;
    private string animationBoolName;
    public IdleState(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName) : base(stateMachine, enemy, animationBoolName)
    {
        this.enemy = enemy;
        this.animationBoolName = animationBoolName;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("idle Enter");
        waitTime = Random.Range(2f, 5f);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= StartTime + waitTime)
        {
            enemy.ChangePoint();
            enemy.StateMachine.ChangeState(enemy.moveState);
        }

        if (enemy.target != null)
        {
            enemy.StateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
