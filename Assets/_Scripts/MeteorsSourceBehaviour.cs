using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsSourceBehaviour : MonoBehaviour
{
    public GameObject smallRock;

    public GameObject bigRock;

    public GameManager gm;

    private float bigRockInterval = 15.0f;

    private float smallRockInterval = 2.0f;

    private float _lastBigRockCreated = 0.0f;

    private float _lastSmallRockCreated = 0.0f;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        this.DestroyLostMeteors();
        this.CreateNewMeteors();
        this.UpdateInterval();
    }

    void UpdateInterval()
    {
        int factor = gm.score / 30;
        if (factor > 0 && gm.score < 200)
        {
            bigRockInterval = (float) 15.0f / (factor + 1);
            smallRockInterval = (float) 2.0f / (factor + 1);
        }
    }

    void CreateNewMeteors()
    {
        if (Time.time - _lastBigRockCreated > bigRockInterval)
        {
            this.CreateMeteor(bigRock);
            _lastBigRockCreated = Time.time;
        }

        if (Time.time - _lastSmallRockCreated > smallRockInterval)
        {
            this.CreateMeteor(smallRock);
            _lastSmallRockCreated = Time.time;
        }
    }

    void CreateMeteor(GameObject meteor)
    {
        float offsetY = Random.Range(-4.0f, 4.0f);
        Vector3 meteorPosition =
            transform.position + new Vector3(0, offsetY, 0);
        Instantiate(meteor, meteorPosition, Quaternion.identity, transform);
    }

    void DestroyLostMeteors()
    {
        Vector3 playerPosition = gm.player.transform.position;
        foreach (Transform meteor in transform)
        {
            Vector3 meteorPosition = meteor.transform.position;

            if (meteorPosition.x - playerPosition.x < -2)
            {
                GameObject.Destroy(meteor.gameObject);
                gm.vidas--;
            }
        }
        if (gm.vidas <= 0)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}