using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad;

    public Transform A;

    public Transform B;

    public Rigidbody2D rb2d;

    public Personaje Personaje;


    public bool inicio;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (inicio)
        {
            rb2d.velocity = Vector2.right * velocidad;
            if (transform.position.x >= A.position.x)
            {
                inicio = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            rb2d.velocity = Vector2.left * velocidad;
            if (transform.position.x <= B.position.x)
            {
                inicio = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);


            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(1, other.GetContact(0).normal);
        }
        if (!Personaje.estaVivo())
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }



}
