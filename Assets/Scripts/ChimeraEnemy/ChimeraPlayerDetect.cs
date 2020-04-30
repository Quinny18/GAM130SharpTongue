using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ChimeraPlayerDetect : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Spotted");
            gameObject.GetComponent<ChimeraEnemyPatrol>().enabled = false;
            gameObject.GetComponent<ChimeraEnemyAI>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<ChimeraEnemyPatrol>().enabled = true;
            gameObject.GetComponent<ChimeraEnemyAI>().enabled = false;
        }

    }
}