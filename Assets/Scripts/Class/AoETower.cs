using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETower : TowerScript
{
    public float cooldownTime;
    public GameObject AoEEffect;
    private float timePassed;

    public float attackActiveTime;
    private float timeAttackIsActive;


    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0f;
        timeAttackIsActive = 0f;

        health = maxHP;

        AoEEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        Attack();

        Die();
    }

    void Attack()
    {
        if (timePassed >= cooldownTime)
        {
            AoEEffect.SetActive(true);
            timeAttackIsActive += Time.deltaTime;
            if (timeAttackIsActive >= attackActiveTime)
            {
                timePassed = 0f;
                timeAttackIsActive = 0f;
                AoEEffect.SetActive(false);
            }
        }
    }
   /* private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            health--;
            Debug.Log("beans");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            health--;
            //Debug.Log("beans");
        }
    }
}