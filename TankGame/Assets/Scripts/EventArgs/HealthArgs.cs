using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArgs : EventArgs
{
    public float currentHealth {  get; set; }
    public float minHealth { get; set; }
    public float maxHealth { get; set; }
    public bool isDead { get; set; }    
}
