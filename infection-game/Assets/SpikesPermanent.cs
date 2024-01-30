using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesPermanent : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDa�o(10, transform);
        }

        if (Personaje.state == GameState.muerto)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }

    }
}
