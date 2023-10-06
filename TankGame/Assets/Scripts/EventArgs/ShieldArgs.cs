using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldArgs : EventArgs
{
    public float minShield;
    public float maxShield;
    public float currentShield;

    public bool isDestroyed;
}
