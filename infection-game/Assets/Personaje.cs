using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public enum GameState { vivo, muerto };

    public GameState estado;

    public HealthManager HealthManager;

    public bool puedeMoverse;
    [SerializeField] private Vector2 velocidadRebote;

    public Rigidbody2D rb2d;
    private Animator animator;
    public ControladorDeEscenas ControladorDeEscenas;

    public PuntuacionMonedas PuntuacionMonedas;

    public MonedaFinalNivel MonedaFinalNivel;

    public MovimientoJugador MovimientoJugador;

    private AudioSource src;
    public AudioClip Daño, Moneda, Muerte;


    // Start is called before the first frame update
    void Start()
    {
        GameState estado = GameState.vivo;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        puedeMoverse = true;
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.vivo && puedeMoverse)
        {
            MovimientoJugador.Movimiento();
           
            if (transform.position.y < -5.4)
            {
                Morir();
            }
        } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PasarNivel")
        {
            PasarNivel();

        }

        if (collision.gameObject.tag == "Moneda")
        {
            PuntuacionMonedas.AgregarMoneda();
            src.clip = Moneda;
            src.Play();
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        src.clip = Daño;
        src.Play();
        rb2d.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
    
    public void ResetVelocity()
    {
        animator.ResetTrigger("daño");
        puedeMoverse = true;
        rb2d.velocity = new Vector2(0, 0);
    }

    public void Morir()
    {
        animator.SetTrigger("jugadorMuere");
        src.clip = Muerte;
        src.Play();
        rb2d.velocity = new Vector2(0, 0);
        estado = GameState.muerto;
        StartCoroutine(HealthManager.ReiniciarNivelTiempo());

    }
 
    private void PasarNivel()
    {
        animator.SetFloat("Horizontal", 0);
        rb2d.velocity = new Vector2(0, 0);
        ControladorDeEscenas.SiguienteNivel();
    }

    private void RecargarNivelAnimacion()
    {
        ControladorDeEscenas.RecargarNivel();
    }

    public bool estaVivo()
    {
        if (estado == GameState.vivo)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
