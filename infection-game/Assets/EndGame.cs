using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ControladorDeEscenas ControladorDeEscenas;

    void Update()
    {

    } 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ControladorDeEscenas.CargarNivel(14);
        }
    }
}
