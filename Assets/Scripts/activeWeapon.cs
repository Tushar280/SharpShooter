using UnityEngine;

public class activeWeapon : MonoBehaviour
{
    Weapon weapon;
    [SerializeField] WeaponSO weaponSO;

    private void Start()
    {
        weapon = FindFirstObjectByType<Weapon>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            weaponSO.muzz.Play();
            weapon.Shoot(weaponSO);
        }
    }
    
}
