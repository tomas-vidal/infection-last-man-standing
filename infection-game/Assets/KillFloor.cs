using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public ControladorDeEscenas ControladorDeEscenas;
    public HealthManager HealthManager;
    public Personaje Personaje;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //if (Personaje.estaVivo())
            if (Personaje.state == GameState.vivo)
            {
            HealthManager.vidaActual = 0;

                HealthManager.recibioDaño(0, transform);
            }
        }
    }
}
