using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Enemy
{
    protected override void Attack()
    {
        DealDamage(3);
        Destroy(gameObject);
    }

    protected override void Start()
    {
        EmaxHealth = 3;
        base.Start();
        speed = 4;
    }

    private void Update()
    {
        FacePlayersDirection();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
