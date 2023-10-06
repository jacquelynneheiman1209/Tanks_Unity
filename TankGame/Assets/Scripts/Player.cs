using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn  
{
    public UIManager uiManager;

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
            health.AddDamage(25);
            health.Die += OnDeath;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (mover != null)
        {
            mover.Move(movementInput.z);
            mover.Turn(movementInput.x);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shooter != null)
            {
                shooter.Shoot();
            }
        }
    }

    protected override void OnDeath(object sender, EventArgs args)
    {
        HealthArgs healthArgs = args as HealthArgs;

        if (healthArgs != null)
        {
            Debug.Log("Player Died...");
        }
    }

    void OnShieldChanged(object sender, EventArgs args)
    {

    }

    void OnShieldDestroyed(object sender, EventArgs args)
    {

    }
}
