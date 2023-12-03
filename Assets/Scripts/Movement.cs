using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpPower = 10f;
    private bool FacingRight = true;
    private int Life = 5;
   
    [SerializeField] private float damageCooldown = 2f;
    private bool canTakeDamage = true;
    private bool canDash = true;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (FacingRight && horizontal < 0f || !FacingRight && horizontal > 0f)
        {
            this.transform.Rotate(0f, 180f, 0f);
            FacingRight = !FacingRight;
        }
    }

    private IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        Debug.Log("Damage cooldown reset");
        canTakeDamage = true;
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage)
        {
            return;
        }
        canTakeDamage = false;
        Life -= damage;
        
        if (Life <= 0)
        {
            // Reload the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
        StartCoroutine(ResetDamageCooldown());
    }
}
