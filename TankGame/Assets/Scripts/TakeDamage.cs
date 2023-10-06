using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Shields shield = other.GetComponent<Shields>();
        float remainingDamage = damage;

        if (shield != null)
        {
            remainingDamage = shield.Reduce(damage);
        }

        if (remainingDamage > 0)
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.AddDamage(remainingDamage);
            }
        }
    }
}
