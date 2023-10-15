using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected AtackZone atackZone;
    [SerializeField] protected AtackVisual atackVisual;

    protected PlayerAnimator playerAnimator;
    private void Awake()
    {
        playerAnimator= GetComponent<PlayerAnimator>();
    }

    public virtual void DealAtack(AtackZone atackZone)
    {
        Debug.Log("NoAtack");
    }

    public virtual void DealAtack()
    {
        Debug.Log("NoAtack");
    }
}
