using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithPlayer : MonoBehaviour
{
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You have been hit!");
            Destroy(other);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(Reset());
        }
    }
}
