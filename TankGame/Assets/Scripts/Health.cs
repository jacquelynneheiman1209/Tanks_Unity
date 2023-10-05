using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public event EventHandler HealthChanged;
    public event EventHandler Die;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        HealthArgs args = new HealthArgs();

        args.currentHealth = currentHealth;
        args.minHealth = minHealth;
        args.maxHealth = maxHealth;
        args.isDead = false;

        HealthChanged.Invoke(this, args);
    }

    public void AddDamage(float amount)
    {
        Debug.Log("Adding Damage");

        currentHealth -= amount;

        HealthArgs args = new HealthArgs();
            
        args.currentHealth = currentHealth;
        args.minHealth = minHealth;
        args.maxHealth = maxHealth;

        if (currentHealth < minHealth)
        {
            args.isDead = true;

            Die.Invoke(this, args);
            return;
        }

        args.isDead = false;

        HealthChanged.Invoke(this, args);
    }
}
