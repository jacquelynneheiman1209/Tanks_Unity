using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : Pickup
{
    [SerializeField] private float duration;
    private float timer;
    [SerializeField] private float speedIncrease;

    float originalForwardSpeed = -1;
    float originalBackwardSpeed = -1;

    bool isActive;

    Mover mover;


    protected override bool Effect(PowerupManager manager)
    {
        mover = manager.GetComponent<Mover>();
        timer = 0;

        if (mover != null)
        {
            if (originalForwardSpeed < 0)
            {
                originalForwardSpeed = mover.GetForwardSpeed();
            }

            if (originalBackwardSpeed < 0)
            {
                originalBackwardSpeed = mover.GetBackwardSpeed();
            }

            if (mover.GetForwardSpeed() != originalForwardSpeed + speedIncrease)
            {
                mover.SetForwardMoveSpeed(mover.GetForwardSpeed() + speedIncrease);
            }

            if (mover.GetBackwardSpeed()  != originalBackwardSpeed + speedIncrease) 
            {
                mover.SetBackwardMoveSpeed(mover.GetBackwardSpeed() + speedIncrease);
            }

            isActive = true;
            return true;
        }

        return false;
    }

    protected bool RemoveEffect()
    {
        if (mover != null)
        {
            if (originalForwardSpeed > -1)
            {
                mover.SetForwardMoveSpeed(originalForwardSpeed);
            }

            if (originalBackwardSpeed > -1)
            {
                mover.SetBackwardMoveSpeed(originalBackwardSpeed);
            }

            isActive = false;
            return true;
        }

        return false;
    }

    private void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer > duration)
            {
                RemoveEffect();
            }
        }
    }
}
