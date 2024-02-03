using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mutear : MonoBehaviour
{

    private GameObject BGMusic;
    public Button buttonMusic;
    public Sprite[] musicIcons;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        BGMusic = GameObject.FindWithTag("Music");
        if (BGMusic.GetComponent<AudioSource>().volume == 0)
        {
            buttonMusic.GetComponent<Image>().sprite = musicIcons[1];
        }
        else
        {
            buttonMusic.GetComponent<Image>().sprite = musicIcons[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void MuteMusic()
    {
        muted = !muted;
        if (muted)
        {
            BGMusic.GetComponent<AudioSource>().volume = 0;
            buttonMusic.GetComponent<Image>().sprite = musicIcons[1];
        }
        else
        {
            BGMusic.GetComponent<AudioSource>().volume = 1;
            buttonMusic.GetComponent<Image>().sprite = musicIcons[0];
        }
    }
}
