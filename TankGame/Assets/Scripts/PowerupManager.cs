using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public void ApplyEffect(Func<bool> effect)
    {
        effect();
    }
}
