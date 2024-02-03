using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorDeEscenas : MonoBehaviour
{
    private Animator animator;
    private int nivelACargar;

    public HealthManager HealthManager;

    public Puntuation Puntuation;
    public int lvlsUnlocked;


    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        lvlsUnlocked = PlayerPrefs.GetInt("lvlsUnlocked", 2);
        if (SceneManager.GetActiveScene().buildIndex >= lvlsUnlocked && SceneManager.GetActiveScene().name != "Shop")
        {
            PlayerPrefs.SetInt("lvlsUnlocked", SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            DeletePlayerPrefs();
        } 

     
    }

    public void RecargarNivel()
    {
        animator.SetTrigger("Fade");
        nivelACargar = SceneManager.GetActiveScene().buildIndex;
    }

    public void EndLvl()
    {
        Destroy(GameObject.FindWithTag("CoinManager"));
        Destroy(GameObject.FindWithTag("Checkpoint"));
        if (SceneManager.GetActiveScene().buildIndex < 6)
        {
            SiguienteNivel();
        } else
        {
            CargarNivel(200);
        }
              
    }

    public void SiguienteNivel()
    {
        CargarNivel(PlayerPrefs.GetInt("currentLvl") + 1);
    }

    public void CargarNivel(int nivel)
    {
        Destroy(GameObject.FindWithTag("CoinManager"));
        Destroy(GameObject.FindWithTag("Checkpoint"));
        animator.SetTrigger("Fade");
        nivelACargar = nivel;
    }

    public void FadeTerminado()
    {
        if (nivelACargar < 100) {
            SceneManager.LoadScene(nivelACargar);
        } else
        {
            SceneManager.LoadScene("Shop");
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
