using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State // Стан атаки на гравця
{
    private Enemy enemy;
    private string animationBoolName;
    public AttackState(FiniteStateMachine stateMachine, Enemy enemy, string animationBoolName) : base(stateMachine, enemy, animationBoolName)
    {
        this.enemy = enemy;
        this.animationBoolName = animationBoolName;
    }

    public override void Enter()
    {
        StartTime = Time.time;

        Debug.Log("attack Enter");
    }
    public override void Exit()
    {
        enemy.StopAllCoroutines();
    }

    
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.target == null)
        {
            enemy.StateMachine.ChangeState(enemy.idleState);
        }
        else if (enemy.GetDistanceToTargetXY(enemy.target.transform.position) > enemy.attackDistance )
        {
            enemy.StateMachine.ChangeState(enemy.chaseState);
        }
        else
        {
            enemy.Attack(animationBoolName);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
