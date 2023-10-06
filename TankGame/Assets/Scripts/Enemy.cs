using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Pawn
{
    [SerializeField] private UIManager uiManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        uiManager = GetComponentInChildren<UIManager>();

        if (uiManager != null)
        {
            uiManager.parent = this.gameObject;
        }

        if (health != null)
        {
            health.Die += OnDeath;
        }
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
