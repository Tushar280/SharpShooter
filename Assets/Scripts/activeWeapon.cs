using UnityEngine;

public class activeWeapon : MonoBehaviour
{
    Weapon currentWeapon;
    [SerializeField] WeaponSO weaponSO;

    float initTime;

    private void Start()
    {
        currentWeapon = FindFirstObjectByType<Weapon>();
        initTime = 0;
    }

    private void Update()
    {
        initTime += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(initTime >= weaponSO.firerate)
            {
                currentWeapon.Shoot(weaponSO);
                initTime = 0;
            }
            
        }
        
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Switched to weapon: " + weaponSO.name);
    }
    
}
