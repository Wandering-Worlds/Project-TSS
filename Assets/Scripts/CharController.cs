using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharController : MonoBehaviour
{
    protected float moveSpeed = 5f;
    protected int maxHealth = 100;
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Move();
}