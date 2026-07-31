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
            ParticleSystem ExploVFX = Instantiate(explo,transform.position,Random.rotation);
            Destroy(gameObject);
            Destroy(ExploVFX.gameObject, 1f);
        }
    }
}
