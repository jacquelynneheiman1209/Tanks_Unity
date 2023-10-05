using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    [SerializeField] private ShieldPowerUp powerUp;

    private void OnTriggerEnter(Collider other)
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
