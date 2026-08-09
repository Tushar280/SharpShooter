using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level Finished!");
            // script
        }
    }
}
