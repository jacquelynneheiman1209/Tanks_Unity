using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Mover mover;
 
    [SerializeField] private TurnDirection turnDirection;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        mover.Turn(turnDirection);   
    }
}
