using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall2 : MonoBehaviour
{
    Rigidbody2D rb;

    int damage = 2;

    Vector2 mousePos;
    Vector2 towardsMouse;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        MoveTowardMouse(); // ABSTRACTION
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
            collision.gameObject.GetComponent<DamageDealer>().DealDamage(damage);
        }
        gameObject.SetActive(false);
    }

    void MoveTowardMouse()
    {
        towardsMouse = mousePos - rb.position;
        float angle = Mathf.Atan2(towardsMouse.y, towardsMouse.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.AddForce(this.transform.up, ForceMode2D.Impulse);
    }
}
