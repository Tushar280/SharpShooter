using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject DieUI;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Player died!");
            DieUI.SetActive(true);
            // 1. Disable player movement
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

    public void Update()
    {
        healthText.text = health.ToString();
    }
}
