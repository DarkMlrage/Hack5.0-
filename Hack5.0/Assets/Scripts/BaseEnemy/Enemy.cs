using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [field: SerializeField] public int health { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public float timeBeforeDestroy { get; private set; }

    [field: SerializeField] public int damage { get; private set; }
    [field: SerializeField] public float attackDistance { get; private set; }
    [field: SerializeField] public float chaseDistance { get; private set; } = 10f;
    [field: SerializeField] public float timeToAttack { get; private set; }
    

    private float TimerBetweenAttack = 0.5f;

    // система патрулювання до точок
    public List<Transform> pointsPos;
    public int pointIndex = 0;
    public Transform currentPoint { get; set; }

    public Player target { get; set; }
    public Rigidbody rb { get; private set; }
    public Animator animator { get; private set; }


    private Coroutine isAttackCoroutine;

    public IdleState idleState; //Спокійний стан
    public MoveState moveState; // Стан патрулювання
    public ChaseState chaseState; // Стан погоні за гравцем
    public AttackState attackState; //Стан атаки
    public DieState dieState; //Стан помирання

    public GameObject Element;
    public override void Start()
    {
        base.Start();

        pointsPos = new List<Transform>();
        foreach (var point in GameObject.FindGameObjectsWithTag("Point"))
        {
            pointsPos.Add(point.transform);
        }
        pointIndex = 0;

        if (GetComponent<Rigidbody>() != null) rb = GetComponent<Rigidbody>();
        else rb = gameObject.AddComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();

        // В "лапках" назва параметру, 
        // який відповідає потрібній для цього стану анімації в аніматорі
        idleState = new IdleState(StateMachine, this, "isIdle");
        moveState = new MoveState(StateMachine, this, "isRunning");
        chaseState = new ChaseState(StateMachine, this, "isRunning");
        attackState = new AttackState(StateMachine, this, "isAttacking");
        dieState = new DieState(StateMachine, this, "isDying");

        StateMachine.Initialize(idleState);
    }

    public void ChangePoint()
    {
        if (pointIndex >= pointsPos.Count - 1) pointIndex = 0;
        else pointIndex++;
    }

    public float GetDistanceToTargetXY(Vector3 target)
    {
        return Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.x, target.y));
    }

    public void Attack(string animBoolName)
    {
        if (Time.time >= TimerBetweenAttack)
        {
            TimerBetweenAttack = Time.time + timeToAttack;
            if (isAttackCoroutine != null)
            {
                StopCoroutine(isAttackCoroutine);
                isAttackCoroutine = null;
            }
            isAttackCoroutine = StartCoroutine(AttackCoroutine(animBoolName));
        }
    }

    IEnumerator AttackCoroutine(string animBoolName)
    {
        animator.SetTrigger(animBoolName);
        yield return new WaitForSeconds(timeToAttack - 1f);
        target.TakeDamage(damage);
        isAttackCoroutine = null;
    }

    public void TakeDamage(int dmg) // dmg = damage 
    {
        if (health <= 0) return;
        animator.SetTrigger("isTakingDamage");

        health -= dmg;

        if (health <= 0)
        {
            this.damage = 0;
            StateMachine.ChangeState(dieState);
        }
    }


    public void Die()
    {
        animator.SetBool("isDying", true);
        if(Element != null)
        {
            GameObject newElement = Instantiate(Element, transform.position, Quaternion.identity);
        }

        if (isAttackCoroutine != null)
        {
            StopCoroutine(isAttackCoroutine);
        }

        Destroy(gameObject, timeBeforeDestroy);
    }


    protected void OnDrawGizmos()
    {
    }
}
