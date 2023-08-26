using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Health system class can be used for enemies players and other npcs. for now it's just used on player
public class HealthSystem : MonoBehaviour
{

    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    // Delegate to handle health changed and player death events
    public event Action<int, int> OnHealthChanged;
    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to damage the entity
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
