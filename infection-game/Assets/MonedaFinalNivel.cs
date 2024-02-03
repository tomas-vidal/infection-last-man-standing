using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonedaFinalNivel : MonoBehaviour
{

    public Puntuation Puntuation;
    public follow follow;
    public Personaje Personaje;
    public ControladorDeEscenas ControladorDeEscenas;
    public Animator lvlAnim;
    public MovimientoJugador MovimientoJugador;
    public Animator animPersonaje;
    public int nextLevel;


    //public CambiarNivel CambiarNivel;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // cuando termina el nivel el jugador sigue caminando y sale "nivel completado"
        if (collision.gameObject.tag == "Player")
        {
            follow.cameraFollow = false;
            MovimientoJugador.KBCounter = 5f;
            MovimientoJugador.rb2d.velocity = new Vector2(5f, MovimientoJugador.rb2d.velocity.y);
            lvlAnim.SetTrigger("lvlComplete");
            PlayerPrefs.SetInt("totalCoins", PlayerPrefs.GetInt("totalCoins") + Puntuation.monedas);
            Puntuation.monedas = 0;
            Destroy(GameObject.FindWithTag("CoinManager"));
            Destroy(GameObject.FindWithTag("Checkpoint"));
            StartCoroutine(delayLvl());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MovimientoJugador.transform.rotation = Quaternion.Euler(0, 0, 0);
            MovimientoJugador.animator.SetBool("animacionSaltar", false);
            if (MovimientoJugador.Piso())
            {
                MovimientoJugador.rb2d.velocity = new Vector2(5f, 0f);
                MovimientoJugador.animator.SetFloat("Horizontal", 1);
                MovimientoJugador.animator.SetBool("isGrounded", true);
                MovimientoJugador.animator.SetBool("animacionCaer", false);
            }
        }
    }

    private IEnumerator delayLvl()
    {
        Destroy(GameObject.FindWithTag("CoinManager"));
        Destroy(GameObject.FindWithTag("Checkpoint"));
        Checkpoint.checkpointReached = false;
        PlayerPrefs.SetInt("currentLvl", SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1);
        ControladorDeEscenas.CargarNivel(nextLevel);

    }

}
