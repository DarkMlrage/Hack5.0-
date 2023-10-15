using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] AudioManager audioManager;

    [SerializeField] public float health;
    [SerializeField] private float damage;

    private Animator animator;
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(float dmg)
    {
        if (health <= 0) Die();

        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        playerAnimator.isTakeDamage();

        health -= dmg;

        audioManager.PlayRandomSound();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() // помиранн€ гравц€
    {
        SceneManager.LoadSceneAsync(1);
    }
}
