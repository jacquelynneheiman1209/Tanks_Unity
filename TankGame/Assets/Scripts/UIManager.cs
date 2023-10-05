using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject parent;
    private Canvas canvas;
    private Camera mainCamera;

    [SerializeField] private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();

        mainCamera = Camera.main;
        canvas.worldCamera = mainCamera;

        if (this.parent != null)
        {
            Health health = parent.GetComponent<Health>();

            if (health != null)
            {
                health.HealthChanged += UpdateHealthBar;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.LookAt(mainCamera.transform.position);
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
