using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Health health;
    private UIManager uiManager;
    [SerializeField] private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();    
        uiManager = GetComponentInChildren<UIManager>();

        uiManager.SetCanvasRenderModer(RenderMode.WorldSpace);

        health.HealthChanged += OnHealthChanged;
        health.Die += OnDeath;

    }

    void OnHealthChanged(object sender, EventArgs args)
    {
        HealthArgs healthArgs = (HealthArgs)args;

        if (healthArgs != null)
        {
            healthBar.fillAmount = healthArgs.currentHealth / healthArgs.maxHealth;
        }
    }

    void OnDeath(object sender, EventArgs args)
    {
        HealthArgs healthArgs = (HealthArgs)args;

        if (healthArgs != null )
        {
            Destroy(this.gameObject);
        }
    }
}
