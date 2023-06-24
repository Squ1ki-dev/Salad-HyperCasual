using UnityEngine;
using System;

public static partial class EventManager
{
    // GameManager events
    public static event Action OnBeginGame;
    public static void OnBegin() { OnBeginGame?.Invoke(); }

    public static event Action OnPlayGame;
    public static void OnPlay() { OnPlayGame?.Invoke(); }

    public static event Action<Transform> OnGameEnd;
    public static void OnGameEnds(Transform transform) { OnGameEnd?.Invoke(transform); }

    public static event Action OnWin;
    public static void OnWins() { OnWin?.Invoke(); }

    public static event Action OnLose;
    public static void OnLoses() { OnLose?.Invoke(); }


    // Game Events
    public static event Action OnStartMovement;
    public static void OnStartMovements() { OnStartMovement?.Invoke(); }

    public static event Action OnStopMovement;
    public static void OnStopMovements() { OnStopMovement?.Invoke(); }

    public static event Action OnFinishArea;
    public static void OnFinishAreas() { OnFinishArea?.Invoke(); }

    public static event Action OnGameOver;
    public static void OnGamesOver() { OnGameOver?.Invoke(); }

    public static event Action LevelCompleted;
    public static void NextLevel() { LevelCompleted?.Invoke(); }

}