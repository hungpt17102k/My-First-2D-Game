using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    private Transform player;

    private Vector2 moveDirection;
    private Rigidbody2D rigi;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigi = GetComponent<Rigidbody2D>();

        moveDirection = (player.position - transform.position).normalized * speed;

        rigi.velocity = new Vector2(moveDirection.x, moveDirection.y);

        DestroyBullet(5);
    }

    private void DestroyBullet(float time)
    {
        Destroy(gameObject, time);
    }

    // Nho de bullet la isTrigger = true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet(0);
        }
    }

}
