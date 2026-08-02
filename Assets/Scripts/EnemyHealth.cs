using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 30;
    [SerializeField] ParticleSystem explo;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {

        Collider[] hitCollider = Physics.OverlapSphere(transform.position,3);
        foreach(Collider collider in hitCollider)
        {
            PlayerHealth ph = collider.gameObject.GetComponent<PlayerHealth>();
            ph?.TakeDamage(40);
            EnemyHealth eh = collider.gameObject.GetComponent<EnemyHealth>();
            eh?.TakeDamage(30);
        }

        ParticleSystem ExploVFX = Instantiate(explo,transform.position,Random.rotation);
        Destroy(gameObject);
        Destroy(ExploVFX.gameObject, 1f);
    }
}
