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

    private void Start()
    {
        currentShield = maxShield;
        RaiseShieldChanged();
    }

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

            ShieldChanged.Invoke(this, args);
        }

        return true;
    }

    public float Reduce(float amount)
    {
        if (currentShield <= minShield)
        {
            return amount;
        }
        else if (currentShield - amount < minShield)
        {
            currentShield = minShield;

            if (ShieldDestroyed != null)
            {
                RaiseShieldDestroyed();
            }

            if (ShieldChanged != null)
            {
                RaiseShieldChanged();
            }

            return amount - minShield;
        }
        else
        {
            currentShield -= amount;

            if (ShieldChanged != null)
            {
                RaiseShieldChanged();
            }

            return 0;
        }
    }

    void RaiseShieldChanged()
    {
        if (ShieldChanged != null)
        {
            ShieldArgs args = new ShieldArgs();

            args.minShield = minShield;
            args.maxShield = maxShield;
            args.currentShield = currentShield;

            args.isDestroyed = false;

            ShieldChanged.Invoke(this, args);
        }   
    }

    void RaiseShieldDestroyed()
    {
        if (ShieldDestroyed != null)
        {
            ShieldArgs args = new ShieldArgs();

            args.minShield = minShield;
            args.maxShield = maxShield;
            args.currentShield = currentShield;

            args.isDestroyed = true;

            ShieldDestroyed.Invoke(this, args);
        }
    }
}
