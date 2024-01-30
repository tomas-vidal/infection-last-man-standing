using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerCombat : MonoBehaviour
{

    private Animator animator;
    public Transform attackPointMelee;
    public Transform attackPointShoot;
    public float attackRange;
    public LayerMask enemyLayers;
    public static int attackDamage;
    private Personaje Personaje;
    private MovimientoJugador MovimientoJugador;
    public static float KBCounterBullet = 0.5f;
    public static bool knockback = true;

    public GameObject bulletPrefab;


    public float attackRateMelee = 2f;
    public float attackRateShoot = 5f;
    public float nextAttackTime = 0f;

    public Puntuation Puntuation;

    //public Sprite bullet;
    //public Sprite bulletMissing;
    //public Image bulletUI;
    public static int totalAmmo;
    public static float bulletKnockback;
    private int currentAmmo;

    private AudioSource src;
    public AudioClip[] Shoots;
    public AudioClip Stab;
    public AudioClip StabbedEnemy;

    void Start()
    {

        totalAmmo = PlayerPrefs.GetInt("totalAmmo", 1);
        bulletKnockback = PlayerPrefs.GetFloat("bulletKnockback", 8f);
        attackDamage = PlayerPrefs.GetInt("attackDamage", 50);
        currentAmmo = totalAmmo;
        Personaje = GetComponent<Personaje>();
        MovimientoJugador = GetComponent<MovimientoJugador>();
        animator = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Personaje.state == GameState.vivo && !PauseMenu.isPaused && SceneManager.GetActiveScene().buildIndex > 3 && MovimientoJugador.KBCounter <= 0)
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    AttackMelee();
                    nextAttackTime = Time.time + 1f / attackRateMelee;
                }
                if (SceneManager.GetActiveScene().buildIndex > 5)
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        if (currentAmmo > 0)
                        {
                            AttackShoot();
                            nextAttackTime = Time.time + 1f / attackRateShoot;
                            if (knockback)
                            {
                                if (attackPointShoot.position.x > Personaje.transform.position.x)
                                {
                                    Personaje.rb2d.velocity = new Vector2(-(bulletKnockback), bulletKnockback);
                                }
                                else
                                {
                                    Personaje.rb2d.velocity = new Vector2(bulletKnockback, bulletKnockback);
                                }
                                MovimientoJugador.KBCounter = KBCounterBullet;
                            }
                        }
                    }
                }
            }
        }
    }

    void AttackMelee()
    {
        animator.SetTrigger("AttackMelee");
        src.PlayOneShot(Stab);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointMelee.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            src.PlayOneShot(StabbedEnemy);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage, attackPointMelee);
        }
    }

    void AttackShoot()
    {
            animator.SetTrigger("AttackShoot");
            Instantiate(bulletPrefab, attackPointShoot.position, attackPointShoot.rotation);
            currentAmmo--;
            Puntuation.DeleteBullet();
            if (currentAmmo % 2 == 0)
            {
                src.PlayOneShot(Shoots[0]);
            } else
            {
                src.PlayOneShot(Shoots[1]);
            }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPointMelee == null) return;

        Gizmos.DrawWireSphere(attackPointMelee.position, attackRange);
    }
}
