using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy
{
    [SerializeField] Collider2D playerCollider;

    float attackSpeed = 2;

    protected override void Attack()
    {
        DealDamage(2);
    }

    protected override void Start()
    {
        base.Start();
        speed = 3;
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
            StartCoroutine(AttackTimer());
        }
    }

    IEnumerator AttackTimer()
    {
        while (rb.IsTouching(playerCollider))
        {
            Attack();
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
