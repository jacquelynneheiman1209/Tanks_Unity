using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Mover mover;
    private Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        mover.Move(movementInput.z);
        mover.Turn(movementInput.x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.Shoot();
        }
    }
}
