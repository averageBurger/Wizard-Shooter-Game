using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : Enemy
{
    [SerializeField] Collider2D tooCloseCheck;

    [SerializeField] Transform shotPos;

    Vector2 direction;

    float minAttackSpeed = 2;
    float maxAttackSpeed = 4;
    float angle;

    protected override void Attack()
    {
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = shotPos.position;
        }
        pooledProjectile.GetComponent<Fireball>().wizard = this;
    }

    protected override void Start()
    {
        base.Start();
        speed = -1;
        StartCoroutine(AttackTimer());
    }

    private void Update()
    {
        MoveEnemy();
        FacePlayersDirection();
    }

    public void Damage()
    {
        DealDamage(2);
    }

    protected override void MoveEnemy()
    {
        if (rb.IsTouching(tooCloseCheck))
        {
            direction = player.position - transform.position;
            rb.velocity = (Vector2)direction.normalized * speed;
        }
    }

    IEnumerator AttackTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minAttackSpeed, maxAttackSpeed));
            Attack();
        }
    }
}
