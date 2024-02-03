using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovimientoJugador : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    [SerializeField] private LayerMask terrenoSaltable;

    public static float KBCounter;

    public float velocidad;
    public float cantidadSalto;

    private Personaje Personaje;
    private PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        Personaje = GetComponent<Personaje>();
        playerCombat = GetComponent<PlayerCombat>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Movimiento()
    {

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("animacionSaltar", false);
            animator.SetBool("animacionCaer", true);
            animator.SetBool("isGrounded", false);
        }
        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("animacionSaltar", true);
            animator.SetBool("animacionCaer", false);
            animator.SetBool("isGrounded", false);
        }


            if (KBCounter <= 0)
        {
            if (Piso())
            {
                animator.SetBool("isGrounded", true);
                animator.SetBool("animacionCaer", false);
                animator.SetBool("animacionSaltar", false);
                if (Input.GetButtonDown("Jump"))
                {
                    Personaje.src.PlayOneShot(Personaje.Salto);
                    rb2d.velocity = cantidadSalto * transform.up;
                }
            }
            else
            {
                animator.SetBool("isGrounded", false);
                
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                rb2d.velocity = new Vector2(velocidad * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);
                Rotacion(); 
            }
            if (Input.GetButtonDown("Jump") && Piso())
            {
                Personaje.src.PlayOneShot(Personaje.Salto);
                rb2d.velocity = cantidadSalto * transform.up;
            }   
        } else
        {
            KBCounter -= Time.deltaTime;
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

    public bool Piso()
    {
        return Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, terrenoSaltable);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (KBCounter >= 0 || playerCombat.nextAttackTime > 0)
        {
            if (collision.gameObject.tag == "Piso" && Piso() && follow.cameraFollow)
            {
                    rb2d.velocity = new Vector2(0, 0);
                    KBCounter = 0;
            }
        }
    }

}
