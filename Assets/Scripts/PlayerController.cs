using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int maxHealth = 100;
    private int health;
    public int public_health
    {
        get { return health; }
        set
        {
            if(value > maxHealth || value < 0)
            {
                Debug.Log("You can't set player health to that!");
            }
            else
            {
                health = value;
            }
        }
    }

    float speed = 6;

    [SerializeField] Transform shotPos;
    Rigidbody2D rb;
    [SerializeField] HealthBarController healthBarScript;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBarScript.SetHealth(maxHealth);
        healthBarScript.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Attack();
        ManageHealth();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        FaceMovementDirection(horizontalInput);

        rb.AddForce(Vector2.right * horizontalInput * speed, ForceMode2D.Force);
        rb.AddForce(Vector2.up * verticalInput * speed, ForceMode2D.Force);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject2();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = shotPos.position;
            }
        }
    }

    void ManageHealth()
    {
        healthBarScript.SetHealth(health);
        Debug.Log("Health: " + health);
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
