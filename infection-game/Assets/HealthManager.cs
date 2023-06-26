using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxVida = 3;
    public int vidaActual;
    public Image corazon;

    private Personaje Personaje;
    private MovimientoJugador MovimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private float tiempoRecargaNivel;

    public ControladorDeEscenas ControladorDeEscenas;

    public Sprite corazonLleno;
    public Sprite corazonCasiLleno;
    public Sprite corazonMedio;
    public Sprite corazonVacio;


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = maxVida;
        corazon.sprite = corazonLleno;
        Personaje = GetComponent<Personaje>();
        MovimientoJugador = GetComponent<MovimientoJugador>();

    }

    // Update is called once per frame
    void Update()
    {
    

    }

    public void recibioDaño(int daño, Vector2 posicion = default(Vector2)) 
    {
        vidaActual = vidaActual - daño;
        


        switch (vidaActual)
        {
            case 3: 
                corazon.sprite = corazonLleno;
                break;
            case 2:
                corazon.sprite = corazonCasiLleno;
                break;
            case 1:
                corazon.sprite = corazonMedio;
                break;
            case 0:
                corazon.sprite = corazonVacio;
                Personaje.Morir();
                break;
            default:
                corazon.sprite = corazonVacio;
                break;
        }


        if (vidaActual > 0)
        {
            Personaje.Rebote(posicion);
            MovimientoJugador.puedeMoverse = false;
            StartCoroutine(PerderControl());

        } else if (vidaActual <= 0)
        {
            Personaje.Morir();
            StartCoroutine(delayMorir());
        }
    }


    private IEnumerator delayMorir()
    {
        yield return new WaitForSeconds(1);
        ControladorDeEscenas.RecargarNivel();

    }

    private IEnumerator PerderControl()
    { 
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Personaje.rb2d.velocity = new Vector2(0, 0);
        MovimientoJugador.puedeMoverse = true;


    }


}
