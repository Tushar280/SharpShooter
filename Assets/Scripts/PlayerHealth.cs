using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        }
        
    }

    public void Update()
    {
        healthText.text = health.ToString();
    }
}
