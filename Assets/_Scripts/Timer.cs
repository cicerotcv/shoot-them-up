using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public int minutes = 0;

    public int seconds = 0;

    private float _lastCheck = 0.0f;

    private GameManager gm;

    public Timer(GameManager gm)
    {
        this.gm = gm;
    }

    public void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float now = Time.time;
        int deltaTime = (int)(now - this._lastCheck);

        if (deltaTime >= 1)
        {
            this.seconds++;

            if (this.seconds >= 60)
            {
                this.seconds = 0;
                this.minutes++;
            }

            this._lastCheck = Time.time;
        }
    }

    public void Reset()
    {
        this.minutes = 0;
        this.seconds = 0;
        this._lastCheck = 0.0f;
    }
}
