using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public static int bulletDamage;
    public Rigidbody2D rb2d;

    void Start()
    {
        bulletDamage = PlayerPrefs.GetInt("bulletDamage", 50);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(bulletDamage, this.gameObject.GetComponent<Transform>());
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "Piso")
        {
            Destroy(gameObject);
        }
    }
}
