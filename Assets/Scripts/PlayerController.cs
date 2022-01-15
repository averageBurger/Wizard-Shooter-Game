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
    }

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        Move();
        Debug.Log("Health: " + health);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        FaceMovementDirection(horizontalInput);

        rb.AddForce(Vector2.right * horizontalInput * speed, ForceMode2D.Force);
        rb.AddForce(Vector2.up * verticalInput * speed, ForceMode2D.Force);
    }

    void FaceMovementDirection(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.rotation = new Quaternion(0, 180, transform.rotation.z, 0);
        }
        else if (horizontal < 0)
        {
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, 0);
        }
    }
}
