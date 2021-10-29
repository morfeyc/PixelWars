using UnityEngine;

public class Movement : AbstractBehavior
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float smoothTime = 1.5f;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    private void FixedUpdate()
    {
        Move(moveAction.ReadValue<Vector2>() * moveSpeed);
    }

    void Move(Vector2 direction)
    {
        currentInputVector = Vector2.SmoothDamp(currentInputVector, direction, ref smoothInputVelocity, smoothTime);

        rb2d.velocity = currentInputVector;
    }
}
