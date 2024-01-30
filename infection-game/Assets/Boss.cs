using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private Animator animator;
    public Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    public Transform player;
    public bool enraged = false;
    private bool lookingRight = true;
    public EnemyHealth enemyHealth;
    [SerializeField] private LayerMask Player;
    public AudioSource src;
    public AudioClip bossAppear;
    public AudioClip bossSkill;

    [Header("Attack")]
    [SerializeField] private Transform attackControl;
    [SerializeField] private float attackRadio;
    [SerializeField] private int attackDamage;

    [Header("Skill")]
    public GameObject explotionPrefab;

    public Transform transform;

    void Start()
    {
        src = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
        bc2d = GetComponent<BoxCollider2D>();
        transform = GetComponent<Transform>();
        InvokeRepeating("skillBoss", 1f, Random.Range(5f, 10f));
        src.PlayOneShot(bossAppear);
    }

    void Update()
    {
    
        float distancePlayer = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("distancePlayer", distancePlayer);

        if (enemyHealth.currentHealth < (enemyHealth.maxHealth / 2))
        {
            animator.SetBool("enraged", true);
        }


        if (Personaje.state == GameState.muerto)
        {
            Destroy(bc2d);
        }
    }

    public void lookPlayer()
    {
        if ((player.position.x > transform.position.x && !lookingRight) || (player.position.x <= transform.position.x && lookingRight))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            lookingRight = !lookingRight;
        } 
    }

    public void Attack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackControl.position, attackRadio);

        foreach (Collider2D collision in objects)
        {
            if (collision.CompareTag("Player"))
            {
                    collision.GetComponent<HealthManager>().recibioDaño(attackDamage, transform);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (PlayerHead())
        {
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().recibioDaño(1, transform);
        }
    }

    public bool PlayerHead()
    {
        return Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.up, .1f, Player);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackControl.position, attackRadio);
    }


    void skillBoss()
    {
        animator.SetTrigger("skill");
    }

    public void startSkill()
    {
        Instantiate(explotionPrefab, transform.position, transform.rotation);
        src.PlayOneShot(bossSkill);
    }
}
