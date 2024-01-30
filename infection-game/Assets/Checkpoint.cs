using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Checkpoint instance;
    public static bool checkpointReached;
    public static Vector2 lastCheckpointPos;
    private Animator checkpointAnimator;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            checkpointAnimator = GetComponent<Animator>();
            checkpointReached = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!checkpointReached)
            {
                lastCheckpointPos = GetComponent<Transform>().position;
                checkpointReached = true;
                checkpointAnimator.SetBool("checkpoint", true);
            }
            
        }
    }
   
}
