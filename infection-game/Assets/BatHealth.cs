using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHealth : MonoBehaviour
{

    public int maxHealth = 1;
    public int currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, Transform position)
    {

        Debug.Log("Hurt");
        currentHealth -= damage;

        // set trigger hurt
        animator.SetTrigger("Hurt");

        // knockback
      
        if (currentHealth < 0)
        {
            Die();
        }
    }

    void Die()
    {

        // set bool isDead true
        animator.SetBool("isDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
