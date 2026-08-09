using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenuScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuMain()
    {
        SceneManager.LoadScene(0);
    }
}
