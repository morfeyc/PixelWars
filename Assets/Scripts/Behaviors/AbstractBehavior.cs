using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbstractBehavior : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected PlayerInput playerInput;

    [Header("Actions")]
    protected InputAction shootAction;
    protected InputAction moveAction;
    protected InputAction swapWeapon;

    protected virtual void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        if (!playerInput)
        {
            playerInput = GetComponentInParent<PlayerInput>();
        }
        rb2d = GetComponent<Rigidbody2D>();

        shootAction = playerInput.actions["Shoot"];
        moveAction = playerInput.actions["Move"];
        swapWeapon = playerInput.actions["SwapWeapon"];
    }
}
