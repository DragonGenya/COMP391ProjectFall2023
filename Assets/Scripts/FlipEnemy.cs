using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    private bool FlipStatus = false;
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Enemy" && FlipStatus == false)
        {

            enemy.transform.Rotate(0f, 180f, 0f);
            FlipStatus = true;
        }else if(enemy.tag == "Enemy" && FlipStatus == true)
        {
            enemy.transform.Rotate(0f, 0f, 0f);
            FlipStatus = false;
        }
    }
}
