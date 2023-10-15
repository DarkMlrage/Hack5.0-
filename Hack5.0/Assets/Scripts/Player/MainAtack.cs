using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAtack : Atack
{
    private List<EnemyAI> enemyToDestroy = new List<EnemyAI>();

    public override void DealAtack()
    {
        foreach (EnemyAI enemy in atackZone.enemyList)
        {
            enemy.TakeDamage(damage);

            if (enemy.currentHP <= 0)
            {
                enemyToDestroy.Add(enemy);
            }
        }

        for (int i = 0; i < enemyToDestroy.Count; i++)
        {
            enemyToDestroy[i].Die();
            enemyToDestroy.RemoveAt(i);
        }

        playerAnimator.isAtacking();
        atackVisual.Visiualize();
    }

}
