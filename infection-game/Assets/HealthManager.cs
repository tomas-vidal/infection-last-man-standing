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


        if (vidaActual != 0)
        {
            StartCoroutine(PerderControl());
            Personaje.Rebote(posicion);
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
        Personaje.puedeMoverse = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Personaje.puedeMoverse = true;
    }


}
