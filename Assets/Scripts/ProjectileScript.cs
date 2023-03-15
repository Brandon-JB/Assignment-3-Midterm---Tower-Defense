using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            //Debug.Log("beans");
        }
    }
}
