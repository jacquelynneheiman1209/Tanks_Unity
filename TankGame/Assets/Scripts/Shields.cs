using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shields : MonoBehaviour
{
    [SerializeField] private float minShield;
    [SerializeField] private float maxShield;
    [SerializeField] private float currentShield;

    public event EventHandler ShieldChanged;
    public event EventHandler ShieldDestroyed;

    public bool Generate(float amount)
    {
        if (currentShield >= maxShield)
        {
            return false;
        }

        if (currentShield + amount >= maxShield)
        {
            currentShield = maxShield;
        }
        else
        {
            currentShield += amount;
        }

        if (ShieldChanged != null)
        {
            ShieldArgs args = new ShieldArgs();

            args.minShield = minShield;
            args.maxShield = maxShield;
            args.currentShield = currentShield;

            args.isDestroyed = false;

            ShieldChanged.Invoke(this, EventArgs.Empty);
        }

        return true;
    }

    public bool Reduce(float amount)
    {
        if (currentShield <= minShield)
        {
            return false;
        }

        currentShield -= amount;

        if (currentShield < minShield)
        {
            currentShield = minShield;

            if (ShieldDestroyed != null)
            {
                ShieldArgs args = new ShieldArgs();

                args.minShield = minShield;
                args.maxShield = maxShield;
                args.currentShield = currentShield;

                args.isDestroyed = true;

                ShieldDestroyed.Invoke(this, EventArgs.Empty);
            }
        }

        if (ShieldChanged != null)
        {
            ShieldArgs args = new ShieldArgs();

            args.minShield = minShield;
            args.maxShield = maxShield;
            args.currentShield = currentShield;

            args.isDestroyed = false;

            ShieldChanged.Invoke(this, EventArgs.Empty);
        }

        return true;
    }
}
