using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Begin,
    Play,
    GameEnd,
    Win,
    Lose
}

public static partial class GameStateEvent
{
    public static event System.Action<State> OnChangeGameState;
    public static void Fire_OnChangeGameState(State gameState) { OnChangeGameState?.Invoke(gameState); }
}

public class GameStates : Singleton<GameStates>
{
    public State gameState;

    protected override void Awake()
    {
        base.Awake();
        GameStateEvent.OnChangeGameState += OnChangeGameState;
    }

    private void Start() => OnChangeGameState(State.Begin);

    private void OnChangeGameState(State newState)
    {
        gameState = newState;

        switch (newState)
        {
            case State.Begin:
                HandleBegin();
                break;
            case State.Play:
                HandlePlay();
                break;
            case State.Win:
                HandleWin();
                break;
            case State.Lose:
                HandleLose();
                break;
            default:
                break;
        }
    }

    public void HandleBegin() => EventManager.OnBegin();

    public void HandlePlay()
    {
        EventManager.OnPlay();
        EventManager.OnStartMovements();
    }

    public void HandleWin() => EventManager.OnWins();
    public void HandleLose() => EventManager.OnLoses();

    private void OnDisable() => GameStateEvent.OnChangeGameState -= OnChangeGameState;
}
