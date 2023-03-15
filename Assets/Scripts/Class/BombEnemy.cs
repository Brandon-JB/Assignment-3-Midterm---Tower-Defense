using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : EnemyScript
{
    public float deathDelay;
    private float timeDead;
    public GameObject damageArea;

    public Animator animator;

    //The node that we are currently following. Set it at edit time to determine the first node.
    public NodeScript nextNode;
    public GameObject startNode;

    //A reference to the contorller so we can call the "move" function
    public CharacterController controller;

    public float speed;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;

    void Start()
    {
        health = maxHP;

        controller = GetComponent<CharacterController>();
        damageArea.SetActive(false);

        startNode = GameObject.Find("StartNode");

        nextNode = startNode.GetComponent<NodeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            timeDead += Time.deltaTime;
            damageArea.SetActive(true);
            speed = 0;

            animator.Play("Explode");
        }

        if (timeDead >= deathDelay)
        {
            Die();
        }

        if (nextNode == null)
        {
            return;
        }

        Vector3 movement = (nextNode.transform.position - transform.position).normalized
            * speed
            * Time.deltaTime;

        //Otherwise, the unite will move in the direction towards its nextNode reference
        controller.Move(movement);

        /*If the distance between this unit and nextNode is less than the minimum distance, we get a new nextNode
         from the current one, by "asking it what is own "next node" is */
        if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TowerAoE" || other.gameObject.tag == "TowerProjectile")
        {
            health--;
            //Debug.Log("beans");
        }

        if (other.gameObject.tag == "Goal")
        {
            Die();
        }
    }
}
