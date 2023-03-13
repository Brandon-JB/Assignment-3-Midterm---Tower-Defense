using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : TowerScript
{
    public float ShootCooldown = 2;
    private float timePassed;
    public Transform firePoint;
    public GameObject bullet;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= ShootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timePassed = 0;
    }
}
