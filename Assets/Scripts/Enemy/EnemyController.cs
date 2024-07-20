using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyController : CharController, IDamageable 
{   
    //enemy movement
    protected float enemyMoveSpeed = 3f;    
    protected GameObject refToPlayer;
    protected Rigidbody2D rb;
    public bool canMove = true;

    //enemy attack
    protected float damageAmount = .5f;
    protected float attackCooldown = .5f;
    protected bool canDealDamage = true;   

    protected virtual void Awake()
    {
        refToPlayer = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

    }
    protected override void Move()
    {
        if (canMove && refToPlayer != null)
        {
            Vector2 direction = refToPlayer.transform.position - transform.position;
            rb.velocity = direction.normalized * enemyMoveSpeed;
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(FlashEffect());
    }

    // enumartor for a flash effect when the enemy takes damage
    protected IEnumerator FlashEffect()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    // Method to deal damage to the player
    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDealDamage)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
                float playerCurrentHealth = player.CurrentHealth;
                Debug.Log($"Player took damage. Current health: {playerCurrentHealth}");
                StartCoroutine(AttackCooldown());
            }
        }
    }

    // Coroutine to handle the Attack cooldown
    protected IEnumerator AttackCooldown()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(attackCooldown);
        canDealDamage = true;
    }



}