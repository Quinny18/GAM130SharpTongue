using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeraEnemy : MonoBehaviour
{
    [SerializeField]
    private int chimeraMaxHealth = 10;
    private int currentHealth;

    public static bool ChimeraenemyInvincible;
    public static float ChimerainvincibleTimer;

    // Update is called once per frame
    void Start()
    {
        currentHealth = chimeraMaxHealth;
    }

    void Update()
    {
        if (ChimeraenemyInvincible && ChimerainvincibleTimer >= 0)
        {
            ChimerainvincibleTimer -= Time.deltaTime;
        }
        else if (ChimerainvincibleTimer <= 0)
        {
            ChimeraenemyInvincible = false;
        }

        Debug.Log(ChimeraenemyInvincible);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public int TransferEnemyHP()
    {
        return currentHealth;
    }

    void Death()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
}
