using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;
        [SerializeField] private List<Enemy> enemies;

        private void Awake()
        {
            Instance = this;
            GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

        }

        private void GameManagerOnGameStateChanged(GameState state)
        {
            if (enemies.Count <= 0)
            {
                GameManager.Instance.UpdateGameState(GameState.Victory);
            }
            
            if (state == GameState.EnemyTurn)
            {
                Move();
            }
        }

        public void Move()
        {
            StopCoroutine(MoveEnemies());
            StartCoroutine(MoveEnemies());
        }

        IEnumerator MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Move();
                yield return new WaitForSeconds(1f);
            }
        
        
            // GameManager.Instance.UpdateGameState(GameState.PrepareRound);
            GameManager.Instance.UpdateGameState(GameState.BoxCheck);
        }
    }
}
