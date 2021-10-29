using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : Projectile
{
    [SerializeField] TrailRenderer tr;
    protected override void Start()
    {
        base.Start();

        if (!tr)
        {            
            tr = GetComponent<TrailRenderer>();
        }        
    }

    public override void ChangeColor(Color color)
    {
        base.ChangeColor(color);

        tr.startColor = color;
        color.a = 0.3f;
        tr.endColor = color;
    }
}