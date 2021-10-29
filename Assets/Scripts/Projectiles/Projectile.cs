using Assets.Scripts;
using Assets.Scripts.Inerfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [Header("Parameters")]
    public float speed;
    public float damage;
    public float lifeTime;
    [HideInInspector] public Color color;

    [Header("")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] SpriteRenderer sr;
    private GameObject parent;
    protected virtual void Start()
    {
        if (!rb2d)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        if (!sr)
        {
            sr = GetComponent<SpriteRenderer>();
        }     

        rb2d.velocity = transform.up * speed;
        StartCoroutine(DestroyObject());
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != parent)
        {
            IDamageable damageableObject = col.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                Debug.Log($"{gameObject.name} hited {col.gameObject.name}");
                Debug.DrawRay(transform.position, transform.up, Color.yellow);
                damageableObject.TakeHit(damage, transform.position, transform.up);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public virtual void ChangeColor(Color color)
    {
        sr.color = color;
    }

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
    }
}
