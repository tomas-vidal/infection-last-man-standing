using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorDeEscenas : MonoBehaviour
{
    public Animator animator;
    private int nivelACargar;

    public PuntuacionMonedas PuntuacionMonedas;

    // Start is called before the first frame update
    void Start()
    {
     animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecargarNivel()
    {
        CargarNivel(SceneManager.GetActiveScene().buildIndex);
    }

    public void SiguienteNivel()
    {
        CargarNivel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CargarNivel(int nivel)
    {
        animator.SetTrigger("Fade");
        nivelACargar = nivel;
    }



    public void FadeTerminado()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(nivelACargar);


    }
}
