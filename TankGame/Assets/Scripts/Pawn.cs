using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    protected Mover mover;
    protected Shooter shooter;
    protected Health health;
    protected Shields shield;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        shield = GetComponent<Shields>();
    }

    protected virtual void OnHealthChanged(object sender, EventArgs args)
    {

    }

    protected virtual void OnDeath(object sender, EventArgs args)
    {

    }

}
