using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerUp : PowerUp
{
    [SerializeField] private float healAmount;

    public override bool Apply(PowerupManager powerupManager)
    {
        Health health = powerupManager.GetComponent<Health>();

        if (health != null)
        {
            return health.AddHealth(healAmount);
        }

        return false;
    }
}
