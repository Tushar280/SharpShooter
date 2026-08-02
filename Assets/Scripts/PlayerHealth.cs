using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] TMP_Text healthText;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            SelfDestroy();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        healthText.text = health.ToString();
    }
}
