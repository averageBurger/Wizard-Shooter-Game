using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform player;

    PlayerController playerScript;

    protected Rigidbody2D rb;

    protected float speed;

    private int EmaxHealth;
    private int Ehealth;
    public int Epublic_health
    {
        get { return Ehealth; }
        set
        {
            if (value > EmaxHealth || value < 0)
            {
                Debug.Log("You can't set health to that!");
            }
            else
            {
                Ehealth = value;
            }
        }
    }

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        player = GameObject.Find("Player").transform;
        playerScript = player.GetComponent<PlayerController>();
        Ehealth = EmaxHealth;
    }

    protected virtual void MoveEnemy()
    {
        Vector2 targetPos = (Vector2)player.position;
        rb.AddForce((targetPos - (Vector2)transform.position).normalized * speed);
    }

    /// <summary>
    /// Makes the enemy attack the player.
    /// </summary>
    protected abstract void Attack();

    protected void DealDamage(int damage)
    {
        playerScript.public_health -= damage;
    }

    protected void FacePlayersDirection()
    {
        Vector2 direction = player.position - transform.position;
        if (direction.x > 0)
        {
            transform.rotation = new Quaternion(0, 180, transform.rotation.z, 0);
        }
        else if (direction.x < 0)
        {
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, 0);
        }
    }
}
