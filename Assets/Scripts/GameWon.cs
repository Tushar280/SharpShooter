using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameWon : MonoBehaviour
{
    [SerializeField] GameObject gameWonScreen;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Won");

            gameWonScreen.SetActive(true);

            FirstPersonController fpc = GetComponent<FirstPersonController>();
            if (fpc != null) fpc.enabled = false;
            // 2. Disable weapon shooting
            activeWeapon weapon = GetComponent<activeWeapon>();
            if (weapon != null) weapon.enabled = false;
            // 3. Unlock and show cursor for UI buttons
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
    
}
