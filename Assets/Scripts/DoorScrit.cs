using UnityEngine;

public class DoorScrit : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    void Update()
    {
        int remainEny = GameObject.FindGameObjectsWithTag(enemyTag).Length;
        
        if (remainEny == 0)
        {
            Debug.Log("All enemies killed. Opening door.");
            Destroy(gameObject);
        }
    }
}
