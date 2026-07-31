using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] RaycastHit hit;
    [SerializeField] ParticleSystem muzz;

    [Header("VFX")]
    
    [SerializeField] ParticleSystem hit1;

    public void Shoot(WeaponSO weaponSO)
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {   
                muzz.Play();
                ParticleSystem hitVFX = Instantiate(hit1, hit.point, Random.rotation);
                Destroy(hitVFX.gameObject, 1f);
                EnemyHealth em = hit.transform.gameObject.GetComponent<EnemyHealth>();
                em?.TakeDamage(weaponSO.damage);
                
            }
    }
}
