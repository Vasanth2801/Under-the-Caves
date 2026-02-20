using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount  = Mathf.Clamp((float)currentHealth / maxHealth, 0f, 1f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f; 
        Debug.Log("Player has died!");
    }
}