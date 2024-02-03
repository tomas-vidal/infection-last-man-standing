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
        if (other == null) return;
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().recibioDaño(10, transform);
        }
    }
}
