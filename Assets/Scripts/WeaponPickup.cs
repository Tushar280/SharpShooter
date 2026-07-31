using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    WeaponSO weaponSO;
    activeWeapon activeWeapon;

    private void Start()
    {
        activeWeapon = FindFirstObjectByType<ActiveWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            //active weapon switch
            activeWeapon.SwitchWeapon(weaponSO);
        }
    }
}
