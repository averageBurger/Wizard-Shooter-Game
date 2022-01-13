using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int maxHealth = 10;
    private int health;
    public int public_health
    {
        get { return health; }
        set
        {
            if(value > maxHealth || value < 0)
            {
                Debug.Log("You can't set health to that!");
            }
            else
            {
                health = value;
            }
        }
    }

    float speed = 5;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log("Health: " + health);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(Vector2.right * horizontalInput * speed, ForceMode2D.Force);
        rb.AddForce(Vector2.up * verticalInput * speed, ForceMode2D.Force);
    }
}
