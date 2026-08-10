using UnityEngine;

public class DoorScrit : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    
    private bool enemiesHaveSpawned = false;
        
    void Update()
    {
        // Include inactive enemies when finding EnemyHealth scripts

        EnemyHealth[] enemies = FindObjectsByType<EnemyHealth>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (enemies.Length > 0)
        {
            enemiesHaveSpawned = true;
        }
        // Only destroy the door once enemies have been detected and then all defeated
        
        if (enemiesHaveSpawned && enemies.Length == 0)
        {
            Debug.Log("All enemies killed. Opening door.");
            Destroy(gameObject);
        }
    }
}
