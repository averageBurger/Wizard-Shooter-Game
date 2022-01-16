using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform player;

    protected PlayerController playerScript;

    protected Rigidbody2D rb;

    protected float speed;

    protected int EmaxHealth;
    private int Ehealth;
    public int Epublic_health // ENCAPSULATION
    {
        get { return Ehealth; }
        set
        {
            if (value < 0)
            {
                Debug.Log("You can't set enemy health to that! Setting it to 0.");
                Ehealth = 0;
            }
            else if(value > EmaxHealth)
            {
                Debug.Log("You can't set enemy health to that! Setting it to max health.");
                Ehealth = EmaxHealth;
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

    protected virtual void Update()
    {
        if (!playerScript.gameOver)
        {
            FacePlayersDirection(); // ABSTRACTION
            CheckIfDead(); // ABSTRACTION
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!playerScript.gameOver)
        {
            MoveEnemy(); // ABSTRACTION
        }
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

    protected void CheckIfDead()
    {
        if (Ehealth == 0)
        {
            Destroy(gameObject);
            playerScript.score += 1;
        }
    }
}
