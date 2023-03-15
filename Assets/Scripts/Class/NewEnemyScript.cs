using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyScript : EnemyScript
{
    //The node that we are currently following. Set it at edit time to determine the first node.
    public NodeScript nextNode;

    //A reference to the contorller so we can call the "move" function
    public CharacterController controller;

    public float speed;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;
    void Start()
    {
        health = maxHP;

        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
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
}
