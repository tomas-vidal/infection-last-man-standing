using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Animator animator;
    public bool puedeMoverse;


    public Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    [SerializeField] private LayerMask terrenoSaltable;

    public float velocidad;
    public float cantidadSalto;

    private Personaje Personaje;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        puedeMoverse = true;
        Personaje = GetComponent<Personaje>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Movimiento()
    {
        if (puedeMoverse)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                rb2d.velocity = new Vector2(velocidad * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);
                Rotacion(); // rota el perfil del personaje según dirección

            }

            if (Piso())
            {
                animator.SetBool("animacionCaer", false);
            }

            if (rb2d.velocity.y < 0 && !Piso())
            {
                animator.SetBool("animacionCaer", true);
                animator.SetBool("animacionSaltar", false);

            }

            if (Input.GetButtonDown("Jump") && Piso())
            {
                Personaje.src.clip = Personaje.Salto;
                Personaje.src.Play();
                animator.SetBool("animacionSaltar", true);
                rb2d.velocity = cantidadSalto * transform.up;

            }


            

        } else
        {
            //fix player jump when collides with next level
            if (Piso())
            {
                animator.SetBool("animacionCaer", false);
            }

            if (rb2d.velocity.y < 0 && !Piso())
            {
                animator.SetBool("animacionCaer", true);
                animator.SetBool("animacionSaltar", false);

            }

        }



    }

    public void Rotacion()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    // funcion deteccion de piso con Boxcast
    public bool Piso()
    {
        return Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, terrenoSaltable);
    }

    // funcion deteccion de piso con Raycast
    //private bool Piso()
    //{
    //    float extraHeightText = .1f;
    //    RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, terrenoSaltable);
    //    return raycastHit.collider != null;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso" && Piso())
        {
            animator.SetBool("animacionSaltar", false);
        }

    }

}
