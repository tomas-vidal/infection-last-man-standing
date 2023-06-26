using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public enum GameState { vivo, muerto };

    public bool estado;

    public HealthManager HealthManager;

    [SerializeField] private Vector2 velocidadRebote;

    public Rigidbody2D rb2d;
    private Animator animator;
    public ControladorDeEscenas ControladorDeEscenas;

    public PuntuacionMonedas PuntuacionMonedas;

    public MovimientoJugador MovimientoJugador;
    public follow follow;


    public AudioSource src;
    public AudioClip Daño, Moneda, Muerte, Salto;



    // Start is called before the first frame update
    void Start()
    {
        estado = true;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estado)
        {
            MovimientoJugador.Movimiento();         
        } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Moneda")
        {
            PuntuacionMonedas.AgregarMoneda();
            src.clip = Moneda;
            src.Play();
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        if (estado)
        {
            src.clip = Daño;
            src.Play();
            rb2d.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
        }
    }

    public void Morir()
    {
        animator.SetTrigger("jugadorMuere");
        src.clip = Muerte;
        src.Play();
        rb2d.velocity = new Vector2(0, 0);
        estado = false;

    }


    private void PasarNivel()
    {
        animator.SetFloat("Horizontal", 0);
        rb2d.velocity = new Vector2(0, 0);
        ControladorDeEscenas.SiguienteNivel();
    }

    public bool estaVivo()
    {
        if (estado)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
