using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerAnimator playerAnimator;


    [SerializeField] public float health;
    [SerializeField] private float damage;

    private Animator animator;
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        if (health <= 0) Die();

        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        playerAnimator.isTakeDamage();

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
