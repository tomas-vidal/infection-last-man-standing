using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum GameState { vivo, muerto };


public class Personaje : MonoBehaviour
{

    public static GameState state;

    public HealthManager HealthManager;

    [SerializeField] private Vector2 velocidadRebote;

    public Rigidbody2D rb2d;
    private Animator animator;
    public ControladorDeEscenas ControladorDeEscenas;

    private PlayerCombat PlayerCombat;

    public Puntuation Puntuation;

    public MovimientoJugador MovimientoJugador;
    public follow follow;
    public Transform checkPointPosition;
    public Transform transform;

    public float delay = .5f;

    public float KBCounter;

    public AudioSource src;
    public AudioClip Daño, Moneda, Muerte, Salto;

    public bool isBeingHurt = false;

    // Start is called before the first frame update


    void Start()
    {
        state = GameState.vivo;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
        PlayerCombat = GetComponent<PlayerCombat>();
        transform = GetComponent<Transform>();
        if (Checkpoint.checkpointReached)
        {
            GetComponent<Transform>().position = Checkpoint.lastCheckpointPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.vivo && !PauseMenu.isPaused && !isBeingHurt)
        {
            MovimientoJugador.Movimiento();
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    GameObject.GetComponent<BoxCollider2D>.setActive = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            Puntuation.AgregarMoneda();
            src.PlayOneShot(Moneda);
        }


    }

    public void Rebote(Transform puntoGolpe)
    {
        if (state == GameState.vivo)
        {
            animator.SetTrigger("daño");
            MovimientoJugador.KBCounter = 0.3f;
            src.PlayOneShot(Daño);

            PlayFeedback(puntoGolpe);
           
            //rb2d.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
        }
    
    
    }

    void PlayFeedback(Transform position)
    {
        StopAllCoroutines();
        if (position.position.x < transform.position.x)
        {
            rb2d.velocity = new Vector2(5f, 5f);

        }
        else
        {
            rb2d.velocity = new Vector2(-5f, 5f);
        }
        isBeingHurt = true;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        isBeingHurt = false;
    }

    public void Morir()
    {
        if (state == GameState.vivo)
        {
            animator.SetBool("isDead", true);
            src.PlayOneShot(Muerte);
            state = GameState.muerto;
            rb2d.velocity = new Vector2(0, 0);
            GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }



    private void PasarNivel()
    {
        animator.SetFloat("Horizontal", 0);
        rb2d.velocity = new Vector2(0, 0);
        ControladorDeEscenas.SiguienteNivel();
    }
}
