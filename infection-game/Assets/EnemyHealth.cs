using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    public int currentHealth;
    public Vector2 velocidadRebote;

    private Transform transform;

    private Rigidbody2D rb2d;
    private Collider2D collider2d;
    private ZombieDog zombieDog;
    private Enemigo enemigo;

    public Animator animator;
    public bool boss;

    public float strength = 16, delay = 0.15f;

    public HealthBarBoss healthBarBoss;

    void Start()
    {
        currentHealth = maxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        if (!boss)
        {
            zombieDog = GetComponent<ZombieDog>();
            enemigo = GetComponent<Enemigo>();
        }
        if (boss)
        {
            healthBarBoss.initializeBossHealthBar(maxHealth);
        }
    }

    public void TakeDamage(int damage, Transform position)
    {
        currentHealth -= damage;
        
        // set trigger hurt
        animator.SetTrigger("Hurt");
        if (boss)
        {
            healthBarBoss.changeCurrentHealth(currentHealth);
        }


        PlayFeedback(position);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void PlayFeedback(Transform position)
    {
        StopAllCoroutines();
        if (position.position.x < transform.position.x)
        {
            rb2d.velocity = new Vector2(velocidadRebote.x, 0);

        }
        else
        {
            rb2d.velocity = new Vector2(-velocidadRebote.x, 0);
        }
        if (enemigo)
        {
            enemigo.isBeingHurt = true;
        }
        if (zombieDog)
        {
            zombieDog.isBeingHurt = true;
        }

        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        if (enemigo)
        {
            enemigo.isBeingHurt = false;
        }
        if (zombieDog)
        {
            zombieDog.isBeingHurt = false;
        }
    }
 

    void Die()
    {
        // set bool isDead true
        // this.enabled = false;
        collider2d.enabled = false;
        Destroy(rb2d);
        animator.SetBool("isDead", true);
     
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
