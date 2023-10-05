using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private float amount;

    protected override bool Effect(PowerupManager manager)
    {
        Health health = manager.GetComponent<Health>();

        if (health != null)
        {
            return health.AddHealth(amount);
        }

        return false;
    }
}
