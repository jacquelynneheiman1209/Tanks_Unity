using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Mover mover;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        mover.Turn(TurnDirection.right);
    }

    private void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            powerupManager.ApplyEffect(() => Effect(powerupManager));
        }
    }

    protected virtual bool Effect(PowerupManager manager)
    {
        return true;
    }
}
