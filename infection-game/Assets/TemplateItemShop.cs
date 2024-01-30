using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemplateItemShop : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI textPrice;
    public TextMeshProUGUI title;
    public Button buyButton;
    int price;
    int totalCoins;
    // Start is called before the first frame update
    void Start()
    {
        price = int.Parse(textPrice.text);
        if (title.text == "+ ATAQUE" && PlayerPrefs.GetInt("attackDamage") == 100)
        {
            buyButton.interactable = false;
            textPrice.text = "COMPRADO";
            textPrice.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (title.text == "+ BALAS" && PlayerPrefs.GetInt("totalAmmo") > 10)
        {
            buyButton.interactable = false;
            textPrice.text = "COMPRADO";
            textPrice.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (title.text == "+ ATAQUE         - RETROCESO" && PlayerPrefs.GetInt("bulletDamage") > 100)
        {
            buyButton.interactable = false;
            textPrice.text = "COMPRADO";
            textPrice.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        totalCoins = PlayerPrefs.GetInt("totalCoins");
        if (price > totalCoins)
        {
            buyButton.interactable = false;
        }
    }
    public void Comprar()
    {
        totalCoins -= price;
        PlayerPrefs.SetInt("totalCoins", totalCoins);
        if (title.text == "+ ATAQUE")
        {
            buyButton.interactable = false;
            textPrice.text = "COMPRADO";
            PlayerPrefs.SetInt("attackDamage", 100);
            textPrice.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (title.text == "+ BALAS")
        {
            PlayerPrefs.SetInt("totalAmmo", PlayerPrefs.GetInt("totalAmmo") + 1);
            if (PlayerPrefs.GetInt("totalAmmo") > 10)
            {
                buyButton.interactable = false;
                textPrice.text = "COMPRADO";
                textPrice.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (title.text == "+ ATAQUE         - RETROCESO")
        {
            textPrice.text = "COMPRADO";
            buyButton.interactable = false;
            PlayerPrefs.SetInt("bulletDamage", 100);
            PlayerPrefs.SetFloat("bulletKnockback", 6f);
            textPrice.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
