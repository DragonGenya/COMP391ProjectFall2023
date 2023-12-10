using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public float lifeTime = 1f;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage = 1;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update()
    {
       
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().health -= damage;

                }
            }
     
    }

   /* private void OnTriggerEnter2D(Collider2D ThingIHit)
    {
//        {

                Destroy(ThingIHit.gameObject);
        //}
        DestroyProjectile();
    }*/

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}