using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        if (manager != null)
        {
            Health health = manager.parent.GetComponent<Health>();

            if (health != null)
            {
                health.HealthChanged += UpdateHealthBar;
            }
        }
    }

    void UpdateHealthBar(object sender, EventArgs args)
    {
        HealthArgs healthArgs = (HealthArgs)args;

        if (healthArgs != null)
        {
            healthBar.fillAmount = healthArgs.currentHealth / healthArgs.maxHealth;
        }
    }


}
