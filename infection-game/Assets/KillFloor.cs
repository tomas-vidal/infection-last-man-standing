using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public ControladorDeEscenas ControladorDeEscenas;
    public HealthManager HealthManager;
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
        if (collision.gameObject.tag == "Player")
        {
            HealthManager.vidaActual = 0;

            HealthManager.recibioDa�o(0);
        }
    }
}
