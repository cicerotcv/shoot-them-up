using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState
    {
        MENU,
        GAME,
        PAUSE,
        ENDGAME
    }

    public GameState gameState { get; private set; }

    public int vidas;

    public int score;

    private static GameManager _instance;

    public GameObject player;

    public delegate void ChangeStateDelegate();

    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (
            (gameState == GameState.ENDGAME && nextState == GameState.GAME) ||
            (gameState == GameState.PAUSE && nextState == GameState.MENU)
        )
        {
            ResetStats();
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void ResetStats()
    {
        vidas = 3;
        score = 0;
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
            _instance.player = GameObject.FindGameObjectWithTag("Player");
        }

        return _instance;
    }

    private GameManager()
    {
        this.Setup();
    }

    private void Setup()
    {
        this.ResetStats();
        gameState = GameState.GAME;
    }
}
