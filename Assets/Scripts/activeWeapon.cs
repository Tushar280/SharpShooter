using UnityEngine;

public class activeWeapon : MonoBehaviour
{
    Weapon weapon;
    [SerializeField] WeaponSO weaponSO;

    float initTime;

    private void Start()
    {
        weapon = FindFirstObjectByType<Weapon>();
        initTime = 0;
    }

    private void Update()
    {
        initTime += Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(initTime >= weaponSO.firerate)
            {
                weaponSO.muzz.Play();
                weapon.Shoot(weaponSO);
                initTime = 0;
            }
            
        }
        
    }
    
}
