using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammo = 10;

    protected override void OnPickup(activeWeapon activeWeapon)
    {
        activeWeapon.ChangeAmmo(ammo);
    }

}
