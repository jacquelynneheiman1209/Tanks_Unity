using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private bool canShoot;

    [SerializeField] private float shootDelay;
    private float shootTimer;

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;

    private void Update()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootDelay)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            canShoot = false;
            shootTimer = 0;

            Debug.Log("Shoot!");
        }
    }
}
