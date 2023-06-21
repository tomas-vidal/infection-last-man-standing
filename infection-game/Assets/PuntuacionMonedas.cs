using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacionMonedas : MonoBehaviour
{

    public int monedas;
    public Text puntuacionTexto;


    // Start is called before the first frame update
    void Start()
    {

            monedas = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgregarMoneda()
    {
        monedas++;
        puntuacionTexto.text = monedas.ToString();

    }
  
}
