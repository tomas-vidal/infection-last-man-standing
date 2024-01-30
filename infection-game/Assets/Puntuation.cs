using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntuation : MonoBehaviour
{

    public static int monedas;
    public Text puntuacionTexto;
    
    public Text ammoText;
    public int ammo;



    // Start is called before the first frame update
    void Start()
    {
        ammo = PlayerCombat.totalAmmo;
        if (SceneManager.GetActiveScene().buildIndex > 5)
        {
            ammoText.text = ammo.ToString();
        }
        puntuacionTexto.text = (PlayerPrefs.GetInt("totalCoins") + monedas).ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AgregarMoneda()
    {
        monedas++;
        puntuacionTexto.text = (PlayerPrefs.GetInt("totalCoins") + monedas).ToString();

    }

    public void DeleteBullet()
    {
        ammo--;
        ammoText.text = ammo.ToString();
    }
  
}
