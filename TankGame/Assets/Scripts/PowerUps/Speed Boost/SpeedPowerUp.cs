using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float speedBoost;

    public override bool Apply(PowerupManager powerupManager)
    {
        Mover mover = powerupManager.GetComponent<Mover>();

        if (mover != null)
        {
            return mover.IncreaseSpeed(speedBoost);
        }

        return false;
    }

    public override bool Remove(PowerupManager powerupManager)
    {
        Mover mover = powerupManager.GetComponent<Mover>();

        if (mover != null)
        {
            return mover.DecreaseSpeed(speedBoost);
        }

        return false;
    }
}
