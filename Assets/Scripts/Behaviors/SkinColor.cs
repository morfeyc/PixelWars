using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColor : AbstractBehavior
{
    [SerializeField] public Color color = Color.white;
    SpriteRenderer sr;

    protected override void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.color = color;
    }
}
