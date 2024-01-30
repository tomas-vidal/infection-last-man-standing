using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    private AudioSource src;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectRandom()
    {
        src.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
