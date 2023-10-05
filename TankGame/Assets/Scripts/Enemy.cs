using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Pawn
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Image healthBar;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        uiManager = GetComponentInChildren<UIManager>();

        uiManager.parent = this.gameObject;

        health.Die += OnDeath;

    }

    protected override void OnDeath(object sender, EventArgs args)
    {
        HealthArgs healthArgs = (HealthArgs)args;

        if (healthArgs != null )
        {
            Destroy(this.gameObject);
        }
    }
}
