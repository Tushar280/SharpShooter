using UnityEngine;

public class activeWeapon : MonoBehaviour
{
    Weapon weapon;
    [SerializeField] WeaponSO weaponSO;
    GameObject currentWeaponInstance;

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
                weapon.Shoot(weaponSO);
                initTime = 0;
            }
            
        }
        
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Switched to weapon: " + weaponSO.name);

        if(weapon)
        {
            Destroy(weapon.gameObject);
        }
        Weapon NewWeapon = Instantiate(weaponSO.weaponPrefab,transform).GetComponent<Weapon>();
        weapon = NewWeapon;
        this.weaponSO = weaponSO;
    }
    
}
