using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        _playButton.interactable = state == GameState.PrepareRound;
    }

    public void PlayPressed()
    {
        GameManager.Instance.UpdateGameState(GameState.EnemyTurn);
    }
}
