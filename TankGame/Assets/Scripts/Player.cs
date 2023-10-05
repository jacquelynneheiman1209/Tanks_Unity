using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn  
{
    protected override void Start()
    {
        base.Start();

        health.HealthChanged += OnHealthChanged;
        health.Die += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        mover.Move(movementInput.z);
        mover.Turn(movementInput.x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.Shoot();
        }
    }
}
