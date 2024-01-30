using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Transform platform;
    public int speed;
    private bool falling;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        platform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            platform.position = Vector2.MoveTowards(platform.position, new Vector2(platform.position.x, -20f), speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
            animator.SetBool("fall", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void fall()
    {
        falling = true;
    }
}
