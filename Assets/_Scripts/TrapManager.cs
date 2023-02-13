using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Traps;
using UnityEngine;

namespace _Scripts
{
    public class TrapManager : MonoBehaviour
    {
        public static TrapManager Instance;
    
        public static event Action OnTrapActivated;

        private bool _isSpikeTurn;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
        }

        private void GameManagerOnOnGameStateChanged(GameState state)
        {
            if (state == GameState.BoxCheck)
            {
                StopCoroutine(ActivateTraps());
                StartCoroutine(ActivateTraps());
            }
        }

        IEnumerator ActivateTraps()
        {
            OnTrapActivated?.Invoke();
            yield return new WaitForSeconds(2);
            
            GameManager.Instance.UpdateGameState(GameState.EnemyTurn);
        }
    }
}
