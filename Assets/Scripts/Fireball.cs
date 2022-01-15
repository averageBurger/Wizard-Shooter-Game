using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rb;

    Transform player;

    public DarkWizard wizard;

    [SerializeField] float speed = 12f;

    Vector2 direction;
    Vector2 playerPos;

    float angle;
    float despawnTime = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    private void OnEnable()
    {
        StartCoroutine(DespawnTimer());
    }

    void Update()
    {
        playerPos = (Vector2)player.position;
        direction = playerPos - (Vector2)transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        rb.velocity = (Vector2)direction.normalized * speed;
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wizard.Damage();
        }
        gameObject.SetActive(false);
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTime);
        gameObject.SetActive(false);
    }
}
