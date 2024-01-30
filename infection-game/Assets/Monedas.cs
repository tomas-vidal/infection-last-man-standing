using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monedas : MonoBehaviour
{
    public string uniqueId;
    public bool pickedUp;

    void Start()
    {
        uniqueId = System.Guid.NewGuid().ToString();
        pickedUp = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickedUp = true;
            Destroy(gameObject);
        }
    }
}
