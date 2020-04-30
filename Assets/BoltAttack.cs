using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltAttack : MonoBehaviour
{
    public GameObject enemy;

    public int attackDamage = 1;

    float attackRate = 1f;
    float nextAttackTime = 0f;
    

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("EnemyLVL2"))
        {
            if (Time.time >= nextAttackTime && !ChimeraEnemy.ChimeraenemyInvincible)
            {
                enemy = collider.gameObject;
                enemy.GetComponentInParent<ChimeraEnemy>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1f / attackRate;
                ChimeraEnemy.ChimerainvincibleTimer = 0.5f;
                ChimeraEnemy.ChimeraenemyInvincible = true;
                Destroy(gameObject);
            }

        }
        else if (collider.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        else
        {
            //Do nothing
        }
    }
}
