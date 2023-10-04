using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("The time in seconds before the bullet is destoryed if it doesn't collide with anything.")]
    [SerializeField] private float destroyDelay;

    [Tooltip("The amount of forces that is applied to the bullet when the player shoots it.")]
    [SerializeField] private float shootForce;

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
        // handle bullet collision here...
        Destroy(this.gameObject);
    }
}
