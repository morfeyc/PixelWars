using UnityEngine;
using UnityEngine.InputSystem;

public class Player : LivingEntity
{
	protected override void Start()
	{
		base.Start();
	}

	public override void TakeHit(float damage, Vector2 hitPoint, Vector2 hitDirection)
	{
		base.TakeHit(damage, hitPoint, hitDirection);
	}
}
