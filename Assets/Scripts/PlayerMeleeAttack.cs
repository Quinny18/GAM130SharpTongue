using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public int attackDamage = 1;

    float attackRate = 1f;
    float nextAttackTime = 0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("EnemyLVL2"))
        {
            if (Time.time >= nextAttackTime && !ChimeraEnemy.ChimeraenemyInvincible)
            {
                ;
                collider.gameObject.GetComponentInParent<ChimeraEnemy>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1f / attackRate;
                ChimeraEnemy.ChimerainvincibleTimer = 0.5f;
                ChimeraEnemy.ChimeraenemyInvincible = true;
                Destroy(gameObject);
            }
        }

        else
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
