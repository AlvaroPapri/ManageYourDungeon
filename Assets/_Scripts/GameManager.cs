using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    [SerializeField] private TextMeshProUGUI _gameStateText;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.PrepareRound);
    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.PrepareRound:
                HandlePrepareRound();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.BoxCheck:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        
        OnGameStateChanged?.Invoke(newState);
        _gameStateText.text = newState.ToString();
    }

    private void HandleEnemyTurn()
    {
        EnemyManager.Instance.Move();
    }

    private void HandlePrepareRound()
    {
        
    }
}

public enum GameState
{
    PrepareRound,
    EnemyTurn,
    BoxCheck,
    Victory,
    Lose
}
