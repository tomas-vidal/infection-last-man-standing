using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Shop : MonoBehaviour
{

    public ControladorDeEscenas ControladorDeEscenas;
    [SerializeField] List<TemplateInformationItem> infoItems;
    [SerializeField] GameObject templateInfo;
    [SerializeField] TextMeshProUGUI textTotalCoins;


    //public void upgradeKnockback()
    //{
    //    Bullet.bulletDamage *= 2;
    //    PlayerCombat.knockback = false;
    //    ControladorDeEscenas.SiguienteNivel();
    //}

    //public void upgradeBullets()
    //{
    //    PlayerCombat.totalAmmo++;
    //    ControladorDeEscenas.SiguienteNivel();
    //}

    //public void upgradeKnifeDamage()
    //{
    //    PlayerCombat.attackDamage *= 2;
    //    ControladorDeEscenas.SiguienteNivel();
    //}


    // Start is called before the first frame update
    void Start()
    {
        if (templateInfo != null) 
        {
            var templateItem = templateInfo.GetComponent<TemplateItemShop>();

            foreach (var item in infoItems)
            {
                templateItem.image.sprite = item.image;
                templateItem.title.text = item.titulo;
                templateItem.textPrice.text = item.precio.ToString();

                Instantiate(templateItem, transform);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textTotalCoins != null)
        {
            textTotalCoins.text = PlayerPrefs.GetInt("totalCoins").ToString();
        }
    }
}
