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
        base.Start();
        speed = 4;
    }

    private void Update()
    {
        MoveEnemy();
        FacePlayersDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
