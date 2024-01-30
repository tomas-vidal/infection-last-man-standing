using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class Murcielago : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public AudioSource src;
    public AudioClip hit;


    private float distance;
    public float distanceFollow;

    //[SerializeField] private Transform[] transformPoints;
    //public float minDistance;
    //private int randomNumber;

    public bool isBeingHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        //randomNumber = Random.Range(0f, length);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeingHurt)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < distanceFollow)
            {
                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();


                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            } 
            //else
            //{
            //    transformPoints.position = Vector2.MoveTowards(transform.position, transformPoints[randomNumber].position, speed * Time.deltaTime);
            //    if (Vector2.Distance(transformPoints.position, transformPoints[randomNumber].position) < minDistance)
            //    {
            //        randomNumber = randomNumber.Range(0, transformPoints.Length);
            //    }
            //}
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
;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(1, transform);
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
