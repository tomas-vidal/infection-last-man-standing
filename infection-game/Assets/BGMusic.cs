using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private static BGMusic instance;

    private AudioSource src;

    private bool muted = false;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            src = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    muted = !muted;
        //    if (muted)
        //    {
        //        src.volume = 0;
        //    }
        //    else
        //    {
        //        src.volume = 1;
        //    }
        //}
    }
}
