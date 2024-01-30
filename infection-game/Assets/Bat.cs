using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class Bat : MonoBehaviour
{
    public GameObject player;
    public float speed;


    private float distance;
    public float distanceFollow;

    public Transform[] transformPoints;
    public float minDistance;
    private int randomNumber;
    private Transform transform;

    public AudioSource src;
    public AudioClip hit;

    private float KBCounter;
    private Rigidbody2D rb2d;

    public bool isBeingHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, transformPoints.Length);
        rb2d = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        src = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeingHurt && !this.gameObject.GetComponent<Animator>().GetBool("isDead"))
        {
            if (KBCounter <= 0)
            {
                distance = Vector2.Distance(transform.position, player.transform.position);
                if (distance < distanceFollow)
                {
                    Vector2 direction = player.transform.position - transform.position;
                    direction.Normalize();


                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, transformPoints[randomNumber].position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, transformPoints[randomNumber].position) < minDistance)
                    {
                        randomNumber = Random.Range(0, transformPoints.Length);
                    }
                }
                rb2d.velocity = new Vector2(0, 0);
            }
            else
            {
                KBCounter -= Time.deltaTime;
            }

        }
    }

    private void Hurt()
    {
        src.PlayOneShot(hit);
        isBeingHurt = true;
    }

    private void HurtFinish()
    {
        isBeingHurt = false;
    }

    private void BatDie()
    {
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(1, transform);
            rb2d.velocity = new Vector2(1, 1);
            KBCounter = 0.7f;
        }

        //if (other.gameObject.GetComponent<Personaje>().state == GameState.muerto)
        //{
        //    Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        //}


        if (Personaje.state == GameState.muerto)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }

    }
}
