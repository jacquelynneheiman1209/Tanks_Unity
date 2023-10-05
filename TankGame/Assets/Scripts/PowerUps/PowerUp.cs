using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp
{
    public float duration;

    public virtual bool Apply(PowerupManager powerupManager)
    {
        return true;
    }

    public virtual bool Remove(PowerupManager powerupManager)
    {
        return true;
    }
}
