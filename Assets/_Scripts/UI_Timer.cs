using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    Text textComp;

    GameManager gm;

    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        gm.timer.Update();
        UpdateTime();
    }

    void UpdateTime()
    {
        int remainingSeconds = 120 - gm.timer.minutes * 60 - gm.timer.seconds;

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
