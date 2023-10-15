using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackZone : MonoBehaviour
{
    public List<EnemyAI> enemyList = new List<EnemyAI>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {             
            enemyList.Add(collision.gameObject.GetComponent<EnemyAI>());
        }
    } 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject.GetComponent<EnemyAI>());
        }
    }
}
