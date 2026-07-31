using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(activeWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }

}
