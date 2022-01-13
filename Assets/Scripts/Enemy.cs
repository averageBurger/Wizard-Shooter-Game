using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    GameObject player;

    PlayerController playerScript;

    Rigidbody2D rb;

    float speed;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    protected void MoveEnemy(float maxDistance)
    {
        Vector2 targetPos = (Vector2)player.transform.position;
        Vector2.MoveTowards((Vector2)transform.position, targetPos, maxDistance);
    }

    /// <summary>
    /// Makes the enemy attack the player.
    /// </summary>
    protected abstract void Attack();

    protected void DealDamage(int damage)
    {
        playerScript.public_health -= damage;
    }

    protected void Die()
    {

    }
}
