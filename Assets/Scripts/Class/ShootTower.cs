using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : TowerScript
{
    public float ShootCooldown = 2;
    private float timePassed;
    public Transform firePoint;
    public Transform topFirePoint;
    public Transform rightFirePoint;
    public Transform bottomFirePoint;
    public GameObject bullet;
    public AudioSource AudioSource;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= ShootCooldown)
        {
            Shoot();
        }

        Die();
    }

    void Shoot()
    {
        AudioSource.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, topFirePoint.position, topFirePoint.rotation);
        Instantiate(bullet, rightFirePoint.position, rightFirePoint.rotation);
        Instantiate(bullet, bottomFirePoint.position, bottomFirePoint.rotation);
        timePassed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            health--;
            //Debug.Log("beans");
        }
    }
}
