using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private Transform player;
    public static bool cameraFollow;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {


        if (cameraFollow)
        {
            if (player.position.y < -5f)
            {
                Vector3 pos = new Vector3(player.position.x, -5f + 1f, transform.position.z);
                transform.position = pos;
            } else
            {
                Vector3 pos = new Vector3(player.position.x, player.position.y + 1f, transform.position.z);
                transform.position = pos;
            }
            
        }  
        
      
    
    }
}
