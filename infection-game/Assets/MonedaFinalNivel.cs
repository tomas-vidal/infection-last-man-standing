using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaFinalNivel : MonoBehaviour
{

    public CircleCollider2D cc2d;
    public PuntuacionMonedas PuntuacionMonedas;
    public int monedasTrack = 0;

    //public CambiarNivel CambiarNivel;
    // Start is called before the first frame update
    void Start()
    {
        cc2d = GetComponent<CircleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void guardarMonedas(int monedas)
    {
        monedasTrack = monedas;
    }

}
