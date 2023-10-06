using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;

    public float currentHealth;

    public event EventHandler HealthChanged;
    public event EventHandler Die;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        RaiseHealthChanged();
    }

    public bool AddHealth(float amount)
    {
        if (currentHealth >= maxHealth)
        {
            return false;
        }

        if (currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        RaiseHealthChanged();

        return true;
    }

    public void AddDamage(float amount)
    {
        currentHealth -= amount;
        RaiseHealthChanged();

        if (currentHealth <= minHealth)
        {
            RaiseDeath();
            return;
        }
    }

    void RaiseHealthChanged()
    {
        if (HealthChanged != null)
        {
            HealthArgs args = new HealthArgs();

            args.currentHealth = currentHealth;
            args.minHealth = minHealth;
            args.maxHealth = maxHealth;
            args.isDead = false;

            HealthChanged.Invoke(this, args);
        }
    }

    void RaiseDeath()
    {
        if (Die != null)
        {
            HealthArgs args = new HealthArgs();

            args.currentHealth = currentHealth;
            args.minHealth = minHealth;
            args.maxHealth = maxHealth;
            args.isDead = true;

            Die.Invoke(this, args);
        }
    }
}
