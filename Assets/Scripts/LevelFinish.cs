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
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("Next level is " + nextSceneIndex);
                //SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("No more levels! Returning to scene 0.");
                //SceneManager.LoadScene(0);
            }
        }
    }
}
