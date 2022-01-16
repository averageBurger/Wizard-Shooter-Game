using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Enemy //Inheritance
{
    protected override void Attack() // POLYMORPHISM
    {
        DealDamage(3); // ABSTRACTION
        Destroy(gameObject);
    }

    protected override void Start() // POLYMORPHISM
    {
        EmaxHealth = 8;
        base.Start();
        speed = 4;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(); // ABSTRACTION
        }
    }
}
