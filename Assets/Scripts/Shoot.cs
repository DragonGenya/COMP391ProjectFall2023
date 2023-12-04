using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject Bullet;

    [SerializeField] private AudioSource attackSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            attackSoundEffect.Play();
 
        }

    }
}
