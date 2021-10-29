using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool isDead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public virtual void TakeHit(float damage, Vector2 hitPoint, Vector2 hitDirection)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();     
        if (rb != null)
        {
            rb.AddForce(hitDirection * damage / 10, ForceMode2D.Impulse);
        }
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        GameObject.Destroy(gameObject);
    }
}
