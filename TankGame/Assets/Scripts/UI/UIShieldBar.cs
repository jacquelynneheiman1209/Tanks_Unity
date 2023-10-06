using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShieldBar : MonoBehaviour
{
    public UIManager manager;
    [SerializeField] private Image shieldBar;

    private void Start()
    {
        if (manager != null)
        {
            Shields shield = manager.parent.GetComponent<Shields>();

            if (shield != null)
            {
                shield.ShieldChanged += UpdateShieldBar;
            }
        }
    }

    void UpdateShieldBar(object sender, EventArgs args)
    {
        ShieldArgs shieldArgs = (ShieldArgs)args;

        if (shieldArgs != null)
        {
            if (shieldBar != null)
            {
                shieldBar.fillAmount = shieldArgs.currentShield / shieldArgs.maxShield;
            }
        }
    }


}
