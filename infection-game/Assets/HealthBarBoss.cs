using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{

    public Slider slider;
    public ControladorDeEscenas ControladorDeEscenas;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void changeMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void changeCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
        if (slider.value <= 0)
        {
            StartCoroutine(delayEnd());
        }
    }

    public void initializeBossHealthBar(int currentHealth)
    {
        changeMaxHealth(currentHealth);
        changeCurrentHealth(currentHealth);
    }

    private IEnumerator delayEnd()
    {
        yield return new WaitForSeconds(2);
        ControladorDeEscenas.CargarNivel(14);
    }
}
