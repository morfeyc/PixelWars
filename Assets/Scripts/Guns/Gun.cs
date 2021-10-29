using Assets.Scripts.Inerfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IShootable
{
    private SkinColor skinColor;
    protected GameObject projectilePrefab;
    protected Transform projectileSpawnPosition;
    protected virtual void Awake()
    {
        skinColor = GetComponentInParent<SkinColor>();
    }

    public virtual void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
        IProjectile projectileScript = projectile.GetComponent<IProjectile>();

        if(projectileScript != null)
        {
            projectileScript.ChangeColor(skinColor.color);
            projectileScript.SetParent(transform.parent.gameObject);
        }
    }
}
