using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLevels : MonoBehaviour
{
    public Button[] Buttons;
    public int lvlsUnlocked;

    // Start is called before the first frame update
    void Awake()
    {
        lvlsUnlocked = PlayerPrefs.GetInt("lvlsUnlocked", 2);
    }

    void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i == 1 || i == 3)
            {
                Buttons[i].gameObject.SetActive(false);
            }
            Buttons[i].interactable = false ;
        }
        for (int i = 0; i < lvlsUnlocked - 1; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
