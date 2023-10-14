using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State // Стан погоні за гравцем
{
    private Enemy enemy;
    private string animationBoolName;

    public ChaseState(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName) : base(stateMachine, enemy, animationBoolName)
    {
        this.enemy = enemy;
        this.animationBoolName = animationBoolName;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("chase Enter");
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
            if (enemy.GetDistanceToTargetXY(enemy.target.transform.position) <= enemy.attackDistance)
            {
                enemy.StateMachine.ChangeState(enemy.attackState);
            }
            else if (enemy.GetDistanceToTargetXY(enemy.target.transform.position) > enemy.chaseDistance)
            {
                enemy.target = null;
                enemy.StateMachine.ChangeState(enemy.idleState);
            }
        }
        else
        {
            enemy.StateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // Тут Механіка погоні за гравцем
    }
}
