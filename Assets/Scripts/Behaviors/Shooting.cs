using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : AbstractBehavior
{
    [SerializeField] List<Gun> guns;
    private int selectedGunId;

    protected override void Awake()
    {
        base.Awake();
        if(guns.Count > 0)
        {
            selectedGunId = 0;
        }
        shootAction.performed += ctx => ShootGun();
        swapWeapon.performed += ctx => SelectWeapon(ctx.ReadValue<float>());
    }

    void ShootGun()
    {
        guns[selectedGunId].Shoot();
    }
    void SelectWeapon(float mouseScroll)
    {
        if (mouseScroll > 0) {
            selectedGunId++;
        }
        else if (mouseScroll < 0)
        {
            selectedGunId--;
        }

        if(selectedGunId == guns.Count)
        {
            selectedGunId = 0;
        }
        else if (selectedGunId == -1)
        {
            selectedGunId = guns.Count - 1;
        }
    }
}
