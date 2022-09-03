using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float invincibilityDurationAfterHit;

    public bool IsAlive => currentHealth > 0;

    public void Change(int amount)
    {
        if (invincibilityCooldown > 0 && amount < 0)
        {
            return;
        }

        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (amount < 0)
        {
            damagedThisFrame = true;
        }
    }

    private float invincibilityCooldown;
    private bool damagedThisFrame = false;

    private void Update()
    {
        if (damagedThisFrame)
        {
            invincibilityCooldown = invincibilityDurationAfterHit;
        }
        else if (invincibilityCooldown > 0)
        {
            invincibilityCooldown -= Time.deltaTime;
        }

        damagedThisFrame = false;
    }
}
