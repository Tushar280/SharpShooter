using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
