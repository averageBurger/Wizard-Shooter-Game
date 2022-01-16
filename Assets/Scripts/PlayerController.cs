using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int maxHealth = 60;
    private int health;
    public int public_health // ENCAPSULATION
    {
        get { return health; }
        set
        {
            if (value < 0)
            {
                Debug.Log("You can't set player health to that! Setting it to 0.");
                health = 0;
            }
            else if (value > maxHealth)
            {
                Debug.Log("You can't set player health to that! Setting it to max health.");
                health = maxHealth;
            }
            else
            {
                health = value;
            }
        }
    }

    public int score = 0;

    float speed = 6;
    float attackSpeed = 1;

    bool canShoot = true;
    public bool gameOver = false;

    [SerializeField] Transform shotPos;
    Rigidbody2D rb;
    [SerializeField] HealthBarController healthBarScript;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverText;

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
        if (!gameOver)
        {
            ManageHealth(); // ABSTRACTION
            Attack(); // ABSTRACTION
            scoreText.text = "Score: " + score;
        }
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            Move(); // ABSTRACTION
        }
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject2();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = shotPos.position;
                canShoot = false;
                StartCoroutine(ReloadTimer());
            }
        }
    }

    void ManageHealth()
    {
        healthBarScript.SetHealth(health);
        if (health == 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);
        }
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

    IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(attackSpeed);
        canShoot = true;
    }
}
