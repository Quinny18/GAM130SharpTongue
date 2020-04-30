using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConeAttackPoint : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Transform pivot;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pivot = transform.parent;
    }

    void Update()
    {
        Vector3 direction = player.position - pivot.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -180f;
        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
