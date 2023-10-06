using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("The time in seconds before the bullet is destoryed if it doesn't collide with anything.")]
    [SerializeField] private float destroyDelay;

    [Tooltip("The amount of forces that is applied to the bullet when the player shoots it.")]
    [SerializeField] private float shootForce;

    [Tooltip("The amount of damage that will be applied to anything with a health component upon hit.")]
    [SerializeField] private float damage;

    private float destroyTimer;
    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    private void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer >= destroyDelay)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Shields shield = other.GetComponent<Shields>();
        float remainingDamage = damage;

        if (shield != null)
        {
            remainingDamage = shield.Reduce(damage);
            Debug.Log("Remaining Damage: " + remainingDamage);
        }

        if (remainingDamage > 0)
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.AddDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
