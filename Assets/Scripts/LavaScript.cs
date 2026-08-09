using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Player hit lava!");
                playerHealth.TakeDamage(100);
            }
        }
    }
}
