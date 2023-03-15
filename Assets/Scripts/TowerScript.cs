using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public int maxHP = 2;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected virtual void Die()
    {
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
