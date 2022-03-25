using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{

    private GameManager gm;
    
    private void Start() {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

        Thrust(4, 0);

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        
        if (posicaoViewport.x < 0 || posicaoViewport.x > 1)
        {
            Destroy(gameObject);
            return;
        }

        float playerX = gm.player.transform.position.x;
        float deltaX = playerX - transform.position.x;

        float scaleX = 1.0f + 5*posicaoViewport.x;
        float scaleY = 2.0f - 0.5f*posicaoViewport.x;
        transform.localScale = new Vector3(scaleX, scaleY, 1);

        // transform.scale.x = 1.0f*deltaX/Screen.width;
        // Debug.Log($"deltax: {deltaX} {}");
    }  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        
        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
}
