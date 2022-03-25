using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public int integrity = 5;
    public int scoreValue = 10;

    private GameManager gm;

    Vector3 direction;

    public void Start()
    {
        float dirX = Random.Range(-0.5f, 0.0f);
        this.direction = new Vector3(dirX, 0).normalized;
        gm = GameManager.GetInstance();
    }

    public void Update()
    {
        // Debug.Log($"{transform.position.x} | {transform.position.y}");
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        integrity--;
        if (integrity <= 0)
        {
            Die();
            gm.score += this.scoreValue;
        }
    }

    public void Die()
    {
        Destroy (gameObject);
    }

    private void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        Thrust(this.direction.x, 0);
    }
}
