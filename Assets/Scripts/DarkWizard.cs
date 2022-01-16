using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : Enemy //Inheritance
{
    Collider2D tooCloseCheck;

    [SerializeField] Transform shotPos;

    Vector2 direction;

    float minAttackSpeed = 2;
    float maxAttackSpeed = 4;
    float angle;

    protected override void Attack() // POLYMORPHISM
    {
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = shotPos.position;
            pooledProjectile.GetComponent<Fireball>().wizard = this;
        }
    }

    protected override void Start() // POLYMORPHISM
    {
        EmaxHealth = 5;
        base.Start();
        speed = -1;
        tooCloseCheck = GameObject.Find("StayAway!").GetComponent<Collider2D>();
        StartCoroutine(AttackTimer());
    }

    public void Damage()
    {
        DealDamage(2); // ABSTRACTION
    }

    protected override void MoveEnemy() // POLYMORPHISM
    {
        if (rb.IsTouching(tooCloseCheck))
        {
            direction = player.position - transform.position;
            rb.velocity = (Vector2)direction.normalized * speed;
        }
    }

    IEnumerator AttackTimer()
    {
        while (!playerScript.gameOver)
        {
            yield return new WaitForSeconds(Random.Range(minAttackSpeed, maxAttackSpeed));
            Attack();
        }
    }
}
