using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public BoxCollider2D bc2d;
    private Animator animator;
    public float spikeSpeed;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        InvokeRepeating("spikeRate", 0f, spikeSpeed);
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Personaje.state == GameState.muerto)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(1, transform);
        }

    }


    private void spikeRate()
    {
        if (animator.GetBool("spike"))
        {
            animator.SetBool("spike", false);
        } else
        {
            animator.SetBool("spike", true);
        }
    }

    public void offSpike()
    {
        bc2d.offset = new Vector2(0f, -0.74f);
    }

    public void onSpike()
    {
        bc2d.offset = new Vector2(0f, -0.35f);
    }
}
