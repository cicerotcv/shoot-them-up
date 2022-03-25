using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public int _defaultIntegrity;

    private int integrity;

    public int scoreValue;

    public GameObject healthbar;

    private GameManager gm;

    Vector3 direction;

    public void Start()
    {
        this.integrity = _defaultIntegrity;
        float dirX = Random.Range(-0.5f, 0.0f);
        this.direction = new Vector3(dirX, 0).normalized;
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        integrity--;
        this.UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        UI_HealthBar hpBehaviour = healthbar.GetComponent<UI_HealthBar>();
        float newScale = (float) integrity / (float) _defaultIntegrity;
        hpBehaviour.UpdateHealthBar(newScale);
    }
}
