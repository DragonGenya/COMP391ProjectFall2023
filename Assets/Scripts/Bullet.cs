using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D otherThing)
    {
        if(otherThing.tag == "Enemy")
        {
            otherThing.GetComponent<EnemyBehaviour>().LifeTotal--;
            if (otherThing.GetComponent<EnemyBehaviour>().LifeTotal == 0)
            {
                Destroy(otherThing.gameObject);
            }
        }
    }
}
