using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillPrefab : MonoBehaviour
{
    private Transform transform;
    private float scale;
    private float opacity;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        scale += 0.03f;
        transform.localScale = new Vector2(scale, scale);
        if (scale >= 10f)
            Destroy(gameObject);
            
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HealthManager personaje = hitInfo.GetComponent<HealthManager>();
        if (personaje != null)
        {
            personaje.recibioDaño(3, this.gameObject.GetComponent<Transform>());
        }
    }
}
