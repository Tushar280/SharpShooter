using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    [SerializeField] GameObject gameWonScreen;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Won");

            gameWonScreen.SetActive(true);

        }
    }
    
}
