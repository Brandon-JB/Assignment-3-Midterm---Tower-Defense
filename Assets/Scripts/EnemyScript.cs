using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHP = 5;
    public int health;

    //public ParticleSystem spawnParticles;
    void Start()
    {
        //Instantiate(spawnParticles, transform.position, Quaternion.identity);

        health = maxHP;
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
