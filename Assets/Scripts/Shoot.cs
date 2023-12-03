using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject Bulletx;
    public LayerMask whatIsEnemies;
    public int damage = 1;

    public float attackRange;

    [SerializeField] private AudioSource attackSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Bulletx, ShootPoint.position, ShootPoint.rotation);
            attackSoundEffect.Play();
 
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(ShootPoint.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyBehaviour>().LifeTotal -= damage;

            }
        }
    }
}
