using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShieldBar : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private Image shieldBar;

    private void Start()
    {
        if (manager != null)
        {
            Shields health = manager.parent.GetComponent<Shields>();

            if (health != null)
            {
                health.ShieldChanged += UpdateShieldBar;
            }
        }
    }

    void UpdateShieldBar(object sender, EventArgs args)
    {
        ShieldArgs shieldArgs = (ShieldArgs)args;

        if (shieldArgs != null)
        {
            shieldBar.fillAmount = shieldArgs.currentShield / shieldArgs.maxShield;
        }
    }


}
