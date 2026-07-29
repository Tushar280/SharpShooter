using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
