using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    Text textComp;

    GameManager gm;

    private int minutes = 0;

    private int seconds = 0;

    private float _lastCheck = 0.0f;

    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
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
        this.UpdateTime();
    }

    void UpdateTime()
    {

        int remainingSeconds = 120 - this.minutes * 60 - this.seconds;

        int seconds;
        float minutes = Math.DivRem(remainingSeconds, 60, out seconds);        

        if (seconds >= 10)
        {
            textComp.text = $"0{minutes}:{seconds}";
        }
        else
        {
            textComp.text = $"0{minutes}:0{seconds}";
        }
    }
}
