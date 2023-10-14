using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State //Стан патрулювання
{
    private Enemy enemy;
    private string animationBoolName;
    public MoveState(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName) : base(stateMachine, enemy, animationBoolName)
    {
        this.enemy = enemy;
        this.animationBoolName = animationBoolName;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("move Enter");
        enemy.currentPoint = enemy.pointsPos[enemy.pointIndex];
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (enemy.target != null)
        {
            enemy.StateMachine.ChangeState(enemy.chaseState);
        }

        if (enemy.GetDistanceToTargetXY(enemy.currentPoint.position) <= 1f)
        {
            enemy.StateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // Тут механіка руху до поінтів
    }



}
