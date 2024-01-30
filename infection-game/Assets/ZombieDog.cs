using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieDog : MonoBehaviour
{
    public float speed;
    public bool enraged;
    public GameObject player;
    public int speedEnraged;
    
    private float KBCounter;

    public Transform A;

    public Transform B;
    private Animator Animator;

    private Rigidbody2D rb2d;

    public bool isBeingHurt = false;

    public bool inicio;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enraged = false;
        Animator = GetComponent<Animator>();
        inicio = Random.Range(0, 2) % 2 != 0;
        if (!inicio)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeingHurt && KBCounter <= 0 && !Animator.GetBool("isDead"))
        {
            if (enraged)
            {
                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();
                if (direction.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    inicio = true;
                } else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    inicio = false;
                }

                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, this.transform.position.y), speedEnraged * Time.deltaTime);
                rb2d.velocity = new Vector2(0, 0);

                if (transform.position.x >= A.position.x)
                {
                    transform.position = new Vector2(A.position.x, this.transform.position.y);
                } 
                if (transform.position.x <= B.position.x)
                {
                    transform.position = new Vector2(B.position.x, this.transform.position.y);

                }



            }
            else
            {
                if (inicio)
                {
                    rb2d.velocity = Vector2.right * speed;
                    if (transform.position.x >= A.position.x)
                    {
                        inicio = false;
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }
                else
                {
                    rb2d.velocity = Vector2.left * speed;
                    if (transform.position.x <= B.position.x)
                    {
                        inicio = true;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
            }
        }
        else
        {
            KBCounter -= Time.deltaTime;
        }


    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(2, transform);
            if (other.GetContact(0).normal.x == 0)
            {
                rb2d.velocity = new Vector2(other.GetContact(0).normal.y * 3, 0);
            } else
            {
                rb2d.velocity = new Vector2(other.GetContact(0).normal.x * 3, 0);
            }
            KBCounter = 0.3f;
        }

        if (other.gameObject.CompareTag("Enemigo"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }

        if (Personaje.state == GameState.muerto)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }

    }
}
