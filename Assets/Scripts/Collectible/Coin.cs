using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    private Rigidbody2D rb;
    private GameObject refToPlayer;

    private bool isPulled = false;
    private float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        refToPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public void Collect()
    {
        Debug.Log("Coin Collected");
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
    }

    public void setMove()
    {
        isPulled = true;
    }

    private void FixedUpdate()
    {
        if (isPulled)
        {
            Vector2 direction = (refToPlayer.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

}
