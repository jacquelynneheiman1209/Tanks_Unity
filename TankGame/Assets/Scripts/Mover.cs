using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Mover : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    [SerializeField] private float turnSpeed;

    public void Move(float direction)
    {
        float directionModifier = 0;

        if (direction > 0)
        {
            directionModifier = forwardSpeed * Time.deltaTime * direction;
        }
        else if (direction < 0 )
        {
            directionModifier = backwardSpeed * Time.deltaTime * direction; 
        }

        transform.position += transform.forward * directionModifier;
    }

    public void Turn(float direction)
    {
        transform.Rotate(0f, direction * turnSpeed * Time.deltaTime, 0f);
    }

    public void Turn(TurnDirection direction)
    {
        Turn((int)direction);
    }

    public float GetForwardSpeed()
    {
        return forwardSpeed;
    }

    public float GetBackwardSpeed()
    {
        return backwardSpeed;
    }

    public void SetForwardMoveSpeed(float newSpeed)
    {
        forwardSpeed = newSpeed;
    }

    public void SetBackwardMoveSpeed(float newSpeed)
    {
        backwardSpeed = newSpeed;
    }
}
