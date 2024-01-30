using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnrage : MonoBehaviour
{
    public ZombieDog ZombieDog;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = ZombieDog.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator.SetBool("Enraged", true);
            ZombieDog.enraged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ZombieDog.inicio = !ZombieDog.inicio;
            StartCoroutine(DisableEnraged());
        }
    }

    IEnumerator DisableEnraged()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        Animator.SetBool("Enraged", false);
        ZombieDog.enraged = false;
    }
}

