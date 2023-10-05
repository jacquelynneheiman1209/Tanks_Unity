using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private List<PowerUp> activePowerUps = new List<PowerUp>();

    private void Update()
    {
        List<PowerUp> powerUpsToRemove = new List<PowerUp>();

        foreach (PowerUp powerUp in activePowerUps)
        {
            if (powerUp.duration > 0)
            {
                powerUp.duration -= Time.deltaTime;

                if (powerUp.duration <= 0)
                {
                    powerUpsToRemove.Add(powerUp);
                }
            }
        }

        // remove any powerups that have run out of time
        if (powerUpsToRemove.Count > 0)
        {
            foreach (PowerUp powerUp in powerUpsToRemove)
            {
                Remove(powerUp);
            }
        }
    }

    public bool Add(PowerUp powerUp)
    {
        if (powerUp.duration > 0)
        {
            activePowerUps.Add(powerUp);
        }

        return powerUp.Apply(this);
    }

    public void Remove(PowerUp powerUp)
    {
        powerUp.Remove(this);
        activePowerUps.Remove(powerUp);
    }
}

