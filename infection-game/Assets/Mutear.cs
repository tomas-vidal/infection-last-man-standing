using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutear : MonoBehaviour
{

    private AudioListener AudioListener;

    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("MUTEAR");
            muted = !muted;
            if (muted)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }

    }


}
