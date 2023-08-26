using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles other player compoments like damageTaken and win, can also be used to see other interactions
public class PlayerController : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();

        // Subscribe to the events
        healthSystem.OnHealthChanged += HandleHealthChanged;
        healthSystem.OnDeath += HandleDeath;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Logger.Debug) Logger.Log("Player collided with enemy");

            healthSystem.TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.EndGame(GameManager.GameResult.Won);
        }
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void HandleDeath()
    {
        GameManager.instance.EndGame(GameManager.GameResult.Lost);
    }
}
