using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Player : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private float damage;

    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        if (health <= 0) return;

        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        animator.SetTrigger("isTakingDamage");

        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() // помиранн€ гравц€
    {
        animator.SetBool("isDying", true);

    }
}
