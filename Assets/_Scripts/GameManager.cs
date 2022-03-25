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

    public MeteorsSourceBehaviour enemySource;

    public Timer timer;

    public delegate void ChangeStateDelegate();

    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (
            (gameState == GameState.ENDGAME && nextState == GameState.GAME) ||
            (gameState == GameState.ENDGAME && nextState == GameState.MENU) ||
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
        enemySource.Wipe();
        timer.Reset();
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject tmp = GameObject.FindGameObjectWithTag("EnemySource");
        enemySource = tmp.GetComponent<MeteorsSourceBehaviour>();
        timer = new Timer();

        this.Setup();
    }

    private void Setup()
    {
        this.ResetStats();
        gameState = GameState.GAME;
    }
}
