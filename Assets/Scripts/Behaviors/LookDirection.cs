using UnityEngine;
using UnityEngine.InputSystem;

public class LookDirection : AbstractBehavior
{
    Camera viewCamera;
    protected override void Awake()
    {
        viewCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        Vector2 mouseScreenPostion = Mouse.current.position.ReadValue();
        Vector2 mousePos = viewCamera.ScreenToWorldPoint(mouseScreenPostion);

        Vector2 dir = mousePos - (Vector2)transform.position;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rot_z - 90, Vector3.forward);
    }
}
