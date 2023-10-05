using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShieldPowerUp : PowerUp
{
    [SerializeField] private float shieldAmount;

    public override bool Apply(PowerupManager powerupManager)
    {
        Shields shield = powerupManager.GetComponent<Shields>();

        if (shield != null) 
        {
            return shield.Generate(shieldAmount);
        }

        return false;
    }
}
