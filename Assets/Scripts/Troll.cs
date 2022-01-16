using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy //Inheritance
{
    Collider2D playerCollider;

    float attackSpeed = 2;

    protected override void Attack() // POLYMORPHISM
    {
        DealDamage(2); // ABSTRACTION
    }

    protected override void Start() // POLYMORPHISM
    {
        EmaxHealth = 6;
        base.Start();
        speed = 3;
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
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
