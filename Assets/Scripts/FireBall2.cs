using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall2 : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 10;

    Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 towardsMouse = mousePos - rb.position;
        float angle = Mathf.Atan2(towardsMouse.y, towardsMouse.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        direction = towardsMouse;
    }

    private void Update()
    {
        rb.velocity = direction.normalized * speed;
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.rotation = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
        gameObject.SetActive(false);
    }
}
