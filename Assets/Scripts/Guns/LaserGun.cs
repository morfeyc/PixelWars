using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun
{
    [Header("Laser Prefab")]
    [SerializeField] private GameObject laserPrefab;

    [Header("LaserProjectile spawn point")]
    [SerializeField] private Transform leftLaserSpawn;
    [SerializeField] private Transform rightLaserSpawn;
    bool isLeftLaser = true;
    
    protected override void Awake()
    {
        base.Awake();
        projectilePrefab = laserPrefab;
        projectileSpawnPosition = leftLaserSpawn;
    }
    public override void Shoot()
    {
        if (isLeftLaser)
        {            
            base.Shoot();
            projectileSpawnPosition = rightLaserSpawn;
        }
        else
        {
            base.Shoot();
            projectileSpawnPosition = leftLaserSpawn;
        }
        isLeftLaser = !isLeftLaser;
    }
}
