using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level Finished!");
            // script to load next level
            //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
