using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightDetect : MonoBehaviour
{
    public bool bossEngaged = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            bossEngaged = true;
            Debug.Log("Boss Engaged");
        }
    }
}
