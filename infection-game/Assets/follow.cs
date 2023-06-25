using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    public bool cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        if (cameraFollow)
        {
            Vector3 pos = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = pos;
        }  
    }
}
