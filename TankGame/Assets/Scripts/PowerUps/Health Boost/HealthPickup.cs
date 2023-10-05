using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private HealthPowerUp powerUp;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)        
        {
            if (powerupManager.Add(powerUp))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
