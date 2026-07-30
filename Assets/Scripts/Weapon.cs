using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] RaycastHit hit;
    

    [Header("VFX")]
    
    [SerializeField] ParticleSystem hit1;

    public void Shoot(WeaponSO weaponSO)
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {   
                Instantiate(hit1,hit.point,Random.rotation);
                EnemyHealth em = hit.transform.gameObject.GetComponent<EnemyHealth>();
                em?.TakeDamage(weaponSO.damage);
                
            }
    }
}
