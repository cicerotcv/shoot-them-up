using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;

    private int lifes;

    public GameObject bullet;

    public Transform arma01;

    public float shootDelay;

    private float _lastShootTimestamp = 0.0f;

    public AudioClip shootSFX;

    GameManager gm;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lifes = 10;
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(1.0f + xInput, yInput);

        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
    }

    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Escape) &&
            gm.gameState == GameManager.GameState.GAME
        )
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
}
