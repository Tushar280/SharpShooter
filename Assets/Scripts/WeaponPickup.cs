using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    [SerializeField] WeaponSO weaponSO;
    activeWeapon activeWeapon;

    private void Start()
    {
        activeWeapon = FindAnyObjectByType<activeWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            //active weapon switch
            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(gameObject);
        }
    }
}
