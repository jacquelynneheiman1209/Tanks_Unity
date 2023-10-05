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

    public bool IncreaseSpeed(float increase)
    {
        float oldForwardSpeed = forwardSpeed;
        float oldBackwardSpeed = backwardSpeed;

        forwardSpeed += increase;
        backwardSpeed += increase;

        return (forwardSpeed == oldForwardSpeed + increase) && (backwardSpeed == oldBackwardSpeed + increase);
    }

    public bool DecreaseSpeed(float decrease)
    {
        float oldForwardSpeed = forwardSpeed;
        float oldBackwardSpeed = backwardSpeed;

        forwardSpeed -= decrease;
        backwardSpeed -= decrease;  

        return (forwardSpeed == oldForwardSpeed - decrease) && (backwardSpeed == oldBackwardSpeed - decrease);
    }
}
