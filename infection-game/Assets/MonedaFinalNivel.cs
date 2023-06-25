using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaFinalNivel : MonoBehaviour
{

    public PuntuacionMonedas PuntuacionMonedas;
    public int monedasTrack = 0;

    public follow follow;
    public Personaje Personaje;
    public ControladorDeEscenas ControladorDeEscenas;
    public Animator lvlAnim;
    public MovimientoJugador MovimientoJugador;
    public Animator animPersonaje;

    //public CambiarNivel CambiarNivel;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void guardarMonedas(int monedas)
    {
        monedasTrack = monedas;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // FIX jumping when lvl complete
            follow.cameraFollow = false;
            Personaje.puedeMoverse = false;
            lvlAnim.SetTrigger("lvlComplete");
            StartCoroutine(delayLvl());

        }
    }

    private IEnumerator delayLvl()
    {
        yield return new WaitForSeconds(2);
        ControladorDeEscenas.SiguienteNivel();

    }

}
