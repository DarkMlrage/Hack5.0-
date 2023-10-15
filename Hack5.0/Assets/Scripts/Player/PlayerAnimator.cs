using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;    
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] float damageTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    public void isTakeDamage()
    {
        StartCoroutine(Delay());
    }

    public void isMoving(bool value)
    {
        animator.SetBool("isMoving", value);
    }
    public void isAtacking()
    {
        animator.SetTrigger("isAtacking");
    }


    private IEnumerator Delay()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageTime);
        spriteRenderer.color = Color.white;
    }
}
